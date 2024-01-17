using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalService.Model
{
    class RecordService
    {
        public int MRecordID { get; set; }
        public int DentalService { get; set; }
        public string NameService { get; set; }
        public int Price { get; set; }
        public RecordService(int mRecordID, int dentalService, string nameService, int price)
        {
            MRecordID = mRecordID;
            DentalService = dentalService;
            NameService = nameService;
            Price = price;
        }
    }
}
