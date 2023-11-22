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
                dataManager.setQuery("SELECT F.IdFlight,F.FlightState,B.Passengers,B.DateBooking,CD.NombreCiudad AS Destino,CO.NombreCiudad AS Origen, A.Model AS Aircraft, F.Estado FROM Flight F LEFT JOIN Booking B ON F.IdBooking = B.IdBooking LEFT JOIN Aircraft A ON F.IdAircraft = A.IdAircraft INNER JOIN Ciudades CD ON B.IdDestino = CD.IdCiudad INNER JOIN Ciudades CO ON B.IdOrigen = CO.IdCiudad");
                dataManager.executeRead();
                while (dataManager.Lector.Read())
                {
                    Flight flight = new Flight();
                    flight.ID_Flight = (int)dataManager.Lector["IdFlight"];
                    flight.booking.Passengers = (short)dataManager.Lector["Passengers"];
                    flight.booking.DateBooking = (DateTime)dataManager.Lector["DateBooking"];
                    flight.booking.Origin.NameCity = (string)dataManager.Lector["Origen"];
                    flight.booking.Destination.NameCity = (string)dataManager.Lector["Destino"];
                    if (dataManager.Lector["Aircraft"] != DBNull.Value)
                    {

                        flight.aircraft.Model = (string)dataManager.Lector["Aircraft"];


                    }
                    else
                    {
                        flight.aircraft.Model = "";
                    }
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

        public List<Flight> ListByClient(int IdClient)
        {
            List<Flight> list = new List<Flight>();
            DataManager dataManager = new DataManager();

            try
            {
                dataManager.setQuery("SELECT  F.IdFlight,F.FlightState,B.Passengers,B.DateBooking,CD.NombreCiudad AS Destino,CO.NombreCiudad AS Origen, A.Model AS Aircraft, F.Estado FROM Flight F LEFT JOIN Booking B ON F.IdBooking = B.IdBooking LEFT JOIN Aircraft A ON F.IdAircraft = A.IdAircraft INNER JOIN Ciudades CD ON B.IdDestino = CD.IdCiudad INNER JOIN Ciudades CO ON B.IdOrigen = CO.IdCiudad LEFT JOIN Client C ON B.IdClient = C.IdClient WHERE C.IdClient = @IdClient ");
                dataManager.setParameter("@IdClient", IdClient);
                dataManager.executeRead();
                while (dataManager.Lector.Read())
                {
                    Flight flight = new Flight();
                    flight.ID_Flight = (int)dataManager.Lector["IdFlight"];
                    flight.booking.Passengers = (short)dataManager.Lector["Passengers"];
                    flight.booking.DateBooking = (DateTime)dataManager.Lector["DateBooking"];
                    flight.booking.Origin.NameCity = (string)dataManager.Lector["Origen"];
                    flight.booking.Destination.NameCity = (string)dataManager.Lector["Destino"];
                    if (dataManager.Lector["Aircraft"] != DBNull.Value)
                    {

                        flight.aircraft.Model = (string)dataManager.Lector["Aircraft"];


                    }
                    else
                    {
                        flight.aircraft.Model = "";
                    }
                    flight.FlightState = (string)dataManager.Lector["FlightState"];
                    flight.Status = (bool)dataManager.Lector["Estado"];

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
       
                dataManager.setQuery("INSERT INTO Flight(IdBooking) VALUES (@IdBooking)");
                dataManager.setParameter("@IdBooking", booking.IdBooking);
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
