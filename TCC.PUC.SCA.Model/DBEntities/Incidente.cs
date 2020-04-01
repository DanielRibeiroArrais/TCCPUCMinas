using System;
using System.ComponentModel.DataAnnotations;

namespace TCC.PUC.SCA.Model.DBEntities
{
    public class Incidente
    {
        public int Id { get; set; }

        [Display(Name = "Barragem")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int SensorDadosId { get; set; }

        [Display(Name = "Plano de Ação")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int PlanoAcaoId { get; set; }

        [Display(Name = "Data Inclusão")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data Alerta")]
        public DateTime? DataAlerta { get; set; }

        public Incidente()
        {

        }
    }
}
