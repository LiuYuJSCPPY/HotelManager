using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManager.Model;

namespace HotelManager.Data
{
    public class HotelManagerContext : IdentityDbContext<HotelUser>
    {
        public HotelManagerContext()
            : base("HotelManagerContext", throwIfV1Schema: false)
        {
        }

        public static HotelManagerContext Create()
        {
            return new HotelManagerContext();
        }


        public virtual DbSet<Accomdation> Accomdations { get; set; }
        public virtual DbSet<AccomdationPackage> AccomdationPackages { get; set; }
        public virtual DbSet<AccomdationPackagePicture> AccomdationPackagePictures { get; set; }
        public virtual DbSet<AccomdationPicture> AccomdationPictures { get; set; }
        public virtual DbSet<AccomodationType> AccomodationTypes { get; set; }
         public virtual DbSet<BookAccmodation> BookAccmodations { get; set; }
        
    }
}

