using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabDominio
{
    public class Booking
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DateBooking { get; set; }
        public int Passengers { get; set; }
        public string  TripType { get; set; }

    }
}
