using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model
{
    [Table("AccomdationPicture", Schema = "dbo")]
    public class AccomdationPicture
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public int AccomdationId { get; set; }
        public virtual Accomdation Accomdation { get; set; }
    }
}
