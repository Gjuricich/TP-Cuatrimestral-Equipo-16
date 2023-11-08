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
        private DataManager dataManager;

        public CredentialBusiness()
        {
            dataManager = new DataManager();
        }


        public Credential GetUserByEmail(string email)
        {
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
    }

}
 