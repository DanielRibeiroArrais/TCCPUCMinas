using System;
using System.ComponentModel.DataAnnotations;

namespace TCC.PUC.SCA.Model.DBEntities
{
    public class Barragem
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(60)]
        public string Nome { get; set; }

        [Display(Name = "Latitude")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(50)]
        public string Latitude { get; set; }

        [Display(Name = "Longitude")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(50)]
        public string Longitude { get; set; }

        [Display(Name = "Situação")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public bool Situacao { get; set; }

        [Display(Name = "Data Inclusão")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data Alteração")]
        public DateTime? DataAlteracao { get; set; }

        public Barragem()
        {
        }
    }
}
