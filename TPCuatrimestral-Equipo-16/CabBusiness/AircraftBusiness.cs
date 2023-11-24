using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabDominio;

namespace CabBusiness
{
    public class AircraftBusiness
    {
        public List<Aircraft> List()
        {
            List<Aircraft> list = new List<Aircraft>();
            DataManager dataManager = new DataManager();

            try
            {
                dataManager.setQuery("SELECT IdAircraft,Model,PassengerCapacity, FuelCapacity,FlightRange,YearOfManufacture,Available,MinimumCrew FROM Aircraft where Estado = 1");
                dataManager.executeRead();
                while (dataManager.Lector.Read())
                {

                    /*
                          IdAircraft INT NOT NULL PRIMARY KEY IDENTITY(1,1),
                          Model VARCHAR(100) NOT NULL,
                          PassengerCapacity TINYINT NOT NULL,
                          MinimumCrew TINYINT NOT NULL,
                          FuelCapacity DECIMAL(10,2) NOT NULL,
                          FlightRange DECIMAL(10,2) NOT NULL,
                          YearOfManufacture DATETIME NOT NULL,
                          Available BIT NOT NULL DEFAULT(1),
                          Estado BIT NOT NULL DEFAULT(1)
                    */
                    Aircraft aircraft = new Aircraft();
                    aircraft.Id= (int)dataManager.Lector["IdAircraft"];
                    aircraft.Model= (string)dataManager.Lector["Model"];
                    aircraft.PassengerCapacity= Convert.ToInt32(dataManager.Lector["PassengerCapacity"]);
                    aircraft.MinimumCrew= Convert.ToInt32(dataManager.Lector["MinimumCrew"]); 
                    aircraft.FuelCapacity= (decimal)dataManager.Lector["FuelCapacity"];
                    aircraft.FlightRange= (decimal)dataManager.Lector["FlightRange"];
                    aircraft.YearOfManufacture= (DateTime)dataManager.Lector["YearOfManufacture"];
                    aircraft.Available= (bool)dataManager.Lector["Available"];
                    list.Add(aircraft);
                }

                return list;
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
