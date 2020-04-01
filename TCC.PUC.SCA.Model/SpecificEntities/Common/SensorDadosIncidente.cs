using TCC.PUC.SCA.Model.DBEntities;

namespace TCC.PUC.SCA.Model.SpecificEntities.Common
{
    public class SensorDadosIncidente
    {
        public SensorDados SensorDados { get; set; }
        public Incidente Incidente { get; set; }
        public SensorDadosIncidente()
        {


        }
    }
}
