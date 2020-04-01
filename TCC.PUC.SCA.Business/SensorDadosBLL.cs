using System;
using System.Collections.Generic;
using TCC.PUC.SCA.Data;
using TCC.PUC.SCA.Model.DBEntities;
using TCC.PUC.SCA.Model.SpecificEntities.Restricted;

namespace TCC.PUC.SCA.Business
{
    public class SensorDadosBLL
    {
        private readonly AppSettings _appSettings;
        public SensorDadosBLL(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public void Inserir(SensorDados sensorDados)
        {
            try
            {
                new SensorDadosDAL(_appSettings).Inserir(sensorDados);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SensorDados> ObterLista()
        {
            try
            {
                return new SensorDadosDAL(_appSettings).ObterLista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SensorDados ObterPorId(int id)
        {
            try
            {
                return new SensorDadosDAL(_appSettings).ObterPorId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SensorDados> ObterListaPorSensorId(int sensorId)
        {
            try
            {
                return new SensorDadosDAL(_appSettings).ObterListaPorSensorId(sensorId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
