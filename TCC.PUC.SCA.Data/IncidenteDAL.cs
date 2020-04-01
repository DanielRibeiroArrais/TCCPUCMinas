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
    public class IncidenteDAL : BaseSqlDAL
    {
        private readonly AppSettings _appSettings;
        public IncidenteDAL(AppSettings appSettings, ConexaoSqlServer con = null) : base(appSettings, con)
        {
            _appSettings = appSettings;
        }

        public void Inserir(Incidente incidente)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO [dbo].[Incidente]");
            sb.Append(" (SensorDadosId, PlanoAcaoId, DataInclusao, DataAlerta)");
            sb.Append(" VALUES");
            sb.Append(" (@SensorDadosId, @PlanoAcaoId, @DataInclusao, @DataAlerta);");
            sb.Append(" SELECT CAST(scope_identity() AS int)");

            try
            {
                using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), GetConexaoSql()))
                    {
                        cmd.Parameters.Add(new SqlParameter("@SensorDadosId", incidente.SensorDadosId));
                        cmd.Parameters.Add(new SqlParameter("@PlanoAcaoId", incidente.PlanoAcaoId));
                        cmd.Parameters.Add(new SqlParameter("@DataInclusao", incidente.DataInclusao == null ? (object)DBNull.Value : incidente.DataInclusao));
                        cmd.Parameters.Add(new SqlParameter("@DataAlerta", (object)DBNull.Value));

                        incidente.Id = (Int32)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(Pessoa pessoa)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE [dbo].[Incidente] SET");
            sb.Append(" PlanoAcaoId = @PlanoAcaoId, DataInclusao, DataAlerta");
            sb.Append(" WHERE Id = @Id");

            try
            {
                using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), GetConexaoSql()))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Id", pessoa.Id));
                        cmd.Parameters.Add(new SqlParameter("@BarragemId", pessoa.BarragemId));
                        cmd.Parameters.Add(new SqlParameter("@Nome", pessoa.Nome ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Situacao", pessoa.Situacao));
                        cmd.Parameters.Add(new SqlParameter("@Email", pessoa.Email ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Celular", pessoa.Celular ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@SMS", pessoa.SMS ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Whatsapp", pessoa.Whatsapp ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DataAlerta", pessoa.DataAlteracao == null ? (object)DBNull.Value : pessoa.DataAlteracao));

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Incidente> ObterLista()
        {
            List<Incidente> lIncidente = new List<Incidente>();
            Incidente incidente;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM [dbo].[Incidente]");

            try
            {
                using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), GetConexaoSql()))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            incidente = new Incidente();
                            if (!reader["Id"].Equals(DBNull.Value)) incidente.Id = (Int32)reader["Id"];
                            if (!reader["SensorDadosId"].Equals(DBNull.Value)) incidente.SensorDadosId = (Int32)reader["SensorDadosId"];
                            if (!reader["PlanoAcaoId"].Equals(DBNull.Value)) incidente.PlanoAcaoId = (Int32)reader["PlanoAcaoId"];
                            if (!reader["DataInclusao"].Equals(DBNull.Value)) incidente.DataInclusao = (DateTime)reader["DataInclusao"];
                            if (!reader["DataAlerta"].Equals(DBNull.Value)) incidente.DataAlerta = (DateTime)reader["DataAlerta"];

                            lIncidente.Add(incidente);
                        }
                    }
                }

                return lIncidente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Incidente ObterPorId(int id)
        {
            Incidente incidente = null;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM [dbo].[Incidente] WHERE Id = @Id");

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
                            incidente = new Incidente();
                            if (!reader["Id"].Equals(DBNull.Value)) incidente.Id = (Int32)reader["Id"];
                            if (!reader["SensorDadosId"].Equals(DBNull.Value)) incidente.SensorDadosId = (Int32)reader["SensorDadosId"];
                            if (!reader["PlanoAcaoId"].Equals(DBNull.Value)) incidente.PlanoAcaoId = (Int32)reader["PlanoAcaoId"];
                            if (!reader["DataInclusao"].Equals(DBNull.Value)) incidente.DataInclusao = (DateTime)reader["DataInclusao"];
                            if (!reader["DataAlerta"].Equals(DBNull.Value)) incidente.DataAlerta = (DateTime)reader["DataAlerta"];
                        }
                    }
                }

                return incidente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Incidente> ObterListaPorDataAlertaNull()
        {
            List<Incidente> lIncidente = new List<Incidente>();
            Incidente incidente;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM [dbo].[Incidente] WHERE DataAlerta IS NULL");

            try
            {
                using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), GetConexaoSql()))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            incidente = new Incidente();
                            if (!reader["Id"].Equals(DBNull.Value)) incidente.Id = (Int32)reader["Id"];
                            if (!reader["SensorDadosId"].Equals(DBNull.Value)) incidente.SensorDadosId = (Int32)reader["SensorDadosId"];
                            if (!reader["PlanoAcaoId"].Equals(DBNull.Value)) incidente.PlanoAcaoId = (Int32)reader["PlanoAcaoId"];
                            if (!reader["DataInclusao"].Equals(DBNull.Value)) incidente.DataInclusao = (DateTime)reader["DataInclusao"];
                            if (!reader["DataAlerta"].Equals(DBNull.Value)) incidente.DataAlerta = (DateTime)reader["DataAlerta"];

                            lIncidente.Add(incidente);
                        }
                    }
                }

                return lIncidente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}