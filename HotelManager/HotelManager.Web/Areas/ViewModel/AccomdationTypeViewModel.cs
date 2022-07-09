using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManager.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;



namespace HotelManager.Web.Areas.ViewModel
{
    public class AccomdationTypeViewModel
    {
        public IEnumerable<AccomodationType> accomodationTypes { get; set; }
    }
    public class AccomdationTypeActionModel
    {
        [DisplayName("編號")]
        public int Id { get; set; }
        [DisplayName("名字")]
        public string Name { get; set; }

        [DisplayName("介紹")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}