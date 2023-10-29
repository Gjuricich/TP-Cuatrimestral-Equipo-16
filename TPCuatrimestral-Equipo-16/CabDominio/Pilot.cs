using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabDominio
{
    public class Pilot : Employee
    {  
        public string LicenseType {get; set;}
        public string FlightLicense { get; set; }
        public string Rank { get; set; }
        public string Specialization { get; set; }
    }
    
}
