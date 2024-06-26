﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalService.Model
{
    class RecordMedicine
    {
        public int MRecordID { get; set; }
        public int MedicineID { get; set; }

        public string NameMedicine { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public RecordMedicine(int mRecordID, int medicineID, string nameMedicine, int price, int quantity)
        {
            MRecordID = mRecordID;
            MedicineID = medicineID;
            NameMedicine = nameMedicine;
            Price = price;
            Quantity = quantity;
        }
    }
}
