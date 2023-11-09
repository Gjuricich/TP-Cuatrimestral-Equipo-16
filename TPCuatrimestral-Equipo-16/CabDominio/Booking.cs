using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CabDominio
{
    public class Booking
    {
        public int IdBooking { get; set; }
        public int IdClient { get; set; }
        public City Origin { get; set; } //Composición de ciudad
        public City Destination { get; set; } //Composición de ciudad
        public DateTime SolicitudDate { get; set; }
        public DateTime DateBooking { get; set; }
        public int Passengers { get; set; }
        public string StateBooking { get; set; } 
        public bool State { get; set; }

        public Booking()
        {
            Origin = new City();

            Destination = new City();


        }

   

    }
}
