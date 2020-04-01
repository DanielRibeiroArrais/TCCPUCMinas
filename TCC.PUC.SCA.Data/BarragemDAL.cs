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
    public class BarragemDAL : BaseSqlDAL
    {
        private readonly AppSettings _appSettings;
        public BarragemDAL(AppSettings appSettings, ConexaoSqlServer con = null) : base(appSettings, con)
        {
            _appSettings = appSettings;
        }

        public void Inserir(Barragem barragem)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO [dbo].[Barragem]");
            sb.Append(" (Nome, Latitude, Longitude, Situacao, DataInclusao, DataAlteracao)");
            sb.Append(" VALUES");
            sb.Append(" (@Nome, @Latitude, @Longitude, @Situacao, @DataInclusao, @DataAlteracao);");
            sb.Append(" SELECT CAST(scope_identity() AS int)");

            try
            {
                using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), GetConexaoSql()))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Nome", barragem.Nome ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Latitude", barragem.Latitude ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Longitude", barragem.Longitude ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Situacao", barragem.Situacao));
                        cmd.Parameters.Add(new SqlParameter("@DataInclusao", barragem.DataInclusao == null ? (object)DBNull.Value : barragem.DataInclusao));
                        cmd.Parameters.Add(new SqlParameter("@DataAlteracao", (object)DBNull.Value));

                        barragem.Id = (Int32)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(Barragem barragem)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE [dbo].[Barragem] SET");
            sb.Append(" Nome = @Nome, Latitude = @Latitude, Longitude = @Longitude, Situacao = @Situacao, DataAlteracao = @DataAlteracao");
            sb.Append(" WHERE Id = @Id");

            try
            {
                using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), GetConexaoSql()))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Id", barragem.Id));
                        cmd.Parameters.Add(new SqlParameter("@Nome", barragem.Nome ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Latitude", barragem.Latitude ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Longitude", barragem.Longitude ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Situacao", barragem.Situacao));
                        cmd.Parameters.Add(new SqlParameter("@DataAlteracao", barragem.DataAlteracao == null ? (object)DBNull.Value : barragem.DataAlteracao));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Barragem> ObterLista()
        {
            List<Barragem> lBarragem = new List<Barragem>();
            Barragem barragem;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM [dbo].[Barragem]");

            try
            {
                using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), GetConexaoSql()))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            barragem = new Barragem();
                            if (!reader["Id"].Equals(DBNull.Value)) barragem.Id = (Int32)reader["Id"];
                            if (!reader["Nome"].Equals(DBNull.Value)) barragem.Nome = (String)reader["Nome"];
                            if (!reader["Latitude"].Equals(DBNull.Value)) barragem.Latitude = (String)reader["Latitude"];
                            if (!reader["Longitude"].Equals(DBNull.Value)) barragem.Longitude = (String)reader["Longitude"];
                            if (!reader["Situacao"].Equals(DBNull.Value)) barragem.Situacao = (bool)reader["Situacao"];
                            if (!reader["DataInclusao"].Equals(DBNull.Value)) barragem.DataInclusao = (DateTime)reader["DataInclusao"];
                            if (!reader["DataAlteracao"].Equals(DBNull.Value)) barragem.DataAlteracao = (DateTime?)reader["DataAlteracao"];

                            lBarragem.Add(barragem);
                        }
                    }
                }

                return lBarragem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Barragem ObterPorId(int id)
        {
            Barragem barragem = null;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM [dbo].[Barragem] WHERE Id = @Id");

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
                            barragem = new Barragem();
                            if (!reader["Id"].Equals(DBNull.Value)) barragem.Id = (Int32)reader["Id"];
                            if (!reader["Nome"].Equals(DBNull.Value)) barragem.Nome = (String)reader["Nome"];
                            if (!reader["Latitude"].Equals(DBNull.Value)) barragem.Latitude = (String)reader["Latitude"];
                            if (!reader["Longitude"].Equals(DBNull.Value)) barragem.Longitude = (String)reader["Longitude"];
                            if (!reader["Situacao"].Equals(DBNull.Value)) barragem.Situacao = (bool)reader["Situacao"];
                            if (!reader["DataInclusao"].Equals(DBNull.Value)) barragem.DataInclusao = (DateTime)reader["DataInclusao"];
                            if (!reader["DataAlteracao"].Equals(DBNull.Value)) barragem.DataAlteracao = (DateTime?)reader["DataAlteracao"];
                        }
                    }
                }

                return barragem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}