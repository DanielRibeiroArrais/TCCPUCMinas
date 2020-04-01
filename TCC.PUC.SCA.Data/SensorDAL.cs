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
    public class SensorDAL : BaseSqlDAL
    {
        private readonly AppSettings _appSettings;
        public SensorDAL(AppSettings appSettings, ConexaoSqlServer con = null) : base(appSettings, con)
        {
            _appSettings = appSettings;
        }

        public void Inserir(Sensor sensor)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO [dbo].[Sensor]");
            sb.Append(" (BarragemId, Nome, Tipo, Codigo, Situacao, DataInclusao, DataAlteracao)");
            sb.Append(" VALUES");
            sb.Append(" (@BarragemId, @Nome, @Tipo, @Codigo, @Situacao, @DataInclusao, @DataAlteracao);");
            sb.Append(" SELECT CAST(scope_identity() AS int)");

            try
            {
                using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), GetConexaoSql()))
                    {
                        cmd.Parameters.Add(new SqlParameter("@BarragemId", sensor.BarragemId));
                        cmd.Parameters.Add(new SqlParameter("@Nome", sensor.Nome ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Codigo", sensor.Codigo ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Tipo", sensor.Tipo ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Situacao", sensor.Situacao));
                        cmd.Parameters.Add(new SqlParameter("@DataInclusao", sensor.DataInclusao == null ? (object)DBNull.Value : sensor.DataInclusao));
                        cmd.Parameters.Add(new SqlParameter("@DataAlteracao", (object)DBNull.Value));

                        sensor.Id = (Int32)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(Sensor sensor)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE [dbo].[Sensor] SET");
            sb.Append(" Nome = @Nome, Codigo = @Codigo, Tipo = @Tipo, Situacao = @Situacao, DataAlteracao = @DataAlteracao");
            sb.Append(" WHERE Id = @Id");

            try
            {
                using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), GetConexaoSql()))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Id", sensor.Id));
                        cmd.Parameters.Add(new SqlParameter("@Nome", sensor.Nome ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Codigo", sensor.Codigo ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Tipo", sensor.Tipo ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Situacao", sensor.Situacao));
                        cmd.Parameters.Add(new SqlParameter("@DataAlteracao", sensor.DataInclusao == null ? DateTime.Now : sensor.DataAlteracao));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Sensor> ObterLista()
        {
            List<Sensor> lSensor = new List<Sensor>();
            Sensor sensor;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM [dbo].[Sensor]");

            try
            {
                using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), GetConexaoSql()))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            sensor = new Sensor();
                            if (!reader["Id"].Equals(DBNull.Value)) sensor.Id = (Int32)reader["Id"];
                            if (!reader["BarragemId"].Equals(DBNull.Value)) sensor.BarragemId = (Int32)reader["BarragemId"];
                            if (!reader["Nome"].Equals(DBNull.Value)) sensor.Nome = (String)reader["Nome"];
                            if (!reader["Codigo"].Equals(DBNull.Value)) sensor.Codigo = (String)reader["Codigo"];
                            if (!reader["Tipo"].Equals(DBNull.Value)) sensor.Tipo = (String)reader["Tipo"];
                            if (!reader["Situacao"].Equals(DBNull.Value)) sensor.Situacao = (bool)reader["Situacao"];
                            if (!reader["DataInclusao"].Equals(DBNull.Value)) sensor.DataInclusao = (DateTime)reader["DataInclusao"];
                            if (!reader["DataAlteracao"].Equals(DBNull.Value)) sensor.DataAlteracao = (DateTime?)reader["DataAlteracao"];

                            lSensor.Add(sensor);
                        }
                    }
                }

                return lSensor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Sensor ObterPorId(int id)
        {
            Sensor sensor = null;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM [dbo].[Sensor] WHERE Id = @Id");

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
                            sensor = new Sensor();
                            if (!reader["Id"].Equals(DBNull.Value)) sensor.Id = (Int32)reader["Id"];
                            if (!reader["BarragemId"].Equals(DBNull.Value)) sensor.BarragemId = (Int32)reader["BarragemId"];
                            if (!reader["Nome"].Equals(DBNull.Value)) sensor.Nome = (String)reader["Nome"];
                            if (!reader["Codigo"].Equals(DBNull.Value)) sensor.Codigo = (String)reader["Codigo"];
                            if (!reader["Tipo"].Equals(DBNull.Value)) sensor.Tipo = (String)reader["Tipo"];
                            if (!reader["Situacao"].Equals(DBNull.Value)) sensor.Situacao = (bool)reader["Situacao"];
                            if (!reader["DataInclusao"].Equals(DBNull.Value)) sensor.DataInclusao = (DateTime)reader["DataInclusao"];
                            if (!reader["DataAlteracao"].Equals(DBNull.Value)) sensor.DataAlteracao = (DateTime?)reader["DataAlteracao"];
                        }
                    }
                }

                return sensor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
