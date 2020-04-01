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
    public class PessoaDAL : BaseSqlDAL
    {
        private readonly AppSettings _appSettings;
        public PessoaDAL(AppSettings appSettings, ConexaoSqlServer con = null) : base(appSettings, con)
        {
            _appSettings = appSettings;
        }

        public void Inserir(Pessoa pessoa)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO [dbo].[Pessoa]");
            sb.Append(" (BarragemId, Nome, Situacao, Email, Celular, SMS, Whatsapp, DataInclusao, DataAlteracao)");
            sb.Append(" VALUES");
            sb.Append(" (@BarragemId, @Nome, @Situacao, @Email, @Celular, @SMS, @Whatsapp, @DataInclusao, @DataAlteracao);");
            sb.Append(" SELECT CAST(scope_identity() AS int)");

            try
            {
                using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), GetConexaoSql()))
                    {
                        cmd.Parameters.Add(new SqlParameter("@BarragemId", pessoa.BarragemId));
                        cmd.Parameters.Add(new SqlParameter("@Nome", pessoa.Nome ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Situacao", pessoa.Situacao));
                        cmd.Parameters.Add(new SqlParameter("@Email", pessoa.Email ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Celular", pessoa.Celular ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@SMS", pessoa.SMS ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Whatsapp", pessoa.Whatsapp ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@DataInclusao", pessoa.DataInclusao == null ? (object)DBNull.Value : pessoa.DataInclusao));
                        cmd.Parameters.Add(new SqlParameter("@DataAlteracao", (object)DBNull.Value));

                        pessoa.Id = (Int32)cmd.ExecuteScalar();
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
            sb.Append("UPDATE [dbo].[Pessoa] SET");
            sb.Append(" Nome = @Nome, Situacao = @Situacao, Email = @Email, Celular = @Celular, SMS = @SMS, Whatsapp = @Whatsapp, DataAlteracao = @DataAlteracao");
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
                        cmd.Parameters.Add(new SqlParameter("@DataAlteracao", pessoa.DataAlteracao == null ? (object)DBNull.Value : pessoa.DataAlteracao));

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Pessoa> ObterLista()
        {
            List<Pessoa> lPessoa = new List<Pessoa>();
            Pessoa pessoa;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM [dbo].[Pessoa]");

            try
            {
                using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), GetConexaoSql()))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            pessoa = new Pessoa();
                            if (!reader["Id"].Equals(DBNull.Value)) pessoa.Id = (Int32)reader["Id"];
                            if (!reader["BarragemId"].Equals(DBNull.Value)) pessoa.BarragemId = (Int32)reader["BarragemId"];
                            if (!reader["Nome"].Equals(DBNull.Value)) pessoa.Nome = (String)reader["Nome"];
                            if (!reader["Situacao"].Equals(DBNull.Value)) pessoa.Situacao = (bool)reader["Situacao"];
                            if (!reader["Email"].Equals(DBNull.Value)) pessoa.Email = (String)reader["Email"];
                            if (!reader["Celular"].Equals(DBNull.Value)) pessoa.Celular = (String)reader["Celular"];
                            if (!reader["SMS"].Equals(DBNull.Value)) pessoa.SMS = (String)reader["SMS"];
                            if (!reader["Whatsapp"].Equals(DBNull.Value)) pessoa.Whatsapp = (String)reader["Whatsapp"];
                            if (!reader["DataInclusao"].Equals(DBNull.Value)) pessoa.DataInclusao = (DateTime)reader["DataInclusao"];
                            if (!reader["DataAlteracao"].Equals(DBNull.Value)) pessoa.DataAlteracao = (DateTime?)reader["DataAlteracao"];

                            lPessoa.Add(pessoa);
                        }
                    }
                }

                return lPessoa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Pessoa ObterPorId(int id)
        {
            Pessoa pessoa = null;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM [dbo].[Pessoa] WHERE Id = @Id");

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
                            pessoa = new Pessoa();
                            if (!reader["Id"].Equals(DBNull.Value)) pessoa.Id = (Int32)reader["Id"];
                            if (!reader["BarragemId"].Equals(DBNull.Value)) pessoa.BarragemId = (Int32)reader["BarragemId"];
                            if (!reader["Nome"].Equals(DBNull.Value)) pessoa.Nome = (String)reader["Nome"];
                            if (!reader["Situacao"].Equals(DBNull.Value)) pessoa.Situacao = (bool)reader["Situacao"];
                            if (!reader["Email"].Equals(DBNull.Value)) pessoa.Email = (String)reader["Email"];
                            if (!reader["Celular"].Equals(DBNull.Value)) pessoa.Celular = (String)reader["Celular"];
                            if (!reader["SMS"].Equals(DBNull.Value)) pessoa.SMS = (String)reader["SMS"];
                            if (!reader["Whatsapp"].Equals(DBNull.Value)) pessoa.Whatsapp = (String)reader["Whatsapp"];
                            if (!reader["DataInclusao"].Equals(DBNull.Value)) pessoa.DataInclusao = (DateTime)reader["DataInclusao"];
                            if (!reader["DataAlteracao"].Equals(DBNull.Value)) pessoa.DataAlteracao = (DateTime?)reader["DataAlteracao"];
                        }
                    }
                }

                return pessoa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
