using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManager.Model;
using HotelManager.Data;

namespace HotelManager.Services
{
  
    public class HotelService
    {
        public AccomodationType GetAccomodationTypeByID(int Id)
        {
            var _context = new HotelManagerContext();
            
             return _context.AccomodationTypes.Find(Id);
        }

        public IEnumerable<AccomdationPackage> GetAllAccomdationPackageByAccomdationType(int Id)
        {
            var _context= new HotelManagerContext();
            return _context.AccomdationPackages.Where(x => x.AccomodationTypeId == Id).ToList();

        }
        public IEnumerable<Accomdation> GetAllAccomdationsByAccomdationPackage(int AccomdationPackageId)
        {
            var _context = new HotelManagerContext();
            return _context.Accomdations.Where(x => x.AccomdationPackageId == AccomdationPackageId).ToList();
        }
    }
}
