using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.PUC.SCA.Model.SpecificEntities.Common
{
    public class InformacaoSensor
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(60)]
        public string Codigo { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(60)]
        public string Tipo { get; set; }

        [Display(Name = "Intensidade")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int Intensidade { get; set; }

        public InformacaoSensor()
        {

        }
    }
}
