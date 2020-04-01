using TCC.PUC.SCA.Model.DBEntities;

namespace TCC.PUC.SCA.Model.SpecificEntities.Common
{
    public class DadosCompletoIncidentes
    {
        public Incidente Incidente { get; set; }
        public PlanoAcao PlanoAcao { get; set; }
        public SensorDados SensorDados { get; set; }
        public Sensor Sensor { get; set; }
        public Barragem Barragem { get; set; }

        public DadosCompletoIncidentes()
        {
            Incidente = new Incidente();
            PlanoAcao = new PlanoAcao();
            SensorDados = new SensorDados();
            Sensor = new Sensor();
            Barragem = new Barragem();
        }
    }
}
