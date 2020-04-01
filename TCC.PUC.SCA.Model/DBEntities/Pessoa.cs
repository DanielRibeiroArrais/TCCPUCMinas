using System;
using System.ComponentModel.DataAnnotations;

namespace TCC.PUC.SCA.Model.DBEntities
{
    public class Pessoa
    {
        public int Id { get; set; }

        [Display(Name = "Barragem")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int BarragemId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(60)]
        public string Nome { get; set; }

        [Display(Name = "Situação")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public bool Situacao { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(60)]
        public string Email { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(60)]
        public string Celular { get; set; }

        [Display(Name = "SMS")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(60)]
        public string SMS { get; set; }

        [Display(Name = "Whatsapp")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(60)]
        public string Whatsapp { get; set; }

        [Display(Name = "Data Inclusão")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data Alteração")]
        public DateTime? DataAlteracao { get; set; }

        public Pessoa()
        {

        }
    }
}
