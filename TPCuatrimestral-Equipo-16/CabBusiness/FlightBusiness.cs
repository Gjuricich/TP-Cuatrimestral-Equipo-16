using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabDominio;

namespace CabBusiness
{
    public class FlightBusiness
    {
        public List<Flight> List()
        {
            List<Flight> list = new List<Flight>();
            DataManager dataManager = new DataManager();

            try
            { 
                /*
                IdFlight 
                FlightDateTime 
                AmountPassengers 
                 IdBooking 
               IdAircraft 
                FlightState
                Estado*/

                dataManager.setQuery("SELECT IdFlight,FlightDateTime,AmountPassengers,FlightState,Estado FROM Flight");
                dataManager.executeRead();
                while (dataManager.Lector.Read())
                {
                    Flight flight = new Flight();
                    flight.ID_Flight = (int)dataManager.Lector["IdFlight"];
                    flight.FlightDateTime = (DateTime)dataManager.Lector["FlightDateTime"];
                    flight.AmountPassengers = (int)dataManager.Lector["AmountPassengers"];
                    flight.FlightState = (string)dataManager.Lector["FlightState"];
                    flight.Status= (bool)dataManager.Lector["Estado"];
                    list.Add(flight);
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

        public void addFlight(Booking booking)
        {
            DataManager dataManager = new DataManager();

            try
            {
       
                dataManager.setQuery("INSERT INTO Flight(IdBooking,AmountPassengers,FlightDateTime) VALUES (@IdBooking, @PASAJEROS, @FECHARESERVA)");
                dataManager.setParameter("@IdBooking", booking.IdBooking);
                dataManager.setParameter("@PASAJEROS", booking.Passengers);
                dataManager.setParameter("@FECHARESERVA", booking.DateBooking);
                dataManager.executeRead();

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
