using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace CabDominio
{
    public class Client : Person
    {
        public DateTime DateOfRegister { get; set; }
        public DateTime DateOfBirth { get; set; }
        public UrlImage ProfilePhoto { get; set; }
        public List<Flight> FlightHistory { get; set; }

        private int Id;

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
        public int getIdUser()
        {
            return Id;
        }
        public void setIdUser(int id)
        {
            Id = id;
        }
        public void sethashPass(string hash)
        {
            hashPass = hash;
        }
        public void setsaltPass(string salt)
        {
            saltPass = salt;

        }
        public Client()
        {
        }
        public Client(string name, string lastName, string email, DateTime dateOfRegister, DateTime dateOfBirth, char gender)
        {
            Name = name;
            Surname = lastName;
            Email = email;
            DateOfRegister = dateOfRegister;
            DateOfBirth = dateOfBirth;
            Gender = gender;
        }
        public void loadUserPropertysFromDb(int id, string name, string lastName, string email, DateTime dateOfRegister, DateTime dateOfBirth, string hash, string salt)
        {
            Id = id;
            Name = name;
            Surname = lastName;
            Email = email;
            DateOfRegister = dateOfRegister;
            DateOfBirth = dateOfBirth;
            setsaltPass(salt);
            sethashPass(hash);
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