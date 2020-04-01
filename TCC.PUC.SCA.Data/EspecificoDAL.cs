using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;
using TCC.PUC.SCA.Data.Common;
using TCC.PUC.SCA.Data.Connection;
using TCC.PUC.SCA.Model.DBEntities;
using TCC.PUC.SCA.Model.SpecificEntities.Common;
using TCC.PUC.SCA.Model.SpecificEntities.Restricted;

namespace TCC.PUC.SCA.Data
{
    public class EspecificoDAL : BaseSqlDAL
    {
        private readonly AppSettings _appSettings;
        public EspecificoDAL(AppSettings appSettings, ConexaoSqlServer con = null) : base(appSettings, con)
        {
            _appSettings = appSettings;
        }

        public void InserirSensorDadosIncidente(SensorDadosIncidente sensorDadosIncidente)
        {
            StringBuilder sbSensorDados = new StringBuilder();
            sbSensorDados.Append("INSERT INTO [dbo].[SensorDados]");
            sbSensorDados.Append(" (SensorId, Intensidade, DataInclusao)");
            sbSensorDados.Append(" VALUES");
            sbSensorDados.Append(" (@SensorId, @Intensidade, @DataInclusao);");
            sbSensorDados.Append(" SELECT CAST(scope_identity() AS int)");

            StringBuilder sbIncidente = new StringBuilder();
            sbIncidente.Append("INSERT INTO [dbo].[Incidente]");
            sbIncidente.Append(" (SensorDadosId, PlanoAcaoId, DataInclusao, DataAlerta)");
            sbIncidente.Append(" VALUES");
            sbIncidente.Append(" (@SensorDadosId, @PlanoAcaoId, @DataInclusao, @DataAlerta);");
            sbIncidente.Append(" SELECT CAST(scope_identity() AS int)");

            TransactionOptions transactionOptions = new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
            };

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
            {
                try
                {
                    using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                    {
                        using (SqlCommand cmdSensorDados = new SqlCommand(sbSensorDados.ToString(), GetConexaoSql()))
                        {
                            cmdSensorDados.Parameters.Add(new SqlParameter("@SensorId", sensorDadosIncidente.SensorDados.SensorId));
                            cmdSensorDados.Parameters.Add(new SqlParameter("@Intensidade", sensorDadosIncidente.SensorDados.Intensidade));
                            cmdSensorDados.Parameters.Add(new SqlParameter("@DataInclusao", sensorDadosIncidente.SensorDados.DataInclusao == null ? (object)DBNull.Value : sensorDadosIncidente.SensorDados.DataInclusao));

                            sensorDadosIncidente.SensorDados.Id = (Int32)cmdSensorDados.ExecuteScalar();
                        }

                        if (sensorDadosIncidente.Incidente != null)
                        {
                            using (SqlCommand cmdIncidente = new SqlCommand(sbIncidente.ToString(), GetConexaoSql()))
                            {
                                cmdIncidente.Parameters.Add(new SqlParameter("@SensorDadosId", sensorDadosIncidente.SensorDados.Id));
                                cmdIncidente.Parameters.Add(new SqlParameter("@PlanoAcaoId", sensorDadosIncidente.Incidente.PlanoAcaoId));
                                cmdIncidente.Parameters.Add(new SqlParameter("@DataInclusao", sensorDadosIncidente.SensorDados.DataInclusao == null ? (object)DBNull.Value : sensorDadosIncidente.SensorDados.DataInclusao));
                                cmdIncidente.Parameters.Add(new SqlParameter("@DataAlerta", (object)DBNull.Value));

                                sensorDadosIncidente.Incidente.Id = (Int32)cmdIncidente.ExecuteScalar();
                            }
                        }
                    }

                    scope.Complete();
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw new Exception($"Erro - Inserir - {ex.ToString()}");
                }
            }
        }

        public List<Alerta> ObterListaAlerta()
        {
            List<Alerta> lAlerta = new List<Alerta>();
            Alerta alerta;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT");
            sb.Append(" Incidente.Id AS IncidenteId,");
            sb.Append(" PlanoAcao.Mensagem AS PlanoAcaoMensagem,");
            sb.Append(" Pessoa.Nome AS PessoaNome, Email AS PessoaEmail, Celular AS PessoaCelular, SMS AS PessoaSMS, Whatsapp AS PessoaWhatsapp,");
            sb.Append(" Barragem.Nome AS BarragemNome");
            sb.Append(" FROM [TCC.PUC.SCA].[dbo].[Incidente] Incidente");
            sb.Append(" INNER JOIN [TCC.PUC.SCA].[dbo].[PlanoAcao] PlanoAcao ON Incidente.PlanoAcaoId = PlanoAcao.Id");
            sb.Append(" INNER JOIN [TCC.PUC.SCA].[dbo].[SensorDados] SensorDados ON Incidente.SensorDadosId = SensorDados.Id");
            sb.Append(" INNER JOIN [TCC.PUC.SCA].[dbo].[Sensor] Sensor ON SensorDados.SensorId = Sensor.Id");
            sb.Append(" INNER JOIN [TCC.PUC.SCA].[dbo].[Barragem] Barragem ON Sensor.BarragemId = Barragem.Id");
            sb.Append(" INNER JOIN [TCC.PUC.SCA].[dbo].[Pessoa] Pessoa ON Barragem.Id = Pessoa.BarragemId");
            sb.Append(" WHERE	Incidente.DataAlerta IS NULL");

            try
            {
                using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), GetConexaoSql()))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            alerta = new Alerta();
                            if (!reader["IncidenteId"].Equals(DBNull.Value)) alerta.IncidenteId = (Int32)reader["IncidenteId"];
                            if (!reader["PlanoAcaoMensagem"].Equals(DBNull.Value)) alerta.PlanoAcaoMensagem = (String)reader["PlanoAcaoMensagem"];
                            if (!reader["PessoaNome"].Equals(DBNull.Value)) alerta.PessoaNome = (String)reader["PessoaNome"];
                            if (!reader["PessoaEmail"].Equals(DBNull.Value)) alerta.PessoaEmail = (String)reader["PessoaEmail"];
                            if (!reader["PessoaCelular"].Equals(DBNull.Value)) alerta.PessoaCelular = (String)reader["PessoaCelular"];
                            if (!reader["PessoaSMS"].Equals(DBNull.Value)) alerta.PessoaSMS = (String)reader["PessoaSMS"];
                            if (!reader["PessoaWhatsapp"].Equals(DBNull.Value)) alerta.PessoaWhatsapp = (String)reader["PessoaWhatsapp"];
                            if (!reader["BarragemNome"].Equals(DBNull.Value)) alerta.BarragemNome = (String)reader["BarragemNome"];

                            lAlerta.Add(alerta);
                        }
                    }
                }

                return lAlerta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
