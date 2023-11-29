using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabDominio;

namespace CabBusiness
{
    public class ItineraryBusiness
    {
        public List<Itinerary> List()
        {
            List<Itinerary> list = new List<Itinerary>();
            DataManager dataManager = new DataManager();

            try
            {

                dataManager.setQuery("SELECT  FlightArrival, FlightDeparture, CodIATAArrival, CodIATADeparture, ETA,updateTrip,flightHours FROM Itinerary");
                dataManager.executeRead();
                while (dataManager.Lector.Read())
                {
                    Itinerary itinerary = new Itinerary();
                    itinerary.ETA = (int)dataManager.Lector["ETA"];
                    itinerary.AirportArrival = (string)dataManager.Lector["CodIATAArrival"];
                    itinerary.AirportDeparture = (string)dataManager.Lector["CodIATADeparture"];
                    itinerary.updateTrip = (string)dataManager.Lector["updateTrip"];
                    itinerary.FlightArrival = (DateTime)dataManager.Lector["FlightArrival"];
                    itinerary.FlightDeparture = (DateTime)dataManager.Lector["FlightDeparture"];
                    itinerary.flightHours= (TimeSpan)dataManager.Lector["flightHours"];

                    list.Add(itinerary);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                dataManager.closeConection();
            }
        }
    }
}
