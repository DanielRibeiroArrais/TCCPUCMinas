using System.Data.SqlClient;
using TCC.PUC.SCA.Data.Connection;
using TCC.PUC.SCA.Model.SpecificEntities.Restricted;

namespace TCC.PUC.SCA.Data.Common
{
    public class BaseSqlDAL
    {
        protected ConexaoSqlServer conexaoSql { get; set; }


        private readonly AppSettings _appSettings;

        public BaseSqlDAL(AppSettings appSettings, ConexaoSqlServer con = null)
        {
            _appSettings = appSettings;
            conexaoSql = con;
        }

        public SqlConnection GetConexaoSql()
        {
            return conexaoSql.ConexaoSql;
        }

    }
}