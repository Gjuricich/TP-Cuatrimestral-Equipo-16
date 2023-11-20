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
        public DateTime FlightDateTime { get; set; }
        public int AmountPassengers { get; set; }


        public Booking booking { get; set; }//aca tengo las ciudades de destino y origen
        public List<Employee> crew { get; set; }
        public Aircraft aircraft { get; set; }
        public Itinerary itinerary { get; set; }
        public string FlightState { get; set; }

        public bool Status { get; set; }

        public List<Person> Passengers { get; set; }
        public Flight()
        {
            aircraft = new Aircraft();
            Passengers = new List<Person>();
            crew = new List<Employee>();
        }
    }

    }
