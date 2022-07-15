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
using System.IO;
using System.Text;

namespace HotelManager.Web.Areas.Dashboard.Controllers
{
    public class AccomdationsController : Controller
    {
        private HotelManagerContext _db = new HotelManagerContext();
        private AccomdationsService _Accomdation = new AccomdationsService();

        // GET: Dashboard/Accomdations
        public ActionResult Index()
        {
            AllAccomdationViewMmodel AllAcomdation = new AllAccomdationViewMmodel();
            AllAcomdation.accomdations = _Accomdation.ToListAccomdation();
            return View(AllAcomdation);
        }


        public ActionResult Action(int? Id)
        {
            AccomdationViewModel model = new AccomdationViewModel();

            if (Id.HasValue)
            {
                var UpAccomdationId = _Accomdation.GetAccomdationById(Id.Value);
                model.Id = UpAccomdationId.Id;
                model.AccomdationPackageId = UpAccomdationId.AccomdationPackageId;
                model.Name = UpAccomdationId.Name;
                model.Description = UpAccomdationId.Description;
            }
            model.AccomdationPackage = _db.AccomdationPackages.Select(AccomdationPackage => new SelectListItem
            {
                Text = AccomdationPackage.Name,
                Value = AccomdationPackage.Id.ToString(),
            }).ToList();

            return PartialView("_Action",model);
        }


        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Action([Bind(Include = "Id,AccomdationPackageId,Name,Description")] Accomdation accomdation, HttpPostedFileBase[] Files)
        {
            JsonResult json = new JsonResult();
            bool Result = false;

            StringBuilder sbCommText = new StringBuilder();
            sbCommText.Append(HttpUtility.HtmlEncode(accomdation.Description));
            sbCommText.Replace("&lt;b&gt;", "<b>");
            sbCommText.Replace("&lt;/b&gt;", "</b>");
            sbCommText.Replace("&lt;u&gt;", "<u>");
            sbCommText.Replace("&lt;/u&gt;", "</u>");
            accomdation.Description = sbCommText.ToString();

            if (accomdation.Id > 0)
            {
                Result = _Accomdation.UpdateAccomdation(accomdation);
            }
            else if ( Files != null && _Accomdation.SaveAccomdation(accomdation))
            {
               
              Result = SaveAccomdationPicture(accomdation.Id, Files);
 
            } else
            {
                Result = _Accomdation.SaveAccomdation(accomdation);
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
            Accomdation model = _Accomdation.GetAccomdationById(Id);


            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete([Bind(Include = "Id,AccomdationPackageId,Name,Description")]Accomdation accomdation)
        {
            JsonResult json = new JsonResult();

            bool Result = false;

            List<AccomdationPicture> DeleteAccomdationPicture = _db.AccomdationPictures.Where(x => x.AccomdationId == accomdation.Id).ToList();
            if(DeleteAccomdationPicture != null)
            {
                if (DeleteAllAccomdationPicture(DeleteAccomdationPicture))
                {
                    Result = _Accomdation.DeleteAccomdation(accomdation.Id);
                }
            }
            else
            {
                Result = _Accomdation.DeleteAccomdation(accomdation.Id);
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
        


        public bool SaveAccomdationPicture(int Id ,HttpPostedFileBase[] Files)
        {
            string SavePath = Server.MapPath("~/Areas/Image/Accomdation/");
            AccomdationPicture accomdationPicture = new AccomdationPicture();   
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }

            if(Files.Length > 0 && Files != null)
            {
                  foreach(var File in Files)
                  {
                        string FileName = File.FileName;
                        string _FileName = $"{Guid.NewGuid()}{FileName}{DateTime.Now.ToString("yyyymmssfff")}";
                        var Extesion = Path.GetExtension(File.FileName);
                        var AccomdationSavePath = Path.Combine(SavePath, FileName);
                        accomdationPicture.AccomdationId = Id;
                        accomdationPicture.URL = "~/Areas/Image/Accomdation/" + _FileName;
                        if (Extesion.ToLower() == ".jpg" || Extesion.ToLower() == ".jepg" || Extesion.ToLower() == ".png")
                        {
                            _db.AccomdationPictures.Add(accomdationPicture);

                            if (_db.SaveChanges() > 0) File.SaveAs(AccomdationSavePath);

                        }

                  }
                return true;
            }
          
            return false;

        }

        public bool DeleteAllAccomdationPicture(List<AccomdationPicture> DeleteAccomdationPictures)
        {
            bool Result = false;

            if(DeleteAccomdationPictures != null)
            {
                foreach(var DeleteAccomdationPicture in DeleteAccomdationPictures)
                {
                    string DeleteImage = Request.MapPath(DeleteAccomdationPicture.URL);
                    if (System.IO.File.Exists(DeleteImage))
                    {
                        System.IO.File.Delete(DeleteImage);
                        _Accomdation.DeleteAccomdationPicture(DeleteAccomdationPicture.Id);
                    }
                }
                Result= true;
            }
            return Result;

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
