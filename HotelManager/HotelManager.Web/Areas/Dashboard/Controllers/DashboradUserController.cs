using HotelManager.Services;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManager.Web.Areas.ViewModel;

namespace HotelManager.Web.Areas.Dashboard.Controllers
{
    public class DashboradUserController : Controller
    {
        private HotelManagerSingInManager _signInManager;
        private HotelManagerUserManager _userManager;
        private HotelRoleManager _hotelRoleManager;

        public DashboradUserController()
        {
        }

        public DashboradUserController(HotelManagerUserManager userManager, HotelManagerSingInManager signInManager, HotelRoleManager hotelRoleManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _hotelRoleManager = hotelRoleManager;
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

        public HotelRoleManager HotelRoleManager
        {
            get
            {
                return _hotelRoleManager ?? HttpContext.GetOwinContext().Get<HotelRoleManager>();
            }
            private set
            {
                _hotelRoleManager = value;
            }
        }
        // GET: Dashboard/DashboradUser
        public ActionResult Index()
        {
            var model = new UserViewModel();
            var ListUser = UserManager.Users.AsQueryable();

            model.hotelUsers = ListUser.ToList();

            return View(model);
        }
    }
}