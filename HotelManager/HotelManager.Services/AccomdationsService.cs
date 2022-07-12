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
    public class AccomdationsService
    {
        public IEnumerable<Accomdation> ToListAccomdation()
        {
            HotelManagerContext _context = new HotelManagerContext();

            return _context.Accomdations.Include(x => x.AccomdationPackage).ToList();
        }

        public Accomdation GetAccomdationById(int Id)
        {
            HotelManagerContext _context = new HotelManagerContext();

            return _context.Accomdations.Find(Id);
        }

        public bool SaveAccomdation(Accomdation accomdation)
        {
            HotelManagerContext _context = new HotelManagerContext();

            _context.Accomdations.Add(accomdation);


            return _context.SaveChanges() > 0;
        }

        public bool UpdateAccomdation(Accomdation accomdation)
        {
            HotelManagerContext _context = new HotelManagerContext();

            _context.Entry(accomdation).State = EntityState.Modified;

            return _context.SaveChanges() > 0;
        }

        public bool DeleteAccomdation(int Id)
        {
            HotelManagerContext _context = new HotelManagerContext();

            Accomdation DeleteAccomdation = _context.Accomdations.Find(Id);
            _context.Accomdations.Remove(DeleteAccomdation);

            return _context.SaveChanges() > 0;
        }




        public void DeleteAccomdationPicture(int Id)
        {
            HotelManagerContext _context = new HotelManagerContext();
            AccomdationPicture DeleteModel = _context.AccomdationPictures.Find(Id);
            _context.AccomdationPictures.Remove(DeleteModel);
            _context.SaveChanges();
        }
        
    }
}
