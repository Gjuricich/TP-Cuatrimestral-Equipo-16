using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabDominio
{
    public class Booking
    {  
        //agregar cliente
        public string Origin { get; set; } //clase
        public string Destination { get; set; }//clase
        public DateTime DateBooking { get; set; }
        public int Passengers { get; set; }
        public string  TripType { get; set; }

        //Estado

    }
}
