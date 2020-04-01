using System;

namespace TCC.PUC.SCA.Alert.Models
{
    public class ClientLoginResponse
    {
        public bool success { get; set; }
        public Data data { get; set; }

        public ClientLoginResponse()
        {
            data = new Data();
        }
    }

    public class Data
    {
        public bool Authenticated { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string AccessToken { get; set; }
        public string Message { get; set; }
    }
}
