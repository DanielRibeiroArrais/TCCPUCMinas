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
using TCC.PUC.SCA.Model.SpecificEntities.Restricted;

namespace TCC.PUC.SCA.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BarragemController : MainController
    {
        private readonly AppSettings _appSettings;

        public BarragemController(IOptions<AppSettings> appSettings, INotificador notificador) : base(appSettings, notificador)
        {
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        [Authorize(Roles = "APIAcesso")]
        [ProducesResponseType(typeof(List<Barragem>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<Barragem> Get()
        {
            try
            {
                return new BarragemBLL(_appSettings).ObterLista();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Autenticar([FromBody]Barragem barragem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    new BarragemBLL(_appSettings).Inserir(barragem);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                ReportError(ex.Message);
            }
        }
    }
}