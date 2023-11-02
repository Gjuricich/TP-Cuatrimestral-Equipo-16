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
        public string destination { get; set; }
        public DateTime dateBooking { get; set; }
        public int passengers { get; set; }
        public string  tripType { get; set; }

    }
}
