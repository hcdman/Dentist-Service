using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalService.Model
{
    public class DentistScheduleM
    {
        public int ScheduleId { get; set; }
        public int DentistId { get; set; }
        public string WorkingDay { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public DentistScheduleM(int scheduleId, int dentistId, string workingDay, string startTime, string endTime)
        {
            ScheduleId = scheduleId;
            DentistId = dentistId;
            WorkingDay = workingDay;
            StartTime = startTime;
            EndTime = endTime;
        }
      
    }
}
