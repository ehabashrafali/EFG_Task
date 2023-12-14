using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControl_Task.BLL
{
    public class EmployeeService
    {
        private readonly DatabaseHelper db = DatabaseHelper.Instance;

        //Get the Employees using department Id 
        public List<Employee> GetEmployeesByDepartment(int departmentID)
        {
            List<Employee> employees = new List<Employee>();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Employee WHERE Dno = @departmentID", db.connection))
            {
                cmd.Parameters.AddWithValue("@departmentID", departmentID);

                db.OpenConnection();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = new Employee
                    {
                        SSN = reader.GetInt32(reader.GetOrdinal("SSN")),
                        Fname = reader.GetString(reader.GetOrdinal("Fname")),
                        Lname = reader.GetString(reader.GetOrdinal("Lname")),
                        Salary = reader.GetDecimal(reader.GetOrdinal("Salary")),
                    };

                    employees.Add(employee);
                }

                db.CloseConnection();
            }

            return employees;
        }
    }
}
