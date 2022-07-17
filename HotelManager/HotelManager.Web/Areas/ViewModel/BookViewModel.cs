using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManager.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace HotelManager.Web.Areas.ViewModel
{
    public class BookViewModel
    {
    }

    public class BookListViewModel
    {
        public IEnumerable<BookAccmodation> BookAccmodations { get; set; }
    }
}