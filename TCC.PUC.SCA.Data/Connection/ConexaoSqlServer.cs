using System;
using System.Data.SqlClient;
using TCC.PUC.SCA.Model.SpecificEntities.Restricted;

namespace TCC.PUC.SCA.Data.Connection
{
    public class ConexaoSqlServer : IDisposable
    {
        public SqlConnection ConexaoSql { get; internal set; }
        private SqlTransaction transacao;
        private bool Finalized;
        private bool Commited;

        public ConexaoSqlServer(AppSettings appSettings)
        {
            Finalized = false;
            Commited = false;
            string connectionString = appSettings.DefaultConnectionSQLServer;
            ConexaoSql = new SqlConnection();
            ConexaoSql.ConnectionString = connectionString;
            ConexaoSql.Open();
        }

        public void Dispose()
        {
            if (!Finalized)
            {
                Finalized = true;
                if (!Commited)
                    Rollback();
                ConexaoSql.Close();
                ConexaoSql.Dispose();
            }
        }

        ~ConexaoSqlServer()
        {
            Dispose();
        }

        public void BeginTransaction(System.Data.IsolationLevel level = System.Data.IsolationLevel.ReadCommitted)
        {
            transacao = ConexaoSql.BeginTransaction(level);
        }

        public void Commit()
        {
            if (transacao != null)
            {
                transacao.Commit();
                transacao = null;
            }
            Commited = true;
        }

        public void Rollback()
        {
            if (transacao != null)
            {
                transacao.Rollback();
                transacao = null;
            }
        }
    }
}