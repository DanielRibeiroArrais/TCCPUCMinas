using System;
using System.ComponentModel.DataAnnotations;

namespace TCC.PUC.SCA.Model.DBEntities
{
    public class PlanoAcao
    {
        public int Id { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(50)]
        public string Tipo { get; set; }

        [Display(Name = "De")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int De { get; set; }

        [Display(Name = "Até")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int Ate { get; set; }

        [Display(Name = "Mensagem")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(150)]
        public string Mensagem { get; set; }

        [Display(Name = "Data Inclusão")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data Alteração")]
        public DateTime? DataAlteracao { get; set; }

        public PlanoAcao()
        {

        }
    }
}
