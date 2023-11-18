using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabDominio;

namespace CabBusiness
{
    public class BookingBusiness
    {
        public List<Booking> List()
        {
            List<Booking> list = new List<Booking>();
            DataManager dataManager = new DataManager();

            try
            {

                dataManager.setQuery("SELECT * FROM Booking");
                dataManager.executeRead();
                while (dataManager.Lector.Read())
                {
                    Booking booking = new Booking();
                    booking.IdBooking = (int)(long)dataManager.Lector["IdBooking"];
                    booking.IdClient = (int)(long)dataManager.Lector["IdClient"];
                    booking.Origin.IdCity = (int)(long)dataManager.Lector["IdOrigen"];
                    booking.Destination.IdCity = (int)(long)dataManager.Lector["IdDestino"];
                    booking.SolicitudDate = (DateTime)dataManager.Lector["SolicitudDate"];
                    booking.DateBooking = (DateTime)dataManager.Lector["DateBooking"];
                    booking.Passengers = (short)dataManager.Lector["Passengers"];
                    booking.StateBooking = (string)dataManager.Lector["StateBooking"];
                    booking.State = (bool)dataManager.Lector["Estado"];

                    list.Add(booking);
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

        
             public List<Booking> ListInProgress()
           {
            List<Booking> list = new List<Booking>();
            DataManager dataManager = new DataManager();

            try
            {
                dataManager.setQuery("SELECT * FROM Booking WHERE StateBooking=@status");
                dataManager.setParameter("@status", "En proceso");       
                dataManager.executeRead();
                while (dataManager.Lector.Read())
                {
                    Booking booking = new Booking();
                    booking.IdBooking = (int)(long)dataManager.Lector["IdBooking"];
                    booking.IdClient = (int)(long)dataManager.Lector["IdClient"];
                    booking.Origin.IdCity = (int)(long)dataManager.Lector["IdOrigen"];
                    booking.Destination.IdCity = (int)(long)dataManager.Lector["IdDestino"];
                    booking.SolicitudDate = (DateTime)dataManager.Lector["SolicitudDate"];
                    booking.DateBooking = (DateTime)dataManager.Lector["DateBooking"];
                    booking.Passengers = (short)dataManager.Lector["Passengers"];
                    booking.StateBooking = (string)dataManager.Lector["StateBooking"];
                    booking.State = (bool)dataManager.Lector["Estado"];

                    list.Add(booking);
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



        public List<Booking> ListByClient(Client client)
        {
            int idClient = client.IdClient;
            List<Booking> list = new List<Booking>();
            DataManager dataManager = new DataManager();
            CityBusiness ctBusines = new CityBusiness();

            try
            {

                dataManager.setQuery("SELECT * FROM Booking WHERE IdClient = '" + idClient + "'");
                dataManager.executeRead();
                while (dataManager.Lector.Read())
                {
                    Booking booking = new Booking();
                    booking.IdBooking = (int)(long)dataManager.Lector["IdBooking"];
                    booking.IdClient = (int)(long)dataManager.Lector["IdClient"];
                    int Origin = (int)(long)dataManager.Lector["IdOrigen"];
                    int Destination = (int)(long)dataManager.Lector["IdDestino"];
                    booking.SolicitudDate = (DateTime)dataManager.Lector["SolicitudDate"];
                    booking.DateBooking = (DateTime)dataManager.Lector["DateBooking"];
                    booking.Passengers = (short)dataManager.Lector["Passengers"];
                    booking.StateBooking = (string)dataManager.Lector["StateBooking"];
                    booking.State = (bool)dataManager.Lector["Estado"];
                    booking.Origin = ctBusines.GetCityByID(Origin);
                    booking.Destination = ctBusines.GetCityByID(Destination);
                    list.Add(booking);
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

        public List<Booking> BookingClient(int idClient)
        {
            List<Booking> list = new List<Booking>();
            DataManager dataManager = new DataManager();
            CityBusiness ctBusines = new CityBusiness();

            try
            {

                dataManager.setQuery("SELECT * FROM Booking WHERE IdClient=@id AND StateBooking<>@status");
                dataManager.setParameter("@status", "En proceso");
                dataManager.setParameter("@id", idClient);
                dataManager.executeRead();
                while (dataManager.Lector.Read())
                {
                    Booking booking = new Booking();
                    booking.IdBooking = (int)(long)dataManager.Lector["IdBooking"];
                    booking.IdClient = (int)(long)dataManager.Lector["IdClient"];
                    int Origin = (int)(long)dataManager.Lector["IdOrigen"];
                    int Destination = (int)(long)dataManager.Lector["IdDestino"];
                    booking.SolicitudDate = (DateTime)dataManager.Lector["SolicitudDate"];
                    booking.DateBooking = (DateTime)dataManager.Lector["DateBooking"];
                    booking.Passengers = (short)dataManager.Lector["Passengers"];
                    booking.StateBooking = (string)dataManager.Lector["StateBooking"];
                    booking.State = (bool)dataManager.Lector["Estado"];
                    booking.Origin = ctBusines.GetCityByID(Origin);
                    booking.Destination = ctBusines.GetCityByID(Destination);
                    list.Add(booking);
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

        public List<Booking> BookingInProgressClient(int idClient)
        {
            List<Booking> list = new List<Booking>();
            DataManager dataManager = new DataManager();
            CityBusiness ctBusines = new CityBusiness();

            try
            {

                dataManager.setQuery("SELECT * FROM Booking WHERE IdClient=@id AND StateBooking=@status" );
                dataManager.setParameter("@status", "En proceso");
                dataManager.setParameter("@id", idClient);
                dataManager.executeRead();
                while (dataManager.Lector.Read())
                {
                    Booking booking = new Booking();
                    booking.IdBooking = (int)(long)dataManager.Lector["IdBooking"];
                    booking.IdClient = (int)(long)dataManager.Lector["IdClient"];
                    int Origin = (int)(long)dataManager.Lector["IdOrigen"];
                    int Destination = (int)(long)dataManager.Lector["IdDestino"];
                    booking.SolicitudDate = (DateTime)dataManager.Lector["SolicitudDate"];
                    booking.DateBooking = (DateTime)dataManager.Lector["DateBooking"];
                    booking.Passengers = (short)dataManager.Lector["Passengers"];
                    booking.StateBooking = (string)dataManager.Lector["StateBooking"];
                    booking.State = (bool)dataManager.Lector["Estado"];
                    booking.Origin = ctBusines.GetCityByID(Origin);
                    booking.Destination = ctBusines.GetCityByID(Destination);
                    list.Add(booking);
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



        public void addBooking(Booking booking)
        {
            DataManager dataManager = new DataManager();

            try
            {

                dataManager.setQuery("INSERT INTO Booking(IdClient,IdOrigen,IdDestino,DateBooking,Passengers) VALUES (@IDCLIENT, @IDORIGEN,@IDDESTINO, @FECHARESERVA, @PASAJEROS)");
                dataManager.setParameter("@IDCLIENT", booking.IdClient );
                dataManager.setParameter("@IDORIGEN", booking.Origin.IdCity);
                dataManager.setParameter("@IDDESTINO", booking.Destination.IdCity);
                dataManager.setParameter("@PASAJEROS",booking.Passengers );
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

        public void editStatusRequestBooking(int IdBooking, string StatusRequest)
        {
            DataManager dataManager = new DataManager();

            try
            {
                dataManager.setQuery("UPDATE Booking SET StateBooking = @StatusBooking WHERE IdBooking = @IDBOOKING");
                dataManager.setParameter("@IDBOOKING", IdBooking);
                dataManager.setParameter("@StatusBooking", StatusRequest);
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

        public void ChangeStateBooking(int bookingId)
        {
            DataManager dataManager = new DataManager();

            try
            {
                dataManager.setQuery("UPDATE Booking SET StateBooking = 'Aprobada' WHERE IdBooking = @IDBOOKING");
                dataManager.setParameter("@IDBOOKING", bookingId);
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

