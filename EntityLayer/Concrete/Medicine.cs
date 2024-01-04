using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Medicine
    {
        [Key]
        public int MedicineID { get; set; }
        public string MedicineName { get; set; }
        public string ManufacturerName { get; set; }        //üretici firma adı
        public decimal Price { get; set; }
    }
}
