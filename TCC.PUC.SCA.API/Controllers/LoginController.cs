using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using TCC.PUC.SCA.Business;
using TCC.PUC.SCA.Business.Intefaces;
using TCC.PUC.SCA.Model.SpecificEntities.Login;
using TCC.PUC.SCA.Model.SpecificEntities.Restricted;

namespace TCC.PUC.SCA.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class LoginController : MainController
    {
        private readonly AppSettings _appSettings;

        public LoginController(IOptions<AppSettings> appSettings, INotificador notificador) : base(appSettings, notificador)
        {
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ClientLoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ClientLoginResponse Autenticar([FromBody]ClientLoginRequest clientLoginRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return new ClienteLoginBLL(_appSettings).AuthenticationRequest(clientLoginRequest);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                ReportError(ex.Message);
                //return CustomResponse();
                return null;
            }
        }
    }
}