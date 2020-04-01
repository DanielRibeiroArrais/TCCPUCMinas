using System;
using System.ComponentModel.DataAnnotations;

namespace TCC.PUC.SCA.Model.DBEntities
{
    public class Sensor
    {
        public int Id { get; set; }

        [Display(Name = "Barragem")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int BarragemId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(50)]
        public string Nome { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(50)]
        public string Codigo { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(50)]
        public string Tipo { get; set; }

        [Display(Name = "Situação")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public bool Situacao { get; set; }

        [Display(Name = "Data Inclusão")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data Alteração")]
        public DateTime? DataAlteracao { get; set; }

        public Sensor()
        {

        }
    }
}
