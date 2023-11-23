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
        public Booking booking { get; set; }
        public Aircraft aircraft { get; set; }
        public string FlightState { get; set; }
        public Itinerary itinerary { get; set; }             
        public List<FlightCrew> crew { get; set; }
        public List<FlightPassenger> Passengers { get; set; }
        public bool Status { get; set; }
        public Flight()
        {
            aircraft = new Aircraft();
            Passengers = new List<FlightPassenger>();
            crew = new List<FlightCrew>();
            booking = new Booking();
        }
    }

    }
