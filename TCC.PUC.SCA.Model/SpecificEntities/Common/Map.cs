using System.ComponentModel.DataAnnotations;

namespace TCC.PUC.SCA.Model.SpecificEntities.Common
{
    public class Map
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(60)]
        public string Nome { get; set; }

        [Display(Name = "Latitude")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public double Latitude { get; set; }

        [Display(Name = "Longitude")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public double Longitude { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(50)]
        public string Tipo { get; set; }

        [Display(Name = "Intensidade")]
        public int Intensidade { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        public Map()
        {
        }
    }
}
