using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model
{

    [Table("AccomdationPackagePicture", Schema = "dbo")]
    public class AccomdationPackagePicture
    {
        public int Id { get; set; }

        public int AccomdationPackageId { get; set; }

        public virtual AccomdationPackage AccomdationPackage { get; set; }
        public string URL { get; set; }

    }
}
