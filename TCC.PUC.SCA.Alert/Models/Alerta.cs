using System.ComponentModel.DataAnnotations;

namespace TCC.PUC.SCA.Alert.Models
{
    public class Alerta
    {
        public int IncidenteId { get; set; }

        [Display(Name = "Plano Ação Mensagem")]
        public string PlanoAcaoMensagem { get; set; }

        [Display(Name = "Pessoa Nome")]
        public string PessoaNome { get; set; }

        [Display(Name = "Pessoa Email")]
        public string PessoaEmail { get; set; }

        [Display(Name = "Pessoa Celular")]
        public string PessoaCelular { get; set; }

        [Display(Name = "Pessoa SMS")]
        public string PessoaSMS { get; set; }

        [Display(Name = "Pessoa Whatsapp")]
        public string PessoaWhatsapp { get; set; }

        [Display(Name = "Barragem Nome")]
        public string BarragemNome { get; set; }

        public Alerta()
        {
        }
    }
}
