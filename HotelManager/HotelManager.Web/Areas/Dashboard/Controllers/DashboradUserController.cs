using HotelManager.Services;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManager.Web.Areas.Dashboard.Controllers
{
    public class DashboradUserController : Controller
    {
        private HotelManagerSingInManager _signInManager;
        private HotelManagerUserManager _userManager;

        public DashboradUserController()
        {
        }

        public DashboradUserController(HotelManagerUserManager userManager, HotelManagerSingInManager signInManager)
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
        // GET: Dashboard/DashboradUser
        public ActionResult Index()
        {
            var user = UserManager.Users.AsQueryable();
            return View();
        }
    }
}