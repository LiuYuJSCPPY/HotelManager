using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
    public class AccomdationPackagesController : Controller
    {
        private HotelManagerContext _db = new HotelManagerContext();
        private AccomdationPackageService _accomdationPackage = new AccomdationPackageService();
        // GET: Dashboard/AccomdationPackages
        public ActionResult Index()
        {
            AccomdationPackageListViewModel ListAllAccomdationPackage = new AccomdationPackageListViewModel();
            ListAllAccomdationPackage.accomdationPackages = _accomdationPackage.ToListAccomdationPackages();
            return View(ListAllAccomdationPackage);
        }

        public ActionResult Action(int? Id)
        {
            FormAccomdationPackageViewModel model = new FormAccomdationPackageViewModel();

            if (Id.HasValue)
            {
                var EditAccomodationPackage = _accomdationPackage.GetAccomdationPackageById(Id.Value);
                model.Id = EditAccomodationPackage.Id;
                model.Name = EditAccomodationPackage.Name;
                model.AccomodationTypeId = EditAccomodationPackage.AccomodationTypeId;
                model.NoOfRoom = EditAccomodationPackage.NoOfRoom;
                model.PericeNigeth = EditAccomodationPackage.PericeNigeth;
            }
            model.AccomodationType = _db.AccomodationTypes.Select(AccomodationType => new SelectListItem
            {
                Text = AccomodationType.Name,
                Value = AccomodationType.Id.ToString(),
            }).ToList();

            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action([Bind(Include = "Id,Name,AccomodationTypeId,NoOfRoom,PericeNigeth")]AccomdationPackage accomdationPackage, HttpPostedFileBase[] Files)
        {
            JsonResult json = new JsonResult();
            bool Result = false;

            if(accomdationPackage.Id > 0)
            {
                Result = _accomdationPackage.UpdateAccomdationPackage(accomdationPackage);
            }else if(Files != null && _accomdationPackage.SaveAccomdationPackage(accomdationPackage))
            {
               
                Result = SaveImage(accomdationPackage.Name, accomdationPackage.Id, Files);

            }else
            {
                Result = _accomdationPackage.SaveAccomdationPackage(accomdationPackage);
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

            AccomdationPackage DeleteaccomdationPackage = _accomdationPackage.GetAccomdationPackageById(Id);

            return PartialView("_Delete",DeleteaccomdationPackage);
        }

        [HttpPost]
        public JsonResult Delete([Bind(Include ="Id")]AccomdationPackage accomdationPackage )
        {
            JsonResult json = new JsonResult();
            bool Result = false;
            var findPackage = _db.AccomdationPackagePictures.Where(x => x.AccomdationPackageId == accomdationPackage.Id).ToList();
            if (findPackage != null)
            {
                DeleteImage(accomdationPackage.Id);
            }
            Result = _accomdationPackage.DeleteAccomdationPackage(accomdationPackage.Id);
            if (Result)
            {
                json.Data = new { Success = true };

            }
            else
            {
                json.Data = new { Success = true, Message = "Error" };
            }

            return json;
        }

        private bool DeleteImage(int Id)
        {
            List<AccomdationPackagePicture> accomdationPackagePictures = _db.AccomdationPackagePictures.Where(x => x.AccomdationPackageId == Id).ToList();

            foreach(AccomdationPackagePicture DeleteImage in accomdationPackagePictures)
            {
                string DeleteImagePage = Request.MapPath(DeleteImage.URL.ToString());
                if (System.IO.File.Exists(DeleteImagePage))
                {
                    System.IO.File.Delete(DeleteImagePage);
                }
                _db.AccomdationPackagePictures.Remove(DeleteImage);
               
            }

            return _db.SaveChanges() > 0;
        }

        private bool SaveImage(string AccPackname,int Id, HttpPostedFileBase[] Files)
        {

            string SavePath = Server.MapPath("~/Areas/Image/AccomdationPackage/");
            AccomdationPackagePicture accomdationPackagePicture = new AccomdationPackagePicture();
            var accomdationPackageName = _db.AccomdationPackages.Where(x => x.Id == Id).First();

            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }


            foreach (HttpPostedFileBase File in Files)
            {
                string FileName = File.FileName;
                string _FileName = $"{Guid.NewGuid()}{FileName}{DateTime.Now.ToString("yyyymmssfff")}";
                string extension = Path.GetExtension(File.FileName);
                string path = Path.Combine(SavePath, _FileName);
                accomdationPackagePicture.AccomdationPackageId = accomdationPackageName.Id;
                accomdationPackagePicture.URL = "~/Areas/Image/AccomdationPackage/" + _FileName;
                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jepg" || extension.ToLower() == ".png")
                {
                    _db.AccomdationPackagePictures.Add(accomdationPackagePicture);
                    if (_db.SaveChanges() > 0)
                    {
                        File.SaveAs(path);
                    }

                }

            }


            return false;
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
