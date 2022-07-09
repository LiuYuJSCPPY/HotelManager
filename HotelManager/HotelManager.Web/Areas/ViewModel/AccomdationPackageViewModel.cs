using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManager.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace HotelManager.Web.Areas.ViewModel
{
    public class AccomdationPackageListViewModel
    {
        public IEnumerable<AccomdationPackage> accomdationPackages { get; set; }
    }


    public class AccomdationPackageViewModel
    {
        [DisplayName("編號")]
        public int Id { get; set; }
        public int AccomodationTypeId { get; set; }
        public virtual AccomodationType AccomodationType { get; set; }

        [DisplayName("名字")]
        public string Name { get; set; }
        [DisplayName("房間型號")]
        public string NoOfRoom { get; set; }
        [DisplayName("價錢")]
        public int PericeNigeth { get; set; }

        public virtual ICollection<AccomdationPackagePicture> AccomdationPackagePictures { get; set; }
    }

    public class FormAccomdationPackageViewModel
    {
        [DisplayName("編號")]
        public int Id { get; set; }
        public int AccomodationTypeId { get; set; }
        public List<SelectListItem> AccomodationType { get; set; }

        [DisplayName("名字")]
        public string Name { get; set; }
        [DisplayName("房間型號")]
        public string NoOfRoom { get; set; }
        [DisplayName("價錢")]
        public int PericeNigeth { get; set; }

    }
}