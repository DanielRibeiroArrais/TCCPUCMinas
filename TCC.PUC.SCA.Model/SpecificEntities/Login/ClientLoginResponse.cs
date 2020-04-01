using System;

namespace TCC.PUC.SCA.Model.SpecificEntities.Login
{
    public class ClientLoginResponse
    {
        public bool Authenticated { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string AccessToken { get; set; }
        public string Message { get; set; }

        public ClientLoginResponse()
        {
        }
    }
}
