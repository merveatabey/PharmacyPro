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
    public class MedicineManager : IMedicineService
    {
        IMedicineDal _medicineDal;

        public MedicineManager(IMedicineDal medicineDal)
        {
            _medicineDal = medicineDal;
        }

        public Medicine GetByID(int id)
        {
            return _medicineDal.GetByID(id);
        }

        public List<Medicine> GetList()
        {
            return _medicineDal.GetList();
        }

        public void TAdd(Medicine t)
        {
            _medicineDal.Add(t);
        }

        public void TDelete(Medicine t)
        {
            _medicineDal.Delete(t);
        }

        public void TUpdate(Medicine t)
        {
            _medicineDal.Update(t);
        }
    }
}
