using System;
using System.Collections.Generic;
using TCC.PUC.SCA.Data;
using TCC.PUC.SCA.Model.DBEntities;
using TCC.PUC.SCA.Model.SpecificEntities.Restricted;

namespace TCC.PUC.SCA.Business
{
    public class SensorBLL
    {
        private readonly AppSettings _appSettings;
        public SensorBLL(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public void Inserir(Sensor sensor)
        {
            try
            {
                new SensorDAL(_appSettings).Inserir(sensor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(Sensor sensor)
        {
            try
            {
                new SensorDAL(_appSettings).Atualizar(sensor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Sensor> ObterLista()
        {
            try
            {
                return new SensorDAL(_appSettings).ObterLista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Sensor ObterPorId(int id)
        {
            try
            {
                return new SensorDAL(_appSettings).ObterPorId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
