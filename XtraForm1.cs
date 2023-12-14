using DataControl_Task.BLL;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataControl_Task
{
    public partial class XtraForm1 : DevExpress.XtraBars.TabForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {
            DepartmentService departmentService = new DepartmentService();

            Company_SDEntities company_SDEntities = new Company_SDEntities();
            employeeBindingSource.DataSource = company_SDEntities.Employees.ToList();
            departmentBindingSource.DataSource = company_SDEntities.Departments.ToList();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void tabFormControl1_Click(object sender, EventArgs e)
        {

        }
    }
}