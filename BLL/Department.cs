using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControl_Task.BLL
{
    public class Department
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? SSN { get; set; }

        public DateTime? MGRStartdate { get; set; }

        public List<Employee> employees { get; set; }

        public Department()
        {
            employees = new List<Employee>();
        }
    }
}
