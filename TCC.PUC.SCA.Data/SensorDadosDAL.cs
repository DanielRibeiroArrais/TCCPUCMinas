using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TCC.PUC.SCA.Data.Common;
using TCC.PUC.SCA.Data.Connection;
using TCC.PUC.SCA.Model.DBEntities;
using TCC.PUC.SCA.Model.SpecificEntities.Restricted;

namespace TCC.PUC.SCA.Data
{
    public class SensorDadosDAL : BaseSqlDAL
    {
        private readonly AppSettings _appSettings;
        public SensorDadosDAL(AppSettings appSettings, ConexaoSqlServer con = null) : base(appSettings, con)
        {
            _appSettings = appSettings;
        }

        public void Inserir(SensorDados sensorDados)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO [dbo].[SensorDados]");
            sb.Append(" (SensorId, Intensidade, DataInclusao)");
            sb.Append(" VALUES");
            sb.Append(" (@SensorId, @Intensidade, @DataInclusao);");
            sb.Append(" SELECT CAST(scope_identity() AS int)");

            try
            {
                using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), GetConexaoSql()))
                    {
                        cmd.Parameters.Add(new SqlParameter("@SensorId", sensorDados.SensorId));
                        cmd.Parameters.Add(new SqlParameter("@Intensidade", sensorDados.Intensidade));
                        cmd.Parameters.Add(new SqlParameter("@DataInclusao", sensorDados.DataInclusao == null ? (object)DBNull.Value : sensorDados.DataInclusao));

                        sensorDados.Id = (Int32)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro - Inserir - {ex.ToString()}");
            }
        }

        public List<SensorDados> ObterLista()
        {
            List<SensorDados> lSensorDados = new List<SensorDados>();
            SensorDados sensorDados;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM [dbo].[SensorDados]");

            try
            {
                using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), GetConexaoSql()))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            sensorDados = new SensorDados();
                            if (!reader["Id"].Equals(DBNull.Value)) sensorDados.Id = (Int32)reader["Id"];
                            if (!reader["SensorId"].Equals(DBNull.Value)) sensorDados.SensorId = (Int32)reader["SensorId"];
                            if (!reader["Intensidade"].Equals(DBNull.Value)) sensorDados.Intensidade = (int)reader["Intensidade"];
                            if (!reader["DataInclusao"].Equals(DBNull.Value)) sensorDados.DataInclusao = (DateTime)reader["DataInclusao"];

                            lSensorDados.Add(sensorDados);
                        }
                    }
                }

                return lSensorDados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SensorDados ObterPorId(int id)
        {
            SensorDados sensorDados = null;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM [dbo].[SensorDados] WHERE Id = @Id");

            try
            {
                using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), GetConexaoSql()))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Id", id));

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            sensorDados = new SensorDados();
                            if (!reader["Id"].Equals(DBNull.Value)) sensorDados.Id = (Int32)reader["Id"];
                            if (!reader["SensorId"].Equals(DBNull.Value)) sensorDados.SensorId = (Int32)reader["SensorId"];
                            if (!reader["Intensidade"].Equals(DBNull.Value)) sensorDados.Intensidade = (int)reader["Intensidade"];
                            if (!reader["DataInclusao"].Equals(DBNull.Value)) sensorDados.DataInclusao = (DateTime)reader["DataInclusao"];
                        }
                    }
                }

                return sensorDados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SensorDados> ObterListaPorSensorId(int sensorId)
        {
            List<SensorDados> lSensorDados = new List<SensorDados>();
            SensorDados sensorDados;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM [dbo].[SensorDados] NOLOCK WHERE SensorId = @SensorId");

            try
            {
                using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), GetConexaoSql()))
                    {
                        cmd.Parameters.Add(new SqlParameter("@SensorId", sensorId));

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            sensorDados = new SensorDados();
                            if (!reader["Id"].Equals(DBNull.Value)) sensorDados.Id = (Int32)reader["Id"];
                            if (!reader["SensorId"].Equals(DBNull.Value)) sensorDados.SensorId = (Int32)reader["SensorId"];
                            if (!reader["Intensidade"].Equals(DBNull.Value)) sensorDados.Intensidade = (int)reader["Intensidade"];
                            if (!reader["DataInclusao"].Equals(DBNull.Value)) sensorDados.DataInclusao = (DateTime)reader["DataInclusao"];

                            lSensorDados.Add(sensorDados);
                        }
                    }
                }

                return lSensorDados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
