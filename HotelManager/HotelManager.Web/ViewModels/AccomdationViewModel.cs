using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManager.Model;

namespace HotelManager.Web.ViewModels
{
    public class AccomdationViewModel
    {
        public AccomdationPackage accomdationPackage { get; set; }
    }
    public class GetAllAccomdationViewModel 
    {
        public AccomodationType accomodationType { get; set; }

        public IEnumerable<Accomdation> accomdations { get; set; }
        public IEnumerable<AccomdationPackage> accomdationPackages { get; set; }

        public int SelectedAccomodationPackageID { get; set; }


    }

    public class GetAccomdationViewModel
    {
        public IEnumerable<Accomdation> accomdations { get; set; }

    }

}