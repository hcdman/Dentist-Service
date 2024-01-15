using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalService.Model; 
public class DentistSchedule {
    public int ScheduleId { get; set; }
    public int DentistId { get; set; }
    public DateTime WorkingDay { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
