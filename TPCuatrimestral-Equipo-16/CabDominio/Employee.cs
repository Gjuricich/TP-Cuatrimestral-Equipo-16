using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabDominio
{
    public class Employee : Person
    {
        public int IdEmployee { get; set; }
        public DateTime JoinDate {get; set;}        
        public decimal Salary {get; set;}
        public bool State {get; set;}
        public int IdRol {get; set;}
        public Credential credentials { get; set; }

        public Employee()
        {
            credentials = new Credential();
          
        }

    }
}
