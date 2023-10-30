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
        private DataManager dataManager;

        public ClientBusiness()
        {
            dataManager = new DataManager();
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
    }
}
