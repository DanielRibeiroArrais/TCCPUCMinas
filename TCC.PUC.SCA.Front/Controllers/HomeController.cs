using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TCC.PUC.SCA.Business;
using TCC.PUC.SCA.Front.Models;
using TCC.PUC.SCA.Model.DBEntities;
using TCC.PUC.SCA.Model.SpecificEntities.Common;
using TCC.PUC.SCA.Model.SpecificEntities.Restricted;

namespace TCC.PUC.SCA.Front.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppSettings _appSettings;

        public HomeController(IOptions<AppSettings> appSettings, IHttpContextAccessor httpContextAccessor)
        {
            _appSettings = appSettings.Value;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            List<Barragem> todasBarragens = new Business.BarragemBLL(_appSettings).ObterLista();
            List<Sensor> todosSensores = new Business.SensorBLL(_appSettings).ObterLista();
            List<SensorDados> todosSensoresDados = new Business.SensorDadosBLL(_appSettings).ObterLista();

            List<Map> maps = new List<Map>();
            Map map = null;

            if (todasBarragens.Count > 0)
            {
                foreach (Barragem barragem in todasBarragens)
                {
                    map = new Map();
                    map.Id = barragem.Id;
                    map.Nome = barragem.Nome;
                    map.Longitude = Convert.ToDouble(barragem.Longitude.Replace('.', ','));
                    map.Latitude = Convert.ToDouble(barragem.Latitude.Replace('.', ','));

                    var resultantList = from item1 in todosSensores
                                        join item2 in todosSensoresDados
                                        on item1.Id equals item2.SensorId
                                        where item1.BarragemId == barragem.Id
                                        select item2;

                    map.Tipo = todosSensores.Where(x => x.Id.Equals(barragem.Id)).FirstOrDefault().Tipo;
                    map.Intensidade = resultantList.ToList().Count == 0 ? 0 : todosSensoresDados.Where(x => x.Id.Equals(resultantList.Max(y => y.Id))).FirstOrDefault().Intensidade;

                    map.Status = VerificarStatus(map.Tipo, map.Intensidade);

                    maps.Add(map);
                }
            }

            return View(maps);
        }

        private string VerificarStatus(string tipo, int intensidade)
        {

            if (tipo.Equals("Tremor", StringComparison.OrdinalIgnoreCase))
            {
                return SensorTremor(intensidade);
            }
            else if (tipo.Equals("Ruido", StringComparison.OrdinalIgnoreCase))
            {
                return SensorRuido(intensidade);
            }
            else
            {
                return "Normal";
            }
        }

        private string SensorTremor(int intensidade)
        {
            if (intensidade >= 10 && intensidade <= 30)
            {
                return "Alerta";
            }
            else if (intensidade >= 31 && intensidade <= 60)
            {
                return "Perigo";
            }
            else if (intensidade >= 61)
            {
                return "Evacuação";
            }
            else
            {
                return "Normal";
            }
        }

        private string SensorRuido(int intensidade)
        {
            if (intensidade >= 71 && intensidade <= 80)
            {
                return "Alerta";
            }
            else if (intensidade >= 81 && intensidade <= 90)
            {
                return "Perigo";
            }
            else if (intensidade >= 91)
            {
                return "Evacuação";
            }
            else
            {
                return "Normal";
            }
        }

        public IActionResult Principal()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login(string returnUrl = null, string msgLogin = null)
        {
            TempData["returnUrl"] = returnUrl;
            ViewData["msgErroLogin"] = msgLogin;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario, string returnUrl = null)
        {
            try
            {
                if (string.IsNullOrEmpty(usuario.NomeUsuario) && string.IsNullOrEmpty(usuario.Senha))
                {
                    return RedirectToAction(nameof(HomeController.Login), "Home", new { returnUrl = "", msgLogin = "Usuário/Senha não pode ser nulo!" });
                }

                usuario = new UsuarioBLL(_appSettings).ObterLista()
                    .Where(x => x.NomeUsuario.Equals(usuario.NomeUsuario) && x.Senha.Equals(usuario.Senha)).FirstOrDefault();

                if (usuario != null && usuario.Id > 0)
                {
                    var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.NameIdentifier, usuario.NomeCompleto),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Name, usuario.NomeUsuario),
                    new Claim(ClaimTypes.Role, usuario.Role)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction(nameof(PrincipalController.Index), "Principal");
                }

                return RedirectToAction(nameof(HomeController.Login), "Home", new { returnUrl = "", msgLogin = "Usuário/Senha incorreto!" });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult LogoutForce()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(HomeController.Login), "Home");
        }

        public IActionResult AcessoNegado()
        {
            return View();
        }
    }
}
