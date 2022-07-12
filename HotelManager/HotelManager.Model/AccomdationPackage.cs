using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace HotelManager.Model
{
    
    [Table("AccomdationPackage",Schema ="dbo")]
    public class AccomdationPackage
    {
        public int Id { get; set; }
        public int AccomodationTypeId { get; set; }
        public virtual AccomodationType AccomodationType { get; set; }
        public string Name { get; set; }
        public string NoOfRoom { get; set; }
        public int PericeNigeth { get; set; }

        public virtual ICollection<AccomdationPackagePicture> AccomdationPackagePictures { get; set; }
        public virtual ICollection<Accomdation> Accomdations { get; set; }
    }
}
