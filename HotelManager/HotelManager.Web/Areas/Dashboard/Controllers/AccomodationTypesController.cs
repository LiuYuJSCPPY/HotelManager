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
    public class AccomodationTypesController : Controller
    {
        private HotelManagerContext db = new HotelManagerContext();
        private AccomodtaionTypeService _accomodtaionType = new AccomodtaionTypeService();

        // GET: Dashboard/AccomodationTypes
        public ActionResult Index()
        {
           
            AccomdationTypeViewModel accomdationTypeViewModel = new AccomdationTypeViewModel();
            accomdationTypeViewModel.accomodationTypes = _accomodtaionType.AllListAccomodationType();

            return View(accomdationTypeViewModel);
        }


       public ActionResult Action(int? Id)
        {
            AccomdationTypeActionModel Model = new AccomdationTypeActionModel();

            if (Id.HasValue)
            {
                var accomodationType = _accomodtaionType.GetAccomodationTypeById(Id.Value);
                Model.Id = accomodationType.Id;
                Model.Name = accomodationType.Name;
                Model.Description = accomodationType.Description;

            }


            return PartialView("_Action", Model);
        }


        [HttpPost]
        public JsonResult Action(AccomdationTypeActionModel model)
        {
            JsonResult json = new JsonResult();
            bool Result = false;

            if(model.Id > 0)
            {
                var AccomodationType = _accomodtaionType.GetAccomodationTypeById(model.Id);
                AccomodationType.Name = model.Name;
                AccomodationType.Description = model.Description;
                Result = _accomodtaionType.UpdateAccomodationType(AccomodationType);
            }
            else
            {
                AccomodationType SaveType = new AccomodationType();
                SaveType.Name = model.Name;
                SaveType.Description = model.Description;

                Result = _accomodtaionType.SaveAccomodationType(SaveType);
            }


            if (Result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Error" };
            }

            return json;
        }

        public ActionResult Delete(int Id)
        {
            AccomodationType model = new AccomodationType();
            var accomodationTypeId = _accomodtaionType.GetAccomodationTypeById(Id);
            model.Id = accomodationTypeId.Id;

            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete([Bind(Include = "Id,Name,Description")]AccomodationType accomodationType)
        {
            JsonResult json = new JsonResult();
            bool Result = false;

            AccomodationType DeleteAccomodationType = _accomodtaionType.GetAccomodationTypeById(accomodationType.Id);

            Result = _accomodtaionType.RemoveAccomdationType(DeleteAccomodationType.Id);

            if (Result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new {Success = false, Message = "Error" };
            }

            return json;

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
