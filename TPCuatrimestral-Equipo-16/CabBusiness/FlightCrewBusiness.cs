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
        public List<FlightCrew> List()
        {
            List<FlightCrew> list = new List<FlightCrew>();
            DataManager dataManager = new DataManager();

            try
            {
                dataManager.setQuery("SELECT FC.IdEmployee,FC.IdFlight, PS.Position, P.Nombre, P.Apellido, P.Sexo, P.DNI, E.Available, FC.Estado FROM FlightCrew FC INNER JOIN Employees E ON FC.IdEmployee = E.IdEmployee INNER JOIN Positions PS ON E.IdPosition = PS.IdPosition LEFT JOIN Credentials C ON E.IdCredencial = C.Id LEFT JOIN Persons P ON C.IdPerson = P.IdPerson WHERE PS.Position IN('Pilot','Flight Attendant') AND E.Available =1");
                dataManager.executeRead();
                while (dataManager.Lector.Read())
                {
                    FlightCrew crewMember = new FlightCrew();
                    crewMember.IdEmployee = (int)(long)dataManager.Lector["IdEmployee"];
                    crewMember.Status = (bool)dataManager.Lector["Estado"];
                    crewMember.Available = (bool)dataManager.Lector["Available"];
                    crewMember.Position = (string)dataManager.Lector["Position"];
                    crewMember.Name = (string)dataManager.Lector["Nombre"];
                    crewMember.Surname = (string)dataManager.Lector["Apellido"];
                    crewMember.Dni = (string)dataManager.Lector["DNI"];
                    crewMember.Gender = Convert.ToChar(dataManager.Lector["Sexo"]);
                    list.Add(crewMember);
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
        public List<FlightCrew> List(int IdFlight)
        {
            List<FlightCrew> list = new List<FlightCrew>();
            DataManager dataManager = new DataManager();

            try
            {
                dataManager.setQuery("SELECT FC.IdEmployee,FC.IdFlight, PS.Position, P.Nombre, P.Apellido, P.Sexo, P.DNI, E.Available, FC.Estado FROM FlightCrew FC INNER JOIN Employees E ON FC.IdEmployee = E.IdEmployee INNER JOIN Positions PS ON E.IdPosition = PS.IdPosition LEFT JOIN Credentials C ON E.IdCredencial = C.Id LEFT JOIN Persons P ON C.IdPerson = P.IdPerson WHERE FC.IdFlight = @IDFLIGHT");
                dataManager.setParameter("@IDFLIGHT", IdFlight);
                dataManager.executeRead();
                while (dataManager.Lector.Read())
                {
                    FlightCrew crewMember = new FlightCrew();
                    crewMember.IdFlight = IdFlight;
                    crewMember.IdEmployee = (int)(long)dataManager.Lector["IdEmployee"];
                    crewMember.Status = (bool)dataManager.Lector["Estado"];
                    crewMember.Available = (bool)dataManager.Lector["Available"];
                    crewMember.Position = (string)dataManager.Lector["Position"];
                    crewMember.Name = (string)dataManager.Lector["Nombre"];
                    crewMember.Surname = (string)dataManager.Lector["Apellido"];
                    crewMember.Dni = (string)dataManager.Lector["DNI"];
                    crewMember.Gender = Convert.ToChar(dataManager.Lector["Sexo"]);
                    list.Add(crewMember);
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
                UpdateCrewMemberAvailable(IdEmployee, 1);

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

        public void UpdateCrewMemberAvailable(int IdEmployee, int available)
        {
            DataManager dataManager = new DataManager();

            try
            {

                dataManager.setQuery("UPDATE Employees SET Available = @available WHERE IdEmployee  = @IdEmployee");
                dataManager.setParameter("@IdEmployee", IdEmployee);
                dataManager.setParameter("@available", available);
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
