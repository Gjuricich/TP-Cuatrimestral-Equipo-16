using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabDominio;

namespace CabBusiness
{
    public class ProvinceBusiness
    {

        public List<Province>List()
        {
            List<Province> list = new List<Province>();
            DataManager dataManager = new DataManager();

            try
            {

                dataManager.setQuery("SELECT IdProvincia, NombreProvincia,Estado FROM PROVINCIAS");
                dataManager.executeRead();
                while (dataManager.Lector.Read())
                {
                    Province province = new Province();
                    province.IdProvince = (int)(long)dataManager.Lector["IdProvincia"];
                    province.NameProvince = (string)dataManager.Lector["NombreProvincia"];
                    province.State = (bool)dataManager.Lector["Estado"];

                    list.Add(province);
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
