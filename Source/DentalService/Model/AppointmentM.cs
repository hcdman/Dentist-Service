using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalService.Model
{
   public class AppointmentM
    {
        public int AppointmentId { get; set; }
        public int DentistId { get; set; }
        public string AppointmentDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int CustomerId { get; set; }
        public bool CreateBy {  get; set; }
        public string Status { get; set; }
        public AppointmentM(int appointmentId,string appointmentDate, string startTime, string endTime, int dentistId, int customerId, bool createBy, string status)
        {
            AppointmentId = appointmentId;
            DentistId = dentistId;
            AppointmentDate = appointmentDate;
            StartTime = startTime;
            EndTime = endTime;
            CustomerId = customerId;
            CreateBy = createBy;
            Status = status;
        }
    }
}
