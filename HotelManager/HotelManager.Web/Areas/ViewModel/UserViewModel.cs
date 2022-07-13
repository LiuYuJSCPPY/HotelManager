using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using HotelManager.Model;
using HotelManager.Web.Models;

namespace HotelManager.Web.Areas.ViewModel
{
    public class AllUserToListViewModel
    {
        public IEnumerable<HotelUser> hotelUsers { get; set; }
    }



    public class UserViewModel 
    { 
        public string Id { get; set; }
        public string UserName { get; set; }   
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
    
}