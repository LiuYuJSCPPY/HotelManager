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

    public class AllAccomdationViewMmodel {
    
        public IEnumerable<Accomdation> accomdations { get; set; }

    }


    public class AccomdationViewModel
    {
        public int Id { get; set; }
        public int AccomdationPackageId { get; set; }

       public List<SelectListItem> AccomdationPackage { get; set; }
       

        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}