using HotelManager.Services;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManager.Web.Areas.ViewModel;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

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

        public ActionResult Action(string Id)
        {
            UserViewModel model = new UserViewModel();
            var User =  UserManager.FindById(Id);

            model.Id = User.Id;
            model.FullName = User.FullName;
            model.Address = User.Address;
            model.UserName = User.UserName;
            model.Country = User.Country;
            model.Email = User.Email;
            model.City = User.City;
            


            return PartialView("_Action",model);
        }

        [HttpPost]
        public JsonResult Action(string Id,UserViewModel model)
        {
            JsonResult json = new JsonResult();
            IdentityResult result = null;

            if (!string.IsNullOrEmpty(model.Id))
            {
                var user = UserManager.FindById(model.Id);
                user.FullName = model.FullName;
                user.Email = model.Email;
                user.City = model.City;
                user.Country = model.Country;
                user.Address = model.Address;
                user.UserName = model.UserName;

                result = UserManager.Update(user);

            }

            json.Data = new { Success = result.Succeeded, Message = string.Join(",", result.Errors) };

            return json;

        }

        public ActionResult Delete (string Id)
        {

            UserViewModel model = new UserViewModel();
            var user = UserManager.FindById(Id);
            model.Id = user.Id;
            model.UserName=user.UserName;

            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(UserViewModel model)
        {
            JsonResult json = new JsonResult();
            IdentityResult result = null;
            if (!string.IsNullOrEmpty(model.Id))
            {
                var user = UserManager.FindById(model.Id);
                result = UserManager.Delete(user);

                json.Data = new { Success = result.Succeeded, Message = string.Join(",", result.Errors) };
            }
            else
            {
                json.Data = new { Success = false, Message = "Invalud User" };
            }


            return json;
        }
    }
}