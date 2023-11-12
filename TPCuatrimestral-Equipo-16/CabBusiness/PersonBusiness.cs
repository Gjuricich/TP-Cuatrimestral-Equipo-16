using System;
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
            dataManager.setQuery("SELECT P.Apellido, P.Nombre, P.FechaNacimiento, P.Sexo, P.DNI, P.Domicilio, P.Celular FROM Credentials C INNER JOIN Persons P ON C.IdPerson = P.IdPerson WHERE C.Id = @Id");
            dataManager.setParameter("@Id", id);
            dataManager.executeRead();

            if (dataManager.Lector.HasRows)
            {
                dataManager.Lector.Read();
                Person person = new Person();
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



        public void addPerson(Client client)
        {
            DataManager dataManager = new DataManager();
    
            try
            {
                dataManager.ClearCommand();
                dataManager.setQuery("INSERT INTO Persons (Nombre, Apellido, Sexo, DNI, FechaNacimiento, Celular) VALUES (@Nombre, @Apellido,@Sexo,  @DNI, @FechaNacimiento, @Celular)");
                dataManager.setParameter("@Nombre", client.Name);
                dataManager.setParameter("@Apellido", client.Surname);
                dataManager.setParameter("@Sexo", client.Gender);
                dataManager.setParameter("@DNI", client.Dni);
                dataManager.setParameter("@FechaNacimiento", client.DateOfBirth);
                dataManager.setParameter("@Celular", client.Cellphone);
                dataManager.executeRead();
                dataManager.closeConection();               
                
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

        public void editPerson(Client client)
        {
            DataManager dataManager = new DataManager();

            try
            {
                dataManager.setQuery("UPDATE Persons SET Domicilio = @Domicilio, Celular = @Celular WHERE IdPerson = @IDPERSON");
                dataManager.setParameter("@Domicilio", client.Address);
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
