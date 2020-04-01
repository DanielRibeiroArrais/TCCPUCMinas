using System;
using System.Collections.Generic;
using TCC.PUC.SCA.Data;
using TCC.PUC.SCA.Model.DBEntities;
using TCC.PUC.SCA.Model.SpecificEntities.Restricted;

namespace TCC.PUC.SCA.Business
{
    public class PessoaBLL
    {
        private readonly AppSettings _appSettings;
        public PessoaBLL(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public void Inserir(Pessoa pessoa)
        {
            try
            {
                new PessoaDAL(_appSettings).Inserir(pessoa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(Pessoa pessoa)
        {
            try
            {
                new PessoaDAL(_appSettings).Atualizar(pessoa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Pessoa> ObterLista()
        {
            try
            {
                return new PessoaDAL(_appSettings).ObterLista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Pessoa ObterPorId(int id)
        {
            try
            {
                return new PessoaDAL(_appSettings).ObterPorId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
