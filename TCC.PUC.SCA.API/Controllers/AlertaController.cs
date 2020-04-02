using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.PUC.SCA.Business;
using TCC.PUC.SCA.Business.Intefaces;
using TCC.PUC.SCA.Model.DBEntities;
using TCC.PUC.SCA.Model.SpecificEntities;
using TCC.PUC.SCA.Model.SpecificEntities.Restricted;

namespace TCC.PUC.SCA.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AlertaController : MainController
    {
        private readonly AppSettings _appSettings;

        public AlertaController(IOptions<AppSettings> appSettings, INotificador notificador) : base(appSettings, notificador)
        {
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        [Authorize(Roles = "APIAcesso")]
        [ProducesResponseType(typeof(List<Alerta>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<Alerta> Get()
        {
            try
            {
                return new EspecificoBLL(_appSettings).ObterListaAlerta();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        [HttpPut]
        [Authorize(Roles = "APIAcesso")]
        [ProducesResponseType(typeof(List<Alerta>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Put([FromBody]Incidente incidente)
        {
            try
            {
                new IncidenteBLL(_appSettings).Atualizar(incidente);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}