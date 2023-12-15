using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalService.Model
{
    public class CustomerM
    {
    
        public CustomerM(int idC, string nameC)
        {
            Id = idC;
            Name = nameC;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
