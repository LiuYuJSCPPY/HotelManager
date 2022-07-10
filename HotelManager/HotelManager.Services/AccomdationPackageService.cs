using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManager.Model;
using HotelManager.Data;
using System.Data.Entity;



namespace HotelManager.Services
{
    public class AccomdationPackageService
    {

        public IList<AccomdationPackage> ToListAccomdationPackages()
        {
            HotelManagerContext _context = new HotelManagerContext();
            return _context.AccomdationPackages.Include(a => a.AccomodationType).ToList();
        }

        public AccomdationPackage GetAccomdationPackageById(int Id)
        {
            HotelManagerContext _context = new HotelManagerContext();
            return _context.AccomdationPackages.Find(Id);
            
        }

        public bool SaveAccomdationPackage(AccomdationPackage accomdationPackage )
        {
            HotelManagerContext _context = new HotelManagerContext();
            _context.AccomdationPackages.Add(accomdationPackage);
            return _context.SaveChanges() > 0;
        }
        public bool UpdateAccomdationPackage(AccomdationPackage accomdationPackage)
        {
            HotelManagerContext _context = new HotelManagerContext();
            _context.Entry(accomdationPackage).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
            
        }

        public bool DeleteAccomdationPackage(int Id)
        {
            HotelManagerContext _context = new HotelManagerContext();
            AccomdationPackage DeleteAccomdationPackage = _context.AccomdationPackages.Find(Id);
            _context.AccomdationPackages.Remove(DeleteAccomdationPackage);

            return _context.SaveChanges() > 0;
        }



        
    }
}
