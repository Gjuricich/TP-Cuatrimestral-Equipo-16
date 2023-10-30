using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CabDominio
{
    public class Credentials
    {
        public int IdPerson { get; set; }
        public int IdRol { get; set; }
        public string Email { get; set; }
        private string hashPass;
        private string saltPass;

        public string gethashPass()
        {
            return hashPass;
        }
        public string getsaltPass()
        {
            return saltPass;
        }
        public void sethashPass(string hash)
        {
            hashPass = hash;
        }
        public void setsaltPass(string salt)
        {
            saltPass = salt;

        }
        public string GenerateRandomSalt(int longitud)
        {
            const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var randomBytes = new byte[longitud];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }
            var sal = new StringBuilder(longitud);
            foreach (var byteAleatorio in randomBytes)
            {
                sal.Append(caracteresPermitidos[byteAleatorio % caracteresPermitidos.Length]);
            }
            return sal.ToString();
        }

        public string CalculteHashPass(string password)
        {
            string contraseñaSalteada = password + getsaltPass();
            // Calcula el hash de la contraseña con la salt.
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(contraseñaSalteada);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
        public void GenerateHashAndSalt(string password)
        {
            setsaltPass(GenerateRandomSalt(10));
            sethashPass(CalculteHashPass(password));
        }
    }
}
