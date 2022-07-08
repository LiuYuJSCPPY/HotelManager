using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelManager.Data;
using HotelManager.Model;
using HotelManager.Services;
using HotelManager.Web.Areas.ViewModel;

namespace HotelManager.Web.Areas.Dashboard.Controllers
{
    public class AccomdationPackagesController : Controller
    {
        private HotelManagerContext db = new HotelManagerContext();
        private AccomdationPackageService _accomdationPackage = new AccomdationPackageService();
        // GET: Dashboard/AccomdationPackages
        public ActionResult Index()
        {
            AccomdationPackageViewModel ListAllAccomdationPackage = new AccomdationPackageViewModel();
            ListAllAccomdationPackage.accomdationPackages = _accomdationPackage.ToListAccomdationPackages();
            return View(ListAllAccomdationPackage);
        }

        public ActionResult Action()
        {


            return PartialView("_Action");
        }

        // GET: Dashboard/AccomdationPackages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccomdationPackage accomdationPackage = db.AccomdationPackages.Find(id);
            if (accomdationPackage == null)
            {
                return HttpNotFound();
            }
            return View(accomdationPackage);
        }

        // GET: Dashboard/AccomdationPackages/Create
        public ActionResult Create()
        {
            ViewBag.AccomodationTypeId = new SelectList(db.AccomodationTypes, "Id", "Name");
            return View();
        }

        // POST: Dashboard/AccomdationPackages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AccomodationTypeId,Name,NoOfRoom,PericeNigeth")] AccomdationPackage accomdationPackage)
        {
            if (ModelState.IsValid)
            {
                db.AccomdationPackages.Add(accomdationPackage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccomodationTypeId = new SelectList(db.AccomodationTypes, "Id", "Name", accomdationPackage.AccomodationTypeId);
            return View(accomdationPackage);
        }

        // GET: Dashboard/AccomdationPackages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccomdationPackage accomdationPackage = db.AccomdationPackages.Find(id);
            if (accomdationPackage == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccomodationTypeId = new SelectList(db.AccomodationTypes, "Id", "Name", accomdationPackage.AccomodationTypeId);
            return View(accomdationPackage);
        }

        // POST: Dashboard/AccomdationPackages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AccomodationTypeId,Name,NoOfRoom,PericeNigeth")] AccomdationPackage accomdationPackage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accomdationPackage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccomodationTypeId = new SelectList(db.AccomodationTypes, "Id", "Name", accomdationPackage.AccomodationTypeId);
            return View(accomdationPackage);
        }

        // GET: Dashboard/AccomdationPackages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccomdationPackage accomdationPackage = db.AccomdationPackages.Find(id);
            if (accomdationPackage == null)
            {
                return HttpNotFound();
            }
            return View(accomdationPackage);
        }

        // POST: Dashboard/AccomdationPackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccomdationPackage accomdationPackage = db.AccomdationPackages.Find(id);
            db.AccomdationPackages.Remove(accomdationPackage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
