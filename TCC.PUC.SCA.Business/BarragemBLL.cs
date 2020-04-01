using System;
using System.Collections.Generic;
using TCC.PUC.SCA.Data;
using TCC.PUC.SCA.Model.DBEntities;
using TCC.PUC.SCA.Model.SpecificEntities.Restricted;

namespace TCC.PUC.SCA.Business
{
    public class BarragemBLL
    {
        private readonly AppSettings _appSettings;
        public BarragemBLL(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public void Inserir(Barragem barragem)
        {
            try
            {
                new BarragemDAL(_appSettings).Inserir(barragem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(Barragem barragem)
        {
            try
            {
                new BarragemDAL(_appSettings).Atualizar(barragem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Barragem> ObterLista()
        {
            try
            {
                return new BarragemDAL(_appSettings).ObterLista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Barragem ObterPorId(int id)
        {
            try
            {
                return new BarragemDAL(_appSettings).ObterPorId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
