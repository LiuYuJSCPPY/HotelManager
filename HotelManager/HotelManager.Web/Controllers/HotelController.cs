﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManager.Model;
using HotelManager.Services;
using HotelManager.Web.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using HotelManager.Data;
using System.Data.Entity;


namespace HotelManager.Web.Controllers
{
    public class HotelController : Controller
    {
        private HotelManagerContext _db = new HotelManagerContext();
        private HotelService _hotelService = new HotelService();
        // GET: Hotel
        public ActionResult ListRoom()
        {
            GetAccomdationViewModel model = new GetAccomdationViewModel();

            model.accomdations = _db.Accomdations.Include(X => X.AccomdationPackage).ToList();
            return View(model);
        }
        public ActionResult Detail(int Id)
        {
            AccomdationPackage model = _db.AccomdationPackages.Find(Id);
            return View(model);
        }

      


        [HttpPost]
        public JsonResult Action(BookAccmodation roomBookings)
        {
            JsonResult json = new JsonResult();
            bool Result = false;


            if (roomBookings!= null && User.Identity.IsAuthenticated)
            {
               int TotalDay = Convert.ToInt32((roomBookings.BookingTo - roomBookings.BookingFrom).TotalDays);
                AccomdationPackage package = _db.AccomdationPackages.Single(model => model.Id == roomBookings.accomdationPackageId);
                int TotalPrice = package.PericeNigeth * TotalDay;
                roomBookings.TotalAmount = TotalPrice;
                roomBookings.HotelUserId = User.Identity.GetUserId();


                _db.BookAccmodations.Add(roomBookings);
                Result = _db.SaveChanges() > 0;

            }
           



            if (Result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "上傳失敗!" };
            }
            return json;
        }

    }
}