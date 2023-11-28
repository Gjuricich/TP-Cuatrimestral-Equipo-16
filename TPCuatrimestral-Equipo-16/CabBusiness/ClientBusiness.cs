using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabDominio;

namespace CabBusiness
{
    public class ClientBusiness
    {
        public Client GetClientById(int id)
        {
            DataManager dataManager = new DataManager();
            Client client = new Client();
            try
            {
                dataManager.setQuery("SELECT C.IdClient ,C.JoinDate, C.Estado FROM Credentials Cre INNER JOIN Client C ON Cre.Id = C.IdCredencial WHERE Cre.Id = @Id");
                dataManager.setParameter("@Id", id);
                dataManager.executeRead();

                if (dataManager.Lector.HasRows)
                {
                    dataManager.Lector.Read();
                    client.IdClient = (int)(long)dataManager.Lector["IdClient"];
                    client.DateOfRegister = (DateTime)dataManager.Lector["JoinDate"];
                    client.State = (bool)dataManager.Lector["Estado"];
                    dataManager.closeConection();
                    return client;
                }
                dataManager.closeConection();

                return null;

            }
            catch (Exception ex)
            {
                dataManager.closeConection();
                throw ex;
            }

        }

        public void AddNewUserDB(Client client, string password)
        {
            DataManager dataManager = new DataManager();
            CredentialBusiness cBusiness = new CredentialBusiness();
            PersonBusiness pBusiness = new PersonBusiness();
            int idPerson;
            int idCredencial;


            try
            {
                //inserto una cliente(persona) en la tabla personas
                pBusiness.addPerson(client);
                //hallo el id que se generó en la tabla personas con DNI del cliente
                idPerson = pBusiness.findIdPerson(client.Dni);
                //Inserto las credenciales en la tabla de credenciales
                cBusiness.addCredential(client, password, idPerson);
                // hallo id de credencial creada para insertar el cliente
                idCredencial = cBusiness.findIdCredential(idPerson);


                //Ahora si, inserto el cliente           
                dataManager.setQuery("INSERT INTO Client(IdCredencial, JoinDate) VALUES (@ID, @Joindate)");
                dataManager.setParameter("@ID", idCredencial);
                dataManager.setParameter("@Joindate", client.DateOfRegister);
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

        public void AddNewUserDB(Client client, string password,string photo)
        {
            DataManager dataManager = new DataManager();
            CredentialBusiness cBusiness = new CredentialBusiness();
            PersonBusiness pBusiness = new PersonBusiness();
            int idPerson;
            int idCredencial;


            try
            {
                //inserto una cliente(persona) en la tabla personas
                pBusiness.addPerson(client);
                //hallo el id que se generó en la tabla personas con DNI del cliente
                idPerson = pBusiness.findIdPerson(client.Dni);
                //Inserto las credenciales en la tabla de credenciales
                cBusiness.addCredential(client, password, idPerson,photo);
                // hallo id de credencial creada para insertar el cliente
                idCredencial = cBusiness.findIdCredential(idPerson);


                //Ahora si, inserto el cliente           
                dataManager.setQuery("INSERT INTO Client(IdCredencial, JoinDate) VALUES (@ID, @Joindate)");
                dataManager.setParameter("@ID", idCredencial);
                dataManager.setParameter("@Joindate", client.DateOfRegister);
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

        public void deleteClient(int idClient, int idPerson, string DNI)
        {
            DataManager data = new DataManager();
            PersonBusiness pBusiness = new PersonBusiness();
            CredentialBusiness cBusiness = new CredentialBusiness();
            try
            {

                data.setQuery("DELETE from Client WHERE IdClient = @ID");
                data.setParameter("@ID", idClient);
                data.executeRead();
                data.closeConection();
                cBusiness.deleteCredential(idPerson);//conflict forain key id person
                pBusiness.deletePerson(DNI);


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

        public void deleteClientOfBooking(int idClient)
        {
            DataManager data = new DataManager();
  
            try
            {

                data.setQuery("UPDATE Booking SET IdClient = NULL WHERE IdClient = @ID");
                data.setParameter("@ID", idClient);
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





        /*
        public List<Client> GetAllUsers()
        {
            List<Client> clients = new List<Client>();

            dataManager.setQuery("SELECT * FROM Credenciales");
            dataManager.executeRead();

            while (dataManager.Lector.Read())
            {

                Client client = new Client();
                client.credentials.IdPerson = (int)dataManager.Lector["Id"];
                client.Name = (string)dataManager.Lector["Nombre"];
                client.Surname = (string)dataManager.Lector["Apellido"];
                client.DateOfBirth = (DateTime)dataManager.Lector["FechaNacimiento"];
                client.DateOfRegister = (DateTime)dataManager.Lector["FechaRegistro"];
                client.Email = (string)dataManager.Lector["CorreoElectronico"];
                client.credentials.sethashPass((string)dataManager.Lector["HashContraseña"]);
                client.credentials.setsaltPass((string)dataManager.Lector["Sal"]);
                string g = (string)dataManager.Lector["Sexo"];
                client.Gender = g[0];
                DateTime birth = (DateTime)dataManager.Lector["FechaNacimiento"];
                clients.Add(client);
            }

            dataManager.closeConection();
            return clients;
        }
        public bool VerificarContraseña(string contraseñaProporcionada, Client client)
        {
            string hashContraseñaProporcionada = client.credentials.CalculteHashPass(contraseñaProporcionada);
            return hashContraseñaProporcionada == client.credentials.gethashPass();
        }
        public void AddNewUser(Client client,string password)
        {
            // Genera una nueva sal para el usuario.
            client.credentials.GenerateHashAndSalt(password);

            // Calcula el hash de la contraseña con la nueva sal.
            string hashContraseña = client.credentials.CalculteHashPass(password);
            dataManager.ClearCommand();
            dataManager.setQuery("INSERT INTO Credenciales(Nombre, Apellido, FechaNacimiento, CorreoElectronico, Sexo, HashContraseña, Sal, FechaRegistro) VALUES (@Nombre, @Apellido, @FechaNacimiento, @CorreoElectronico, @Sexo, @HashContraseña, @Sal, @FechaRegistro)");
            dataManager.setParameter("@Nombre", client.Name);
            dataManager.setParameter("@Apellido", client.Surname);
            dataManager.setParameter("@FechaNacimiento", client.DateOfBirth);
            dataManager.setParameter("@CorreoElectronico", client.Email);
            dataManager.setParameter("@Sexo", client.Gender);
            dataManager.setParameter("@HashContraseña", hashContraseña);
            dataManager.setParameter("@Sal", client.credentials.getsaltPass());
            dataManager.setParameter("@FechaRegistro", client.DateOfRegister);
            dataManager.executeRead();
            dataManager.closeConection();
        }


           public Client GetUserById(int id)
        {
            dataManager.setQuery("SELECT * FROM Credenciales WHERE Id = @Id");
            dataManager.setParameter("@Id", id);
            dataManager.executeRead();

            if (dataManager.Lector.HasRows)
            {
                dataManager.Lector.Read();
                Client client = new Client();               
                client.credentials.IdPerson = (int)dataManager.Lector["Id"];
                client.Name = (string)dataManager.Lector["Nombre"];
                client.Surname = (string)dataManager.Lector["Apellido"];
                client.DateOfBirth = (DateTime)dataManager.Lector["FechaNacimiento"];
                client.DateOfRegister = (DateTime)dataManager.Lector["FechaRegistro"];
                client.Email = (string)dataManager.Lector["CorreoElectronico"];
                client.credentials.sethashPass((string)dataManager.Lector["HashContraseña"]);
                client.credentials.setsaltPass((string)dataManager.Lector["Sal"]);
                string g = (string)dataManager.Lector["Sexo"];
                client.Gender = g[0];
                DateTime birth = (DateTime)dataManager.Lector["FechaNacimiento"];
                dataManager.closeConection();
                return client;
            }
            dataManager.closeConection();
            return null;
        }

        public Client GetUserByEmail(string email)
        {

            dataManager.ClearCommand();
            string consulta = "SELECT * FROM Credenciales WHERE CorreoElectronico = @Email";
            dataManager.setQuery(consulta);
            dataManager.setParameter("Email", email);
            dataManager.executeRead();

            if (dataManager.Lector.HasRows)
            {
                dataManager.Lector.Read();
                Client client = new Client();
                client.credentials.IdPerson = (int)dataManager.Lector["Id"];
                client.Name = (string)dataManager.Lector["Nombre"];
                client.Surname = (string)dataManager.Lector["Apellido"];
                client.DateOfBirth = (DateTime)dataManager.Lector["FechaNacimiento"];
                client.DateOfRegister = (DateTime)dataManager.Lector["FechaRegistro"];
                client.Email = (string)dataManager.Lector["CorreoElectronico"];
                client.credentials.sethashPass((string)dataManager.Lector["HashContraseña"]);
                client.credentials.setsaltPass((string)dataManager.Lector["Sal"]);
                string g = (string)dataManager.Lector["Sexo"];
                client.Gender = g[0];
                DateTime birth = (DateTime)dataManager.Lector["FechaNacimiento"];
                dataManager.closeConection();
                return client;
            }
            dataManager.closeConection();
            return null;
        }
        public bool VerificarCredenciales(string email, string password)
        {
            Client user = GetUserByEmail(email);
            if (user != null)
            {
                string hashContraseñaProporcionada = user.credentials.CalculteHashPass(password);
                return hashContraseñaProporcionada == user.credentials.gethashPass();
            }
            return false;
        }
        */
    }
}
