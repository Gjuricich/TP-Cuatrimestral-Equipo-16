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
        public int IdClient { get; set; }
        public bool State { get; set; }
        public Credential credentials { get; set; }
        public DateTime DateOfRegister { get; set; }
        public UrlImage ProfilePhoto { get; set; }
        public List<Flight> FlightHistory { get; set; }

        public Client()
        {
            credentials = new Credential();
            FlightHistory = new List<Flight>();
            ProfilePhoto = new UrlImage();
        }
        public Client(string name, string lastName, string email, DateTime dateOfRegister, DateTime dateOfBirth, char gender)
        {
            Name = name;
            Surname = lastName;
            Email = email;
            DateOfRegister = dateOfRegister;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            credentials = new Credential();
            FlightHistory = new List<Flight>();
            ProfilePhoto = new UrlImage();
        }
    
        
    }
}