using HotelManager.Services;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManager.Web.Areas.ViewModel;
using System.Threading.Tasks;

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
            var model = new AllUserToListViewModel();
            var ListUser =  UserManager.Users.AsQueryable();

            model.hotelUsers = ListUser.ToList();

            return View(model);
        }

        public async Task<ActionResult> Action(string Id)
        {
            UserViewModel model = new UserViewModel();
            var User = await UserManager.FindByIdAsync(Id);

            model.Id = User.Id;
            model.FullName = User.FullName;
            model.Address = User.Address;
            model.UserName = User.UserName;
            model.Country = User.Country;
            model.Email = User.Email;
            model.City = User.City;
            


            return  PartialView("_Action",model);
        }
    }
}