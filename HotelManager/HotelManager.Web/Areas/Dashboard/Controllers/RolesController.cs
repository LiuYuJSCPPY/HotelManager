using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManager.Data;
using HotelManager.Services;
using Microsoft.AspNet.Identity.Owin;
using HotelManager.Web.Areas.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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

        public ActionResult Index()
        {
            RoleListingModel roleListingModel = new RoleListingModel();
            var ListRole = RoleManager.Roles.AsQueryable();
            roleListingModel.roles = ListRole.ToList();

            return View(roleListingModel);
        }

        public ActionResult Action(string Id)
        {
            RoelViewModel model = new RoelViewModel();
          

            if (!string.IsNullOrEmpty(Id))
            {
                var rolea = RoleManager.FindById(Id);
                model.Id = rolea.Id;
                model.name = rolea.Name;
            }

            return PartialView("_Action", model);
        }


        [HttpPost]
        public JsonResult Action(RoelViewModel model)
        {
            JsonResult json = new JsonResult();
            IdentityResult Result = null;

            if (!string.IsNullOrEmpty(model.Id))
            {
                IdentityRole role = RoleManager.FindById(model.Id);
                role.Name = model.name;

                Result = RoleManager.Update(role);
            }
            else
            {
                var role = new IdentityRole();
                role.Name = model.name;
                Result = RoleManager.Create(role);
            }

            json.Data = new { Success = Result.Succeeded, Message = $"{Result.Errors}" };

            return json;

                
        }

        public ActionResult Delete(string Id)
        {
            RoelViewModel model = new RoelViewModel();

            var role = RoleManager.FindById(Id);
            if (!string.IsNullOrEmpty(role.Id))
            {
                model.Id = role.Id;
                model.name = role.Name;
            }


            return PartialView("_Delete", model);
        }


        [HttpPost]
        public JsonResult Delete(RoelViewModel model)
        {
            JsonResult json = new JsonResult();
            IdentityResult Result = null;

            if (!string.IsNullOrEmpty(model.Id))
            {
                var role = RoleManager.FindById(model.Id);
                Result = RoleManager.Delete(role);

                json.Data = new { Success = Result.Succeeded, Message = $"{Result.Errors}" };
            }
            else
            {
                json.Data = new { Success = Result.Succeeded, Message = $"{Result.Errors}" };


            }

            return json;
        }


    }
}