using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabDominio;

namespace CabBusiness
{
    public class FlightCrewBusiness
    {


        /*
        public List<FlightCrewBusiness> List(int IdFlight)
        {
            List<FlightCrewBusiness> list = new List<FlightCrewBusiness>();
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
        */







        public void addCrewMember(FlightCrew member)
        {
            DataManager dataManager = new DataManager();
    

            try
            {  
                dataManager.setQuery("INSERT INTO FlightCrew(IdEmployee,IdFlight) VALUES (@IdEmployee, @IdFlight)");
                dataManager.setParameter("@IdEmployee", member.IdEmployee);
                dataManager.setParameter("@IdFlight", member.IdFlight);
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



        public void deleteCrewMember(int IdEmployee)
        {
            DataManager dataManager = new DataManager();

            try
            {

                dataManager.setQuery("DELETE from FlightCrew  WHERE IdEmployee = @IdEmployee");
                dataManager.setParameter("@IdEmployee", IdEmployee);
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
