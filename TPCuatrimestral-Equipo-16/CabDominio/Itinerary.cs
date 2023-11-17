using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabDominio
{
    public class Itinerary
    {
        public DateTime FlightArrival { get; set; }
        public DateTime FlightDeparture { get; set; }
        public string AirportArrival { get; set; }
        public string AirportDeparture { get; set; }
        public int ETA { get; set; }
        public TimeSpan flightHours { get; set; }
        public string updateTrip { get; set; }
        public Itinerary()
        {
            flightHours = new TimeSpan(2, 30, 0);
        }
    }

}


//Cargas y pasajeros: Información sobre la cantidad de carga y pasajeros a bordo, incluyendo cualquier información especial sobre la carga.

//Restricciones y requisitos de vuelo: Cualquier restricción o requisito específico para el vuelo, como restricciones de altitud, restricciones de espacio aéreo o requisitos de combustible.

//Instrucciones de seguridad: Información sobre procedimientos de seguridad, incluyendo rutas de escape, ubicación de equipos de emergencia y procedimientos de evacuación.

