using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManager.Model
{
    [Table("BookAccmodation", Schema = "dbo")]
    public class BookAccmodation
    {
        public int Id { get; set; }
       
        public string HotelUserId { get; set; }
        
        public virtual HotelUser HotelUser { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public DateTime BookingFrom { get; set; }
        public DateTime BookingTo { get; set; }
        public int accomdationPackageId { get; set; }
        public AccomdationPackage accomdationPackage { get; set; }

        public decimal TotalAmount { get; set; }
    }

}
