using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManager.Model;
using HotelManager.Services;
using HotelManager.Web.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using HotelManager.Data;
using System.Data.Entity;


namespace HotelManager.Web.Controllers
{
    public class HotelController : Controller
    {
        private HotelManagerContext _db = new HotelManagerContext();
        private HotelService _hotelService = new HotelService();
        // GET: Hotel
        public ActionResult ListRoom()
        {
            GetAccomdationViewModel model = new GetAccomdationViewModel();

            model.accomdations = _db.Accomdations.Include(X => X.AccomdationPackage).ToList();
            return View(model);
        }
        public ActionResult Detail( )
        {
            return View();
        }
    }
}