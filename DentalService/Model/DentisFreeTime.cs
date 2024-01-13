using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalService.Model; 
public class DentisFreeTime {
    public int DentistID { get; set; }
    public string DentistName { get; set; }
    public DateTime WorkingDay { get; set; }
    public int FreeHour { get; set; } //8am <-> 8am-9am
}
