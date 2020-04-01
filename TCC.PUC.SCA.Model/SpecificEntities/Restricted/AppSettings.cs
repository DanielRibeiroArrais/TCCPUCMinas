namespace TCC.PUC.SCA.Model.SpecificEntities.Restricted
{
    public class AppSettings
    {
        public AppSettings()
        {
        }

        public string Secret { get; set; }
        public int ExpirationHours { get; set; }
        public string Emitter { get; set; }
        public string ValidOn { get; set; }
        public string DefaultConnectionSQLServer { get; set; }
        public string DefaultConnectionOracle { get; set; }
        public string MensageriaUserName { get; set; }
        public string MensageriaPassword { get; set; }
        public string MensageriaHostName { get; set; }
    }
}
