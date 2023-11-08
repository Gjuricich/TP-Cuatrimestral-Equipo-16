using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabDominio;

namespace CabBusiness
{
    public class CredentialBusiness
    {     
        public Credential GetUserByEmail(string email)
        {
            DataManager dataManager = new DataManager();
            Credential credential = new Credential();
            try
            {
                dataManager.ClearCommand();
                string consulta = "SELECT C.Id, C.IdPerson, R.Rol, C.Email, C.Sal, C.HashContraseña FROM Credentials C  INNER JOIN Roles R ON C.IdRol = R.IdRol WHERE Email = @Email";
                dataManager.setQuery(consulta);
                dataManager.setParameter("Email", email);
                dataManager.executeRead();

                if (dataManager.Lector.HasRows)
                {
                    dataManager.Lector.Read();
                    credential.IdCredential = (int)(long)dataManager.Lector["Id"];
                    credential.IdPerson = (int)(long)dataManager.Lector["IdPerson"];
                    credential.Rol = (string)dataManager.Lector["Rol"];
                    credential.Email = (string)dataManager.Lector["Email"];
                    credential.sethashPass((string)dataManager.Lector["HashContraseña"]);
                    credential.setsaltPass((string)dataManager.Lector["Sal"]);
                    dataManager.closeConection();
                    return credential;
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
        public bool VerificarCredenciales(string email, string password)
        {
            Credential credential = GetUserByEmail(email);
            if (credential != null)
            {
                string hashContraseñaProporcionada = credential.CalculteHashPass(password);
                return hashContraseñaProporcionada == credential.gethashPass();
            }
            return false;
        }

        public int findIdCredential(int idPerson)
        {
            DataManager dataManager = new DataManager();
            int aux;
            try
            {
                dataManager.setQuery("SELECT C.Id FROM Credentials C WHERE C.IdPerson = @IDPERSON");
                dataManager.setParameter("@IDPERSON", idPerson);
                dataManager.executeRead();
                dataManager.Lector.Read();
                aux = (int)(long)dataManager.Lector["Id"];
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


        public void addCredential(Client client, string password, int idPerson)
        {
            DataManager dataManager = new DataManager();
            client.credentials.GenerateHashAndSalt(password);

            try
            {
                dataManager.ClearCommand();
                dataManager.setQuery("INSERT INTO Credentials(IdPerson, IdRol, Email, HashContraseña, Sal) VALUES (@ID, @IDROL, @Email, @HashContraseña, @Sal)");
                dataManager.setParameter("@ID", idPerson);
                //MEGA HARDCODIADO
                dataManager.setParameter("@IDROL", 1);
                dataManager.setParameter("@Email", client.credentials.Email);
                dataManager.setParameter("@HashContraseña", client.credentials.gethashPass());
                dataManager.setParameter("@Sal", client.credentials.getsaltPass());
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
    }

}
 