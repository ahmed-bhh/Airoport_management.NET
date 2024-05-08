﻿using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;

namespace AM.UI.Web.Controllers
{
    public class FlightController : Controller
    {
        //hedhom zouz mchina hatinehom fil program.cs
        //static AMContext ctx=new AMContext();
        // static IUnitOfWork uow=new UnitOfWork(ctx);


        // IserviceFlight sf=new ServiceFlight(uow);
        IserviceFlight sf;
        IServicePlane sp;//hachti beha l liste deroulente fil create

        public FlightController(IserviceFlight sf, IServicePlane sp)
        {
            this.sf = sf;
            this.sp = sp;
        }

        // GET: FlightController
        public ActionResult Index(DateTime? dateDepart)//wkeft houni seance 9 kamaltha
        {
            if (dateDepart == null)
                return View(sf.GetMany());
            else
                return View(sf.GetMany(f=>f.FlightDate==dateDepart));
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
             ViewBag.listPlanes = new SelectList(sp.GetMany(), "PlaneId", "Information");//nafs el hkeya ama aamlt propriete fil domaine plane esmha information
            // ViewBag.listPlanes = new SelectList(sp.GetMany(), "PlaneId", "ManufactureDate");//houni aaamlt liste w bech nabaathha lil create.cshtml bech nselecti chneya el plane par date de depart
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight collection)//kent fama IFormCollection nbadalha b Flight
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

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlightController/Edit/5
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

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightController/Delete/5
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
