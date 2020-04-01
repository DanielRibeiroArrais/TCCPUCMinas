using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using TCC.PUC.SCA.Model.SpecificEntities.Restricted;

namespace TCC.PUC.SCA.Front.Controllers
{
    [Authorize(Roles = "Engenheiros, Administrador")]
    public class BarragemController : Controller
    {
        private readonly AppSettings _appSettings;

        public BarragemController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(new Business.BarragemBLL(_appSettings).ObterLista());
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Model.DBEntities.Barragem barragem)
        {
            try
            {
                barragem.Id = 0;
                barragem.DataInclusao = DateTime.Now;
                barragem.DataAlteracao = null;

                if (ModelState.IsValid)
                {
                    new Business.BarragemBLL(_appSettings).Inserir(barragem);

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
            return View(new Business.BarragemBLL(_appSettings).ObterPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Model.DBEntities.Barragem barragem)
        {
            try
            {
                barragem.DataAlteracao = DateTime.Now;

                if (ModelState.IsValid)
                {
                    new Business.BarragemBLL(_appSettings).Atualizar(barragem);
                }
                else
                {
                    //return View(company);
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
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}