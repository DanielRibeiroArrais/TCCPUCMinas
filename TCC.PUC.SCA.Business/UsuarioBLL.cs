using System;
using System.Collections.Generic;
using TCC.PUC.SCA.Data;
using TCC.PUC.SCA.Model.DBEntities;
using TCC.PUC.SCA.Model.SpecificEntities.Restricted;

namespace TCC.PUC.SCA.Business
{
    public class UsuarioBLL
    {
        private readonly AppSettings _appSettings;
        public UsuarioBLL(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public void Inserir(Usuario sensorDados)
        {
            try
            {
                new UsuarioDAL(_appSettings).Inserir(sensorDados);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> ObterLista()
        {
            try
            {
                return new UsuarioDAL(_appSettings).ObterLista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario ObterPorId(int id)
        {
            try
            {
                return new UsuarioDAL(_appSettings).ObterPorId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
