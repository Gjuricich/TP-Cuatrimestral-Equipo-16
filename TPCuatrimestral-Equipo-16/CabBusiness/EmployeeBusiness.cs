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
         

        public Employee GetEmployeeById(int id)
        {
            DataManager dataManager = new DataManager();
            Employee employee = new Employee();
            try
            {
                dataManager.setQuery("SELECT E.IdEmployee,E.JoinDate,E.Salary, PS.Position, E.Available,E.Estado FROM Credentials C INNER JOIN Employees E ON C.Id = IdCredencial INNER JOIN Positions PS ON E.IdPosition = PS.IdPosition WHERE C.Id = @Id");
                dataManager.setParameter("@Id", id);
                dataManager.executeRead();

                if (dataManager.Lector.HasRows)
                {
                    dataManager.Lector.Read();
                    employee.IdEmployee = (int)(long)dataManager.Lector["IdEmployee"];
                    employee.JoinDate = (DateTime)dataManager.Lector["JoinDate"];
                    employee.Position = (string)dataManager.Lector["Position"];
                    employee.Salary = (Decimal)dataManager.Lector["Salary"];
                    employee.Available = (bool)dataManager.Lector["Available"];
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
        public void updateAvailability(int idEmployee)
        {
            DataManager dataManager = new DataManager();
            Employee employee = new Employee();
            try
            {
                dataManager.setQuery("UPDATE Employees SET Available=1 WHERE IdEmployee = @Id");
                dataManager.setParameter("@Id", idEmployee);
                dataManager.executeRead();
                dataManager.closeConection();



            }
            catch (Exception ex)
            {
                dataManager.closeConection();
                throw ex;
            }



        }
    }
}
