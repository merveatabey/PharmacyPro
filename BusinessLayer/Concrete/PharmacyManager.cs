using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PharmacyManager : IPharmacyService
    {
        IPharmacyDal _pharmacyDal;

        public PharmacyManager(IPharmacyDal pharmacyDal)
        {
            _pharmacyDal = pharmacyDal;
        }

        public Pharmacy GetByID(int id)
        {
            return _pharmacyDal.GetByID(id);
        }

        public List<Pharmacy> GetList()
        {
            return _pharmacyDal.GetList();
        }

        public void TAdd(Pharmacy t)
        {
            _pharmacyDal.Add(t);
        }

        public void TDelete(Pharmacy t)
        {
            _pharmacyDal.Delete(t);
        }

        public void TUpdate(Pharmacy t)
        {
           _pharmacyDal.Update(t);
        }
    }
}
