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
    public class UsuarioDAL : BaseSqlDAL
    {
        private readonly AppSettings _appSettings;
        public UsuarioDAL(AppSettings appSettings, ConexaoSqlServer con = null) : base(appSettings, con)
        {
            _appSettings = appSettings;
        }

        public void Inserir(Usuario usuario)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO [dbo].[Usuario]");
            sb.Append(" (RoleId, NomeCompleto, Email, NomeUsuario, Senha, Ativo, DataInclusao, DataAlteracao)");
            sb.Append(" VALUES");
            sb.Append(" (@RoleId, @NomeCompleto, @Email, @NomeUsuario, @Senha, @Ativo, @DataInclusao, @DataAlteracao);");
            sb.Append(" SELECT CAST(scope_identity() AS int)");

            try
            {
                using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), GetConexaoSql()))
                    {
                        cmd.Parameters.Add(new SqlParameter("@RoleId", usuario.RoleId));
                        cmd.Parameters.Add(new SqlParameter("@NomeCompleto", usuario.NomeCompleto ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Email", usuario.Email ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@NomeUsuario", usuario.NomeUsuario ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Senha", usuario.Senha ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Ativo", usuario.Ativo));
                        cmd.Parameters.Add(new SqlParameter("@DataInclusao", usuario.DataInclusao == null ? (object)DBNull.Value : usuario.DataInclusao));
                        cmd.Parameters.Add(new SqlParameter("@DataAlteracao", (object)DBNull.Value));

                        usuario.Id = (Int32)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(Usuario usuario)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE [dbo].[Usuario] SET");
            sb.Append(" RoleId = @RoleId, NomeCompleto = @NomeCompleto, Email = @Email, NomeUsuario = @NomeUsuario, Senha = @Senha, Ativo = @Ativo, DataAlteracao = @DataAlteracao");
            sb.Append(" WHERE Id = @Id");

            try
            {
                using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), GetConexaoSql()))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Id", usuario.Id));
                        cmd.Parameters.Add(new SqlParameter("@RoleId", usuario.RoleId));
                        cmd.Parameters.Add(new SqlParameter("@NomeCompleto", usuario.NomeCompleto ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Email", usuario.Email ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@NomeUsuario", usuario.NomeUsuario ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Senha", usuario.Senha ?? (object)DBNull.Value));
                        cmd.Parameters.Add(new SqlParameter("@Ativo", usuario.Ativo));
                        cmd.Parameters.Add(new SqlParameter("@DataAlteracao", usuario.DataAlteracao == null ? DateTime.Now : usuario.DataAlteracao));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> ObterLista()
        {
            List<Usuario> lUsuario = new List<Usuario>();
            Usuario usuario;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT u.*, r.Descricao");
            sb.Append(" FROM [TCC.PUC.SCA].[dbo].[Usuario] u");
            sb.Append(" INNER JOIN [TCC.PUC.SCA].[dbo].[Role] r ON u.RoleId = r.Id");

            try
            {
                using (conexaoSql ?? (conexaoSql = new ConexaoSqlServer(_appSettings)))
                {
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), GetConexaoSql()))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            usuario = new Usuario();
                            if (!reader["Id"].Equals(DBNull.Value)) usuario.Id = (Int32)reader["Id"];
                            if (!reader["RoleId"].Equals(DBNull.Value)) usuario.RoleId = (Int32)reader["RoleId"];
                            if (!reader["Descricao"].Equals(DBNull.Value)) usuario.Role = (String)reader["Descricao"];
                            if (!reader["NomeCompleto"].Equals(DBNull.Value)) usuario.NomeCompleto = (String)reader["NomeCompleto"];
                            if (!reader["Email"].Equals(DBNull.Value)) usuario.Email = (String)reader["Email"];
                            if (!reader["NomeUsuario"].Equals(DBNull.Value)) usuario.NomeUsuario = (String)reader["NomeUsuario"];
                            if (!reader["Senha"].Equals(DBNull.Value)) usuario.Senha = (String)reader["Senha"];
                            if (!reader["Ativo"].Equals(DBNull.Value)) usuario.Ativo = (bool)reader["Ativo"];
                            if (!reader["DataInclusao"].Equals(DBNull.Value)) usuario.DataInclusao = (DateTime)reader["DataInclusao"];
                            if (!reader["DataAlteracao"].Equals(DBNull.Value)) usuario.DataAlteracao = (DateTime?)reader["DataAlteracao"];

                            lUsuario.Add(usuario);
                        }
                    }
                }

                return lUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario ObterPorId(int id)
        {
            Usuario usuario = null;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM [dbo].[Usuario] WHERE Id = @Id");

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
                            usuario = new Usuario();
                            if (!reader["Id"].Equals(DBNull.Value)) usuario.Id = (Int32)reader["Id"];
                            if (!reader["RoleId"].Equals(DBNull.Value)) usuario.RoleId = (Int32)reader["RoleId"];
                            if (!reader["NomeCompleto"].Equals(DBNull.Value)) usuario.NomeCompleto = (String)reader["NomeCompleto"];
                            if (!reader["Email"].Equals(DBNull.Value)) usuario.Email = (String)reader["Email"];
                            if (!reader["NomeUsuario"].Equals(DBNull.Value)) usuario.NomeUsuario = (String)reader["NomeUsuario"];
                            if (!reader["Senha"].Equals(DBNull.Value)) usuario.Senha = (String)reader["Senha"];
                            if (!reader["Ativo"].Equals(DBNull.Value)) usuario.Ativo = (bool)reader["Ativo"];
                            if (!reader["DataInclusao"].Equals(DBNull.Value)) usuario.DataInclusao = (DateTime)reader["DataInclusao"];
                            if (!reader["DataAlteracao"].Equals(DBNull.Value)) usuario.DataAlteracao = (DateTime?)reader["DataAlteracao"];
                        }
                    }
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
