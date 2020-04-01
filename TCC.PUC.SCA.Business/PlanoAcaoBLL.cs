using System;
using System.Collections.Generic;
using TCC.PUC.SCA.Data;
using TCC.PUC.SCA.Model.DBEntities;
using TCC.PUC.SCA.Model.SpecificEntities.Restricted;

namespace TCC.PUC.SCA.Business
{
    public class PlanoAcaoBLL
    {
        private readonly AppSettings _appSettings;
        public PlanoAcaoBLL(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public void Inserir(PlanoAcao planoAcao)
        {
            try
            {
                new PlanoAcaoDAL(_appSettings).Inserir(planoAcao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(PlanoAcao planoAcao)
        {
            try
            {
                new PlanoAcaoDAL(_appSettings).Atualizar(planoAcao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PlanoAcao> ObterLista()
        {
            try
            {
                return new PlanoAcaoDAL(_appSettings).ObterLista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PlanoAcao ObterPorId(int id)
        {
            try
            {
                return new PlanoAcaoDAL(_appSettings).ObterPorId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
