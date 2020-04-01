using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using TCC.PUC.SCA.Model.SpecificEntities.Restricted;

namespace TCC.PUC.SCA.Front.Controllers
{
    [Authorize(Roles = "Engenheiros, Administrador")]
    public class SensorController : Controller
    {
        private readonly AppSettings _appSettings;

        public SensorController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            ViewBag.Barragens = new Business.BarragemBLL(_appSettings).ObterLista();

            return View(new Business.SensorBLL(_appSettings).ObterLista());
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Barragens = new Business.BarragemBLL(_appSettings).ObterLista();


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Model.DBEntities.Sensor sensor)
        {
            try
            {
                sensor.DataInclusao = DateTime.Now;
                sensor.DataAlteracao = null;

                if (ModelState.IsValid)
                {
                    new Business.SensorBLL(_appSettings).Inserir(sensor);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Create));
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Barragens = new Business.BarragemBLL(_appSettings).ObterLista();

            return View(new Business.SensorBLL(_appSettings).ObterPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Model.DBEntities.Sensor sensor)
        {
            try
            {
                sensor.DataAlteracao = DateTime.Now;

                if (ModelState.IsValid)
                {
                    new Business.SensorBLL(_appSettings).Atualizar(sensor);
                }
                else
                {

                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}