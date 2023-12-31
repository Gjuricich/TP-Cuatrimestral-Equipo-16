﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabDominio;

namespace CabBusiness
{
    public class PersonBusiness 
    {
        public Person GetPersonById(int id)
        {
            DataManager dataManager = new DataManager();
            dataManager.setQuery("SELECT P.Apellido, P.IdPerson, P.Nombre, P.FechaNacimiento, P.Sexo, P.DNI, P.Domicilio, P.Celular FROM Credentials C INNER JOIN Persons P ON C.IdPerson = P.IdPerson WHERE C.Id = @Id");
            dataManager.setParameter("@Id", id);
            dataManager.executeRead();

            if (dataManager.Lector.HasRows)
            {
                dataManager.Lector.Read();
                Person person = new Person();
                person.IdPerson = (int)(long)dataManager.Lector["IdPerson"];
                person.Name = (string)dataManager.Lector["Nombre"];
                person.Surname = (string)dataManager.Lector["Apellido"];
                person.Gender = Convert.ToChar(dataManager.Lector["Sexo"]);
                person.Dni = (string)dataManager.Lector["DNI"];
                person.DateOfBirth = (DateTime)dataManager.Lector["FechaNacimiento"];
                if ((string)dataManager.Lector["Domicilio"] == null) {
                    person.Address = "";
                }
                else
                {
                    person.Address = (string)dataManager.Lector["Domicilio"];
                }
                person.Cellphone = (string)dataManager.Lector["Celular"];
                dataManager.closeConection();
                return person;
            }
            dataManager.closeConection();
            return null;
        }

        public int findIdPerson(string DNI)
        {
            DataManager dataManager = new DataManager();
            int aux;
            try
            {
                dataManager.setQuery("SELECT P.IdPerson FROM Persons P WHERE P.DNI = @DNI");
                dataManager.setParameter("@DNI", DNI);
                dataManager.executeRead();
                dataManager.Lector.Read();
                aux = (int)(long)dataManager.Lector["IdPerson"];
                dataManager.closeConection();
                return aux;
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

        public bool ExistPerson(string DNI, string Cellphone, string email)
        {
            DataManager dataManager = new DataManager();
            bool exists = false; 

            try
            {
                dataManager.setQuery("SELECT P.IdPerson FROM Persons P INNER JOIN Credentials C ON C.IdPerson = P.IdPerson WHERE P.DNI = @DNI OR  P.Celular =  @Cellphone OR C.Email = @Email");
                dataManager.setParameter("@DNI", DNI);
                dataManager.setParameter("@Cellphone", Cellphone);
                dataManager.setParameter("@Email", email);
                dataManager.executeRead();
                
                if (dataManager.Lector.HasRows)
                {
                    dataManager.Lector.Read();

                    if(dataManager.Lector["IdPerson"] != null)
                    {
                        exists = true;
                        
                    }
                }

                return exists;

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



        public void addPerson(Client client)
        {
            DataManager dataManager = new DataManager();
    
            try
            {
       
                dataManager.setQuery("INSERT INTO Persons (Nombre, Apellido, Sexo, DNI, FechaNacimiento,Celular, Domicilio ) VALUES (@Nombre, @Apellido,@Sexo,  @DNI, @FechaNacimiento, @Celular, @Domicilio)");
                dataManager.setParameter("@Nombre", client.Name);
                dataManager.setParameter("@Apellido", client.Surname);
                dataManager.setParameter("@Sexo", client.Gender);
                dataManager.setParameter("@DNI", client.Dni);
                dataManager.setParameter("@Domicilio", client.Address);
                dataManager.setParameter("@FechaNacimiento", client.DateOfBirth);
                dataManager.setParameter("@Celular", client.Cellphone);
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


        public void addPassengerToPerson(FlightPassenger passenger)
        {
            DataManager dataManager = new DataManager();

            try
            {
                dataManager.setQuery("INSERT INTO Persons (Nombre, Apellido, Sexo, DNI, FechaNacimiento,Celular, Domicilio ) VALUES (@Nombre, @Apellido,@Sexo,  @DNI, @FechaNacimiento, @Celular, @Domicilio)");
                dataManager.setParameter("@Nombre", passenger.Name);
                dataManager.setParameter("@Apellido", passenger.Surname);
                dataManager.setParameter("@Sexo", passenger.Gender);
                dataManager.setParameter("@DNI", passenger.Dni);
                dataManager.setParameter("@Domicilio", "");
                dataManager.setParameter("@FechaNacimiento", "1985-03-20");
                dataManager.setParameter("@Celular", passenger.Cellphone);
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

        public void UpdatePassengerToPerson(FlightPassenger passenger)
        {
            DataManager dataManager = new DataManager();

            try
            {
                dataManager.setQuery("UPDATE Persons SET Nombre= @Nombre, Apellido= @Apellido, Sexo= @Sexo, DNI = @DNI WHERE IdPerson = @IdPerson");
                dataManager.setParameter("@IdPerson", passenger.IdPerson);
                dataManager.setParameter("@Nombre", passenger.Name);
                dataManager.setParameter("@Apellido", passenger.Surname);
                dataManager.setParameter("@Sexo", passenger.Gender);
                dataManager.setParameter("@DNI", passenger.Dni);
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

        public void editPerson(Person person)
        {
            DataManager dataManager = new DataManager();

            try
            {
                dataManager.setQuery("UPDATE Persons SET Domicilio = @Domicilio, Celular = @Celular, Nombre = @Nombre, Apellido =@Apellido, Sexo = @Sexo WHERE DNI = @DNI or IdPerson = @IDPERSON");
                dataManager.setParameter("@IDPERSON", person.IdPerson);
                dataManager.setParameter("@DNI", person.Dni);
                dataManager.setParameter("@Celular", person.Cellphone);
                dataManager.setParameter("@Domicilio", person.Address);
                dataManager.setParameter("@Nombre", person.Name);
                dataManager.setParameter("@Apellido", person.Surname);
                dataManager.setParameter("@Sexo", person.Gender);
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

        public void deletePerson(string DNI)
        {
            DataManager data = new DataManager();
            try
            {

                data.setQuery("DELETE from Persons WHERE DNI = @DNI");
                data.setParameter("@DNI", DNI);
                data.executeRead();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.closeConection();
            }
        }


    }

}
