using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using TCC.PUC.SCA.Model.SpecificEntities.Restricted;

namespace TCC.PUC.SCA.Front.Controllers
{
    [Authorize]
    public class PessoaController : Controller
    {
        private readonly AppSettings _appSettings;

        public PessoaController(IOptions<AppSettings> appSettings)
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

            return View(new Business.PessoaBLL(_appSettings).ObterLista());
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
        public ActionResult Create(Model.DBEntities.Pessoa pessoa)
        {
            try
            {
                pessoa.Id = 0;
                pessoa.DataInclusao = DateTime.Now;
                pessoa.DataAlteracao = null;

                if (ModelState.IsValid)
                {
                    new Business.PessoaBLL(_appSettings).Inserir(pessoa);

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

            return View(new Business.PessoaBLL(_appSettings).ObterPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Model.DBEntities.Pessoa pessoa)
        {
            try
            {
                pessoa.DataAlteracao = DateTime.Now;

                if (ModelState.IsValid)
                {
                    new Business.PessoaBLL(_appSettings).Atualizar(pessoa);
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