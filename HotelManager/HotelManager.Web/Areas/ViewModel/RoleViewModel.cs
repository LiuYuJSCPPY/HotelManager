using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManager.Web.Areas.ViewModel
{
    public class RoleListingModel
    {
        public IEnumerable<IdentityRole> roles { get; set; }
        
    }

    public class RoelViewModel
    {
        public string Id { get; set; }
        public string name { get; set; }

    }
}