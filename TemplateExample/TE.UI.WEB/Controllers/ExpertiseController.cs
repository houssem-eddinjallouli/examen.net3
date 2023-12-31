using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TE.Core.Domain;
using TE.Core.Services;

namespace TE.UI.WEB.Controllers
{
    public class ExpertiseController : Controller
    {
        readonly IService<Expertise> serrviceexpert;
        public ExpertiseController(IService<Expertise> serrviceexpert)
        {
            this.serrviceexpert = serrviceexpert;
        }

        // GET: ExpertiseController
        public ActionResult Index(string filter)
        {
            if (!string.IsNullOrEmpty(filter))
                return View(serrviceexpert.GetAll()
                    .Where(f => f.MySinistre.MyAssurance.Type.ToString() == filter));
          
            return View(serrviceexpert.GetAll().OrderBy(g=>g.DateExpertise));
        }

        // GET: ExpertiseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExpertiseController/Create
        public ActionResult Create()
        {
            var houssem = serrviceexpert.GetAll();
            ViewBag.ee = new SelectList(houssem, "ExpertFK", "MyExpert.Nom");
            ViewBag.ss = new SelectList(houssem, "SinistreFK", "SinistreFK");
            return View();
        }

        // POST: ExpertiseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection,Expertise hh)
        {
            try
            {
                serrviceexpert.Add(hh);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExpertiseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExpertiseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ExpertiseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExpertiseController/Delete/5
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
