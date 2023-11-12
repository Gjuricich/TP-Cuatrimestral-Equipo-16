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
                string consulta = "SELECT C.Id, C.IdPerson, R.Rol, C.Email, C.Sal, C.HashContraseña,C.ImageProfile FROM Credentials C  INNER JOIN Roles R ON C.IdRol = R.IdRol WHERE Email = @Email";
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
                    credential.Photo = (string)dataManager.Lector["ImageProfile"];
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
                dataManager.setQuery("INSERT INTO Credentials(IdPerson, IdRol, Email, HashContraseña, Sal) VALUES (@ID, @IDROL, @Email, @HashContraseña,@Sal)");
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
        public void addCredential(Client client, string password, int idPerson,string photo)
        {
            DataManager dataManager = new DataManager();
            client.credentials.GenerateHashAndSalt(password);

            try
            {
                dataManager.ClearCommand();
                dataManager.setQuery("INSERT INTO Credentials(IdPerson, IdRol, Email, HashContraseña, Sal,ImageProfile) VALUES (@ID, @IDROL, @Email, @HashContraseña,@Sal,@Photo)");
                dataManager.setParameter("@ID", idPerson);
                //MEGA HARDCODIADO
                dataManager.setParameter("@IDROL", 1);
                dataManager.setParameter("@Email", client.credentials.Email);
                dataManager.setParameter("@HashContraseña", client.credentials.gethashPass());
                dataManager.setParameter("@Sal", client.credentials.getsaltPass());
                dataManager.setParameter("@Photo", photo);
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

        public void editCredential(Client client)
        {
            DataManager dataManager = new DataManager();

            try
            {   /* aca deberiamos actualizar la contraseña
                dataManager.setQuery("UPDATE Credentials SET Domicilio = @Domicilio, Celular = @Celular WHERE IdPerson = @IDPERSON");
                dataManager.setParameter("@Domicilio", client.Address);
                dataManager.setParameter("@Celular", client.Cellphone);
                dataManager.executeRead();
                */
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


        public void deleteCredential(int idPerson)
        {
            DataManager data = new DataManager();
            try
            {

                data.setQuery("DELETE from Credentials WHERE IdPerson = @IDPERSON");     
                data.setParameter("@IDPERSON", idPerson);
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
        public void ChangePhoto(string route, int IdCredential)
        {
            DataManager data = new DataManager();
            try
            {
                data.setQuery("UPDATE Credentials SET ImageProfile = @Route WHERE Id = @ID");
                data.setParameter("@Route", route);
                data.setParameter("@ID", IdCredential);
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
        public string getPhoto(int IdCredential)
        {

            string photo;
            DataManager data = new DataManager();
            try
            {
                data.setQuery("Select ImageProfile from Credentials  WHERE Id = @ID");
                data.setParameter("@ID", IdCredential);
                data.executeRead();
                data.Lector.Read();
                photo= (string)data.Lector["ImageProfile"];
                return photo;
                
            }
            catch (Exception ex)
            {
                return "";
            }
            finally
            {
                data.closeConection();
            }
        }

    }

}
 