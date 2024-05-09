using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AM.UI.Web.Controllers
{
    public class PlaneController : Controller
    {
        IServicePlane sf;//etape 1

        public PlaneController(IServicePlane sf)//etape 1
        {
            this.sf = sf;
        }


        // GET: PlaneController
        public ActionResult Index()//tawa nheb njeneri view naamel click droit w naamel ajouter une vue RAZOR
        {
            return View(sf.GetMany());
        }

        // GET: PlaneController/Details/5
        public ActionResult Details(int id)
        {
            return View(sf.GetById(id));
        }

        // GET: PlaneController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlaneController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Plane collection)
        {
            try
            {
                sf.Add(collection);
                sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlaneController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlaneController/Edit/5
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

        // GET: PlaneController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlaneController/Delete/5
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
