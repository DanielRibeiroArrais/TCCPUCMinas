using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TCC.PUC.SCA.Model.SpecificEntities.Restricted;

namespace TCC.PUC.SCA.Front.Controllers
{
    [Authorize]
    public class PrincipalController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppSettings _appSettings;

        public PrincipalController(IOptions<AppSettings> appSettings, IHttpContextAccessor httpContextAccessor)
        {
            _appSettings = appSettings.Value;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}