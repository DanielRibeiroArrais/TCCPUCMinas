using System;
using System.Collections.Generic;
using TCC.PUC.SCA.Data;
using TCC.PUC.SCA.Model.DBEntities;
using TCC.PUC.SCA.Model.SpecificEntities.Common;
using TCC.PUC.SCA.Model.SpecificEntities.Restricted;

namespace TCC.PUC.SCA.Business
{
    public class EspecificoBLL
    {
        private readonly AppSettings _appSettings;
        public EspecificoBLL(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public void InserirSensorDadosIncidente(SensorDadosIncidente sensorDadosIncidente)
        {
            try
            {
                new EspecificoDAL(_appSettings).InserirSensorDadosIncidente(sensorDadosIncidente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Alerta> ObterListaAlerta()
        {
            try
            {
                return new EspecificoDAL(_appSettings).ObterListaAlerta();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
