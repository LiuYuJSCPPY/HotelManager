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
using Microsoft.AspNet.Identity.Owin;

namespace HotelManager.Web.Areas.Dashboard.Controllers
{
    public class HotelUsersController : Controller
    {
        private HotelManagerSingInManager _signInManager;
        private HotelManagerUserManager _userManager;
        private HotelManagerContext db = new HotelManagerContext();


        public HotelUsersController()
        {
        }

        public HotelUsersController(HotelManagerUserManager userManager, HotelManagerSingInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public HotelManagerSingInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<HotelManagerSingInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public HotelManagerUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<HotelManagerUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

      

        // GET: Dashboard/HotelUsers
        public ActionResult Index()
        {
            return View(db.HotelUsers.ToList());
        }

        // GET: Dashboard/HotelUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelUser hotelUser = db.HotelUsers.Find(id);
            if (hotelUser == null)
            {
                return HttpNotFound();
            }
            return View(hotelUser);
        }

        // GET: Dashboard/HotelUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/HotelUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullName,Country,City,Address,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] HotelUser hotelUser)
        {
            if (ModelState.IsValid)
            {
                db.HotelUsers.Add(hotelUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotelUser);
        }

        // GET: Dashboard/HotelUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelUser hotelUser = db.HotelUsers.Find(id);
            if (hotelUser == null)
            {
                return HttpNotFound();
            }
            return View(hotelUser);
        }

        // POST: Dashboard/HotelUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,Country,City,Address,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] HotelUser hotelUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotelUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotelUser);
        }

        // GET: Dashboard/HotelUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelUser hotelUser = db.HotelUsers.Find(id);
            if (hotelUser == null)
            {
                return HttpNotFound();
            }
            return View(hotelUser);
        }

        // POST: Dashboard/HotelUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HotelUser hotelUser = db.HotelUsers.Find(id);
            db.HotelUsers.Remove(hotelUser);
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
