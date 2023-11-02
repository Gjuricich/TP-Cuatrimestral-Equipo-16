using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabDominio
{
    public class Flight
    {
        public int ID_Flight { get; set; }
        public string Origin { get; set; } 
        public string Destiny { get; set; }
        public DateTime FlightDateTime { get; set; }
        public int amuntPassengers { get; set; }
        public string FlightState { get; set; }

        public List<Person> Passengers { get; set; } 
        public Flight() {Passengers = new List<Person> (); }

    }
}
