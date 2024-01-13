using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalService.Model; 
public class Appointment {
    public int AppointmentID { get; set; }
    public int CustomerID { get; set; }
    public int DentistId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
