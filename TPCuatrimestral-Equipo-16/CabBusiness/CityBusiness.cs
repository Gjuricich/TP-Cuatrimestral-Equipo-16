using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabDominio;

namespace CabBusiness
{
    public class CityBusiness
    {
        public List<City> List()
        {
            List<City> list = new List<City>();
            DataManager dataManager = new DataManager();

            try
            {

                dataManager.setQuery("SELECT IdCiudad,IdProvincia, NombreCiudad,Estado FROM CIUDADES");
                dataManager.executeRead();
                while (dataManager.Lector.Read())
                {
                    City city = new City();
                    city.IdCity = (int)(long)dataManager.Lector["IdCiudad"];
                    city.IdProvince = (int)(long)dataManager.Lector["IdProvincia"];
                    city.NameCity = (string)dataManager.Lector["NombreCiudad"];
                    city.State = (bool)dataManager.Lector["Estado"];

                    list.Add(city);
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
