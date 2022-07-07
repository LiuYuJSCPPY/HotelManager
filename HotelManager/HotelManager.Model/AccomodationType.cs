using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model
{
    [Table("AccomodationType", Schema = "dbo")]
    public class AccomodationType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public virtual ICollection<AccomdationPackage> AccomdationPackages { get; set; }    
    }
}
