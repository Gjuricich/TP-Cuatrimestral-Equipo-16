using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabDominio
{

    class Itinerary
    {
        public DateTime flightArrival { get; set; }
        public DateTime flightDeparture { get; set; }
        public string airportArrival { get; set; }
        public string airportDeparture { get; set; }

        public Aircraft aircraft { get; set; }
        public Flight flight { get; set; }
        public List<Employee> crew { get; set; } 
        public int ETA { get; set; }
        public int flightHours { get; set; }
        public TimeSpan flightHour { get; set; }
        public string updateTrip { get; set; }
        public Itinerary()
        {
            aircraft = new Aircraft();
            crew = new List<Employee>();
            flightHour  = new TimeSpan(2, 30, 0);
            flight = new Flight();


        }
    }

}


//Cargas y pasajeros: Información sobre la cantidad de carga y pasajeros a bordo, incluyendo cualquier información especial sobre la carga.

//Restricciones y requisitos de vuelo: Cualquier restricción o requisito específico para el vuelo, como restricciones de altitud, restricciones de espacio aéreo o requisitos de combustible.

//Instrucciones de seguridad: Información sobre procedimientos de seguridad, incluyendo rutas de escape, ubicación de equipos de emergencia y procedimientos de evacuación.

