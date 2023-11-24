using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabDominio
{
    public class Aircraft
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int PassengerCapacity { get; set; }
        public int MinimumCrew { get; set; }
        public decimal FuelCapacity { get; set; }
        public decimal FlightRange { get; set; }
        public DateTime YearOfManufacture { get; set; }
        public bool Available { get; set; }

    }
}
