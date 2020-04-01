using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TCC.PUC.SCA.Model.SpecificEntities.Restricted;

namespace TCC.PUC.SCA.Front.Controllers
{
    [Authorize]
    public class IncidenteController : Controller
    {
        private readonly AppSettings _appSettings;

        public IncidenteController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new Business.IncidenteBLL(_appSettings).ObterDadosCompletoIncidentes());
        }
    }
}