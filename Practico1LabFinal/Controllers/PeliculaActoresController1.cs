using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practico1LabFinal.Controllers
{
    public class PeliculaActoresController1 : Controller
    {
        // GET: PeliculaActoresController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: PeliculaActoresController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PeliculaActoresController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeliculaActoresController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: PeliculaActoresController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PeliculaActoresController1/Edit/5
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

        // GET: PeliculaActoresController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PeliculaActoresController1/Delete/5
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
