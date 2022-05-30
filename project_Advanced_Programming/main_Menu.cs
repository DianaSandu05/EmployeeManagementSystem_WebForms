using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_Advanced_Programming
{
    public partial class main_Menu : Form
    {
       static public List<SalariedEmployees> list_salaried;
       static public List<HourlyEmployees> list_hourly;
       static public List<CommissionEmployees> list_commission;
        public main_Menu()
        {
            InitializeComponent();
            list_salaried = new List<SalariedEmployees>();
            list_hourly = new List<HourlyEmployees>();
            list_commission= new List<CommissionEmployees>();
        }
        private void main_Menu_Load(object sender, EventArgs e)
        {

        }
        private void AddEmpsBtn_Click(object sender, EventArgs e)
        {
            AddEmployee add_emps = new AddEmployee(this);
            this.Hide();
            add_emps.Show();
        }

        private void deleteEmpsBtn_Click(object sender, EventArgs e)
        {
            DeleteEmployees ve = new DeleteEmployees(this);
            this.Hide();
            ve.Show();
        }

        private void updateEmpsBtn_Click(object sender, EventArgs e)
        {
            UpdateEmployee update_emps = new UpdateEmployee(this);
            this.Hide();
            update_emps.Show();
        }

        private void viewEmpsBtn_Click(object sender, EventArgs e)
        {
            ViewEmployees emps_link = new ViewEmployees(this);
            this.Hide();
            emps_link.Show();
        }

        private void searchEmpsBtn_Click(object sender, EventArgs e)
        {
            SearchEmployees emps_link = new SearchEmployees(this);
            this.Hide();
            emps_link.Show();
        }

        private void printEmpsBtn_Click(object sender, EventArgs e)
        {
            EmployeesPayslips emps_payslips = new EmployeesPayslips(this);
            this.Hide();
            emps_payslips.Show();
        }
        
    }
}
