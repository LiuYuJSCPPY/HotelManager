using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManager.Model;
using HotelManager.Web.Areas.ViewModel;
using HotelManager.Data;

namespace HotelManager.Web.Areas.Dashboard.Controllers
{

    public class BookingController : Controller
    {

        private HotelManagerContext _db = new HotelManagerContext();
        // GET: Dashboard/Booking
        public ActionResult Index()
        {
            BookListViewModel model = new BookListViewModel();
            model.BookAccmodations = _db.BookAccmodations.ToList();
            return View(model);
        }
    }
}