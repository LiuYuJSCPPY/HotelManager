using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManager.Data;
using HotelManager.Services;
using Microsoft.AspNet.Identity.Owin;

namespace HotelManager.Web.Areas.Dashboard.Controllers
{
    public class RolesController : Controller
    {
        private HotelManagerSingInManager _signInManager;
        private HotelManagerUserManager _userManager;
        private HotelRoleManager _roleManager;
        private HotelManagerContext db = new HotelManagerContext();


        public RolesController()
        {
        }

        public RolesController(HotelManagerUserManager userManager, HotelManagerSingInManager signInManager, HotelRoleManager roleManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
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
        public HotelRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext()?.Get<HotelRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }





    }
}