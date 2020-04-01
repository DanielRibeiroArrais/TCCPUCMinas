using System;
using System.Collections.Generic;
using TCC.PUC.SCA.Data;
using TCC.PUC.SCA.Model.DBEntities;
using TCC.PUC.SCA.Model.SpecificEntities.Common;
using TCC.PUC.SCA.Model.SpecificEntities.Restricted;

namespace TCC.PUC.SCA.Business
{
    public class IncidenteBLL
    {
        private readonly AppSettings _appSettings;
        public IncidenteBLL(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public void Inserir(Incidente pessoa)
        {
            try
            {
                new IncidenteDAL(_appSettings).Inserir(pessoa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Incidente> ObterLista()
        {
            try
            {
                return new IncidenteDAL(_appSettings).ObterLista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Incidente ObterPorId(int id)
        {
            try
            {
                return new IncidenteDAL(_appSettings).ObterPorId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Incidente> ObterListaPorDataAlertaNull()
        {
            try
            {
                return new IncidenteDAL(_appSettings).ObterListaPorDataAlertaNull();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DadosCompletoIncidentes> ObterDadosCompletoIncidentes()
        {
            try
            {
                List<DadosCompletoIncidentes> lDadosCompletoIncidentes = new List<DadosCompletoIncidentes>();
                DadosCompletoIncidentes dadosCompletoIncidentes = null;

                List<Incidente> lIncidente = new IncidenteDAL(_appSettings).ObterLista();

                foreach (Incidente incidente in lIncidente)
                {
                    dadosCompletoIncidentes = new DadosCompletoIncidentes();
                    dadosCompletoIncidentes.Incidente = incidente;
                    dadosCompletoIncidentes.PlanoAcao = new PlanoAcaoDAL(_appSettings).ObterPorId(incidente.PlanoAcaoId);
                    dadosCompletoIncidentes.SensorDados = new SensorDadosDAL(_appSettings).ObterPorId(incidente.SensorDadosId);
                    dadosCompletoIncidentes.Sensor = new SensorDAL(_appSettings).ObterPorId(dadosCompletoIncidentes.SensorDados.SensorId);
                    dadosCompletoIncidentes.Barragem = new BarragemDAL(_appSettings).ObterPorId(dadosCompletoIncidentes.Sensor.BarragemId);

                    lDadosCompletoIncidentes.Add(dadosCompletoIncidentes);
                }

                return lDadosCompletoIncidentes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
