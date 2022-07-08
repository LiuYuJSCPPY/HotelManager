using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManager.Model;


namespace HotelManager.Web.Areas.ViewModel
{
    public class AccomdationTypeViewModel
    {
        public IEnumerable<AccomodationType> accomodationTypes { get; set; }
    }
    public class AccomdationTypeActionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}