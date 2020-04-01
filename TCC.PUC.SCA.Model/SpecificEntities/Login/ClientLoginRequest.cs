using System.ComponentModel.DataAnnotations;

namespace TCC.PUC.SCA.Model.SpecificEntities.Login
{
    public class ClientLoginRequest
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Senha { get; set; }

        public ClientLoginRequest()
        {
        }
    }
}
