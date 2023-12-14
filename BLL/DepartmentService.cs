using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControl_Task.BLL
{
    internal class DepartmentService
    {
        private readonly DatabaseHelper db = DatabaseHelper.Instance;


        //Get All departments data including the employees in each department
        public List<Department> GetAllDepartmentsWithEmployees()
        {
            List<Department> departments = new List<Department>();

            using (SqlCommand cmd = new SqlCommand("SELECT d.Dnum, d.Dname, d.MGRSSN, d.MGRStart, e.SSN, e.Fname, e.Lname, e.Salary " +
                "FROM Departments d LEFT JOIN Employee e ON d.Dnum = e.Dno", db.connection))
            {
                db.OpenConnection();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int departmentId = reader.GetInt32(reader.GetOrdinal("Dnum"));

                    Department department = departments.FirstOrDefault(d => d.Id == departmentId);

                    if (department == null)
                    {
                        department = new Department
                        {
                            Id = departmentId,
                            Name = reader.GetString(reader.GetOrdinal("Dname")),
                            SSN = reader.GetInt32(reader.GetOrdinal("SSN")),
                            MGRStartdate = reader.GetDateTime(reader.GetOrdinal("MGRStart")),
                            employees = new List<Employee>()
                        };

                        departments.Add(department);
                    }

                    if (!reader.IsDBNull(reader.GetOrdinal("SSN")))
                    {
                        Employee employee = new Employee
                        {
                            SSN = reader.GetInt32(reader.GetOrdinal("SSN")),
                            Fname = reader.GetString(reader.GetOrdinal("Fname")),
                            Lname = reader.GetString(reader.GetOrdinal("Lname")),
                            Salary = reader.GetDecimal(reader.GetOrdinal("Salary")),
                        };

                        department.employees.Add(employee);
                    }
                }

                db.CloseConnection();
            }

            return departments;
        }
    }
}
