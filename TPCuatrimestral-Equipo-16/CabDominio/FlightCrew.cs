using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabDominio
{
    public class FlightCrew : Employee
    {
        public int IdFlight { get; set; }
        public bool Status { get; set; }
    }
}
