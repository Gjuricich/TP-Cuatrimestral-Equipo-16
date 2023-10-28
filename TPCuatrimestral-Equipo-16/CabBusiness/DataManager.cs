using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBusiness
{
    class DataManager
    {
        private SqlConnection conection;
        private SqlCommand command;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }
        public DataManager()
        {
            conection = new SqlConnection();
            command = new SqlCommand();
            conection.ConnectionString = "server=.\\SQLEXPRESS;database=CabWeb_DB;integrated security = true;";

        }
        public void setQuery(string consulta)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consulta;
        }
        public void setProcedure(string sp)
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = sp;
        }
        public void ClearCommand()
        {
            command.Parameters.Clear();
        }
        public void executeRead()
        {
            command.Connection = conection;
            try
            {
                conection.Open();
                lector = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void closeConection()
        {
            if (lector != null)
                lector.Close();
            conection.Close();
        }
        public void setParameter(string name, object value)
        {
            command.Parameters.AddWithValue(name, value);
        }
    }
}
