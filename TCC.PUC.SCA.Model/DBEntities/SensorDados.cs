using System;
using System.ComponentModel.DataAnnotations;

namespace TCC.PUC.SCA.Model.DBEntities
{
    public class SensorDados
    {
        public int Id { get; set; }

        [Display(Name = "Sensor")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int SensorId { get; set; }

        [Display(Name = "Intensidade")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int Intensidade { get; set; }

        [Display(Name = "Data Inclusão")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public DateTime DataInclusao { get; set; }

        public SensorDados()
        {

        }
    }
}
