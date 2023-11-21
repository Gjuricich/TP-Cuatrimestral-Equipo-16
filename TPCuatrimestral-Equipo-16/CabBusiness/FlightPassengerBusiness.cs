using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabDominio;

namespace CabBusiness
{
    public class FlightPassengerBusiness
    {
        

        public List<FlightPassenger> List(int IdFlight)
        {
            List<FlightPassenger> list = new List<FlightPassenger>();
            DataManager dataManager = new DataManager();

            try
            {
                dataManager.setQuery("SELECT FP.IdPerson,FP.Estado, P.Nombre, P.Apellido, P.Sexo, P.DNI FROM FlightPassengers FP INNER JOIN Persons P ON FP.IdPerson = P.IdPerson WHERE FP.IdFlight = @IDFLIGHT");
                dataManager.setParameter("@IDFLIGHT", IdFlight);               
                dataManager.executeRead();
                while (dataManager.Lector.Read())
                {
                    FlightPassenger passenger = new FlightPassenger();
                    passenger.IdFlight = IdFlight;
                    passenger.IdPerson = (int)(long)dataManager.Lector["IdPerson"];
                    passenger.Status = (bool)dataManager.Lector["Estado"];
                    passenger.Name = (string)dataManager.Lector["Nombre"];
                    passenger.Surname = (string)dataManager.Lector["Apellido"];
                    passenger.Gender = Convert.ToChar(dataManager.Lector["Sexo"]);
                    passenger.Dni = (string)dataManager.Lector["DNI"];
                    list.Add(passenger);
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

        public void addPassenger(FlightPassenger passenger)
        {
            DataManager dataManager = new DataManager();
            PersonBusiness pBusiness = new PersonBusiness();

            try
            {
                //inserto una pasajero(persona) en la tabla personas
                pBusiness.addPassengerToPerson(passenger);
                passenger.IdPerson = pBusiness.findIdPerson(passenger.Dni);

                dataManager.setQuery("INSERT INTO FlightPassengers(IdPerson,IdFlight) VALUES (@Idperson, @IdFlight)");
                dataManager.setParameter("@Idperson", passenger.IdPerson);
                dataManager.setParameter("@IdFlight", passenger.IdFlight);     
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
