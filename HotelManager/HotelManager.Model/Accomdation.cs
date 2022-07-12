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
    [Table("Accomdation",Schema ="dbo")]
    public class Accomdation
    {
        public int Id { get; set; }
        
        public int AccomdationPackageId { get; set; }
        public virtual AccomdationPackage AccomdationPackage { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<AccomdationPicture> accomdationPictures { get; set; }
    }
}
