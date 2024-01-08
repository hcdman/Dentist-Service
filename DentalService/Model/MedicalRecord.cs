using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalService.Model; 
public class MedicalRecord {
    public int MRecordId { get; set; }
    public int CustomerId { get; set; }
    public int DentistId { get; set; }
    public DateTime MedicalRecordDate { get; set; }
    public int ExaminationFee { get; set; }
}
