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
    public class PlanoAcaoDAL : BaseSqlDAL
    {
        private readonly AppSettings _appSettings;
        public PlanoAcaoDAL(AppSettings appSettings, ConexaoSqlServer con = null) : base(appSettings, con)
        {
            _appSettings = appSettings;
        }

        public void Inserir(PlanoAcao planoAcao)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO [dbo].[PlanoAcao]");
            sb.Append(" (Tipo, De, Ate, Mensagem, DataInclusao, DataAlteracao)");
            sb.Append(" VALUES");
            sb.Append(" (@Tipo, @De, @Ate, @Mensagem, @DataInclusao, @DataAlteracao);");
            sb.Append(" SELECT CAST(scope_identity() AS int)");

            try
            {
                using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), GetConexaoSql()))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Tipo", planoAcao.Tipo ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@De", planoAcao.De));
                        cmd.Parameters.Add(new SqlParameter("@Ate", planoAcao.Ate));
                        cmd.Parameters.Add(new SqlParameter("@Mensagem", planoAcao.Mensagem ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DataInclusao", planoAcao.DataInclusao == null ? (object)DBNull.Value : planoAcao.DataInclusao));
                        cmd.Parameters.Add(new SqlParameter("@DataAlteracao", (object)DBNull.Value));

                        planoAcao.Id = (Int32)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(PlanoAcao planoAcao)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE [dbo].[PlanoAcao] SET");
            sb.Append(" De = @De, Ate = @Ate, Mensagem = @Mensagem, DataAlteracao = @DataAlteracao");
            sb.Append(" WHERE Id = @Id");

            try
            {
                using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), GetConexaoSql()))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Id", planoAcao.Id));
                        cmd.Parameters.Add(new SqlParameter("@De", planoAcao.De));
                        cmd.Parameters.Add(new SqlParameter("@Ate", planoAcao.Ate));
                        cmd.Parameters.Add(new SqlParameter("@Mensagem", planoAcao.Mensagem ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DataAlteracao", planoAcao.DataAlteracao == null ? (object)DBNull.Value : planoAcao.DataAlteracao));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PlanoAcao> ObterLista()
        {
            List<PlanoAcao> lPlanoAcao = new List<PlanoAcao>();
            PlanoAcao planoAcao;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM [dbo].[PlanoAcao]");

            try
            {
                using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), GetConexaoSql()))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            planoAcao = new PlanoAcao();
                            if (!reader["Id"].Equals(DBNull.Value)) planoAcao.Id = (Int32)reader["Id"];
                            if (!reader["Tipo"].Equals(DBNull.Value)) planoAcao.Tipo = (String)reader["Tipo"];
                            if (!reader["De"].Equals(DBNull.Value)) planoAcao.De = (int)reader["De"];
                            if (!reader["Ate"].Equals(DBNull.Value)) planoAcao.Ate = (int)reader["Ate"];
                            if (!reader["Mensagem"].Equals(DBNull.Value)) planoAcao.Mensagem = (String)reader["Mensagem"];
                            if (!reader["DataInclusao"].Equals(DBNull.Value)) planoAcao.DataInclusao = (DateTime)reader["DataInclusao"];
                            if (!reader["DataAlteracao"].Equals(DBNull.Value)) planoAcao.DataAlteracao = (DateTime?)reader["DataAlteracao"];

                            lPlanoAcao.Add(planoAcao);
                        }
                    }
                }

                return lPlanoAcao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PlanoAcao ObterPorId(int id)
        {
            PlanoAcao planoAcao = null;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM [dbo].[PlanoAcao] WHERE Id = @Id");

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
                            planoAcao = new PlanoAcao();
                            if (!reader["Id"].Equals(DBNull.Value)) planoAcao.Id = (Int32)reader["Id"];
                            if (!reader["Tipo"].Equals(DBNull.Value)) planoAcao.Tipo = (String)reader["Tipo"];
                            if (!reader["De"].Equals(DBNull.Value)) planoAcao.De = (int)reader["De"];
                            if (!reader["Ate"].Equals(DBNull.Value)) planoAcao.Ate = (int)reader["Ate"];
                            if (!reader["Mensagem"].Equals(DBNull.Value)) planoAcao.Mensagem = (String)reader["Mensagem"];
                            if (!reader["DataInclusao"].Equals(DBNull.Value)) planoAcao.DataInclusao = (DateTime)reader["DataInclusao"];
                            if (!reader["DataAlteracao"].Equals(DBNull.Value)) planoAcao.DataAlteracao = (DateTime?)reader["DataAlteracao"];
                        }
                    }
                }

                return planoAcao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}