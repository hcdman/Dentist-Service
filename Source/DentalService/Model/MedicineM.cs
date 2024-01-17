using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalService.Model
{
    public class MedicineM
    {
        public int MedicineID { get; set; }
        public string MedicineName { get; set; }
        public string Unit { get; set; }
        public string Prescription { get; set; }
        public int QuantityOnStock { get; set; }
        public string ExpirationDate { get; set; }
        public int Price { get; set; }

        public string Description { get; set; }

        public int SoldQuantity { get; set ; }
    }
}
    