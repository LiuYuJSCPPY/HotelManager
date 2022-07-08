using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HotelManager.Model;
using HotelManager.Data;

namespace HotelManager.Services
{
    public class AccomodtaionTypeService
    {

        public List<AccomodationType> AllListAccomodationType()
        {
            HotelManagerContext _db = new HotelManagerContext();
            return _db.AccomodationTypes.ToList();
        }

        public AccomodationType GetAccomodationTypeById(int Id)
        {
            HotelManagerContext _db = new HotelManagerContext();

            return _db.AccomodationTypes.Find(Id);
        }


        public bool SaveAccomodationType(AccomodationType accomodationType)
        {
            HotelManagerContext _db = new HotelManagerContext();
            _db.AccomodationTypes.Add(accomodationType);

            return _db.SaveChanges() > 0;
        }

        public bool UpdateAccomodationType(AccomodationType accomodationType)
        {
            HotelManagerContext _db = new HotelManagerContext();
            _db.Entry(accomodationType).State = EntityState.Modified;
            return _db.SaveChanges() > 0;
        }

        public bool RemoveAccomdationType(int Id)
        {
            HotelManagerContext _db = new HotelManagerContext();
            AccomodationType accomodationType = _db.AccomodationTypes.Find(Id);
            _db.AccomodationTypes.Remove(accomodationType);
            return _db.SaveChanges() > 0;
        }
    }
}
