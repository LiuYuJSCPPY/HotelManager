using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Data
{
    public class HotelManagerContext : DbContext
    {
        public HotelManagerContext() : base("name=HotelManagerContext")
        {

        }


    }
}
