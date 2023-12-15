using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalService.Model
{
    public class EmployeeM
    {
       

        public EmployeeM(int idE, string nameE)
        {
           Id = idE;
           Name = nameE;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
