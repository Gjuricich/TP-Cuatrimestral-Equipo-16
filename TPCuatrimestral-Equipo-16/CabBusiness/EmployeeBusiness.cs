using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabDominio;

namespace CabBusiness
{
    public class EmployeeBusiness
    {
        private DataManager dataManager;

        public EmployeeBusiness()
        {
            dataManager = new DataManager();
        }

        public Employee GetEmployeeById(int id)
        {

            Employee employee = new Employee();
            try
            {
                dataManager.setQuery("SELECT E.IdEmployee,E.JoinDate,E.Salary,E.Estado FROM Credentials C INNER JOIN Employees E ON C.Id = IdCredencial WHERE C.Id = @Id");
                dataManager.setParameter("@Id", id);
                dataManager.executeRead();

                if (dataManager.Lector.HasRows)
                {
                    dataManager.Lector.Read();
                    employee.IdEmployee = (int)(long)dataManager.Lector["IdEmployee"];
                    employee.JoinDate = (DateTime)dataManager.Lector["JoinDate"];
                    employee.Salary = (Decimal)dataManager.Lector["Salary"];
                    employee.State = (bool)dataManager.Lector["Estado"];
                    dataManager.closeConection();
                    return employee;
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
    }
}
