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

namespace HotelManager.Web.Areas.Dashboard.Controllers
{
    public class AccomdationsController : Controller
    {
        private HotelManagerContext db = new HotelManagerContext();

        // GET: Dashboard/Accomdations
        public ActionResult Index()
        {
            var accomdations = db.Accomdations.Include(a => a.AccomdationPackage);
            return View(accomdations.ToList());
        }

        // GET: Dashboard/Accomdations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accomdation accomdation = db.Accomdations.Find(id);
            if (accomdation == null)
            {
                return HttpNotFound();
            }
            return View(accomdation);
        }

        // GET: Dashboard/Accomdations/Create
        public ActionResult Create()
        {
            ViewBag.AccomdationPackageId = new SelectList(db.AccomdationPackages, "Id", "Name");
            return View();
        }

        // POST: Dashboard/Accomdations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AccomdationPackageId,Name,Description")] Accomdation accomdation)
        {
            if (ModelState.IsValid)
            {
                db.Accomdations.Add(accomdation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccomdationPackageId = new SelectList(db.AccomdationPackages, "Id", "Name", accomdation.AccomdationPackageId);
            return View(accomdation);
        }

        // GET: Dashboard/Accomdations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accomdation accomdation = db.Accomdations.Find(id);
            if (accomdation == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccomdationPackageId = new SelectList(db.AccomdationPackages, "Id", "Name", accomdation.AccomdationPackageId);
            return View(accomdation);
        }

        // POST: Dashboard/Accomdations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AccomdationPackageId,Name,Description")] Accomdation accomdation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accomdation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccomdationPackageId = new SelectList(db.AccomdationPackages, "Id", "Name", accomdation.AccomdationPackageId);
            return View(accomdation);
        }

        // GET: Dashboard/Accomdations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accomdation accomdation = db.Accomdations.Find(id);
            if (accomdation == null)
            {
                return HttpNotFound();
            }
            return View(accomdation);
        }

        // POST: Dashboard/Accomdations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accomdation accomdation = db.Accomdations.Find(id);
            db.Accomdations.Remove(accomdation);
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
