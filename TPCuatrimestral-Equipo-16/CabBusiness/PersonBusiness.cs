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
        private DataManager dataManager;

        public PersonBusiness()
        {
            dataManager = new DataManager();
        }

        public Person GetPersonById(int id)
        {
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
                person.Address = (string)dataManager.Lector["Domicilio"];
                person.Cellphone = (string)dataManager.Lector["Celular"];
                dataManager.closeConection();
                return person;
            }
            dataManager.closeConection();
            return null;
        }
    }
}
