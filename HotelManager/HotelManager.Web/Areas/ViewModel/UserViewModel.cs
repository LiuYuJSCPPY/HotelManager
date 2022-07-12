using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using HotelManager.Model;
using HotelManager.Web.Models;

namespace HotelManager.Web.Areas.ViewModel
{
    public class UserViewModel
    {
        public IEnumerable<HotelUser> hotelUsers { get; set; }
    }
}