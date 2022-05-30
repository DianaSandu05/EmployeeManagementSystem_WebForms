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
    public partial class ViewEmployees : Form
    { int emps_type;
        int position;
        main_Menu emps_transfer;
        public ViewEmployees(main_Menu emp)
        {
            emps_transfer = emp;
            InitializeComponent();
            position = 0;
        }
        private void cmb_staff_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            position = 0;
            emps_type = cmb_staff_type.SelectedIndex;
            if (emps_type==0)
            {
                salaryEmps(position);
            }

            if (emps_type ==1)
            {
                hourlyEmps(position);
            }

            if (emps_type ==2)
            {
                commissionEmps(position);
            }
        }
        void commissionEmps(int position)
        {
            if (main_Menu.list_commission.Count > 0)
            {
                CommissionEmployees commission_emps = new CommissionEmployees();
                commission_emps = main_Menu.list_commission[position];
                empFirstName.Text = commission_emps.Firstname;
                empLastName.Text = commission_emps.Lastname;
                cmb_gender.Text = commission_emps.Gender;
                dtp_dob.Value = commission_emps.Dob;
                empAddress.Text = commission_emps.Address;
                empContactNo.Text = commission_emps.Phone;
                empNiNo.Text = commission_emps.NiNo;
                empDepartment.Text = commission_emps.Department;
                empSales.Text = commission_emps.Sales.ToString();
                empCmsRates.Text = commission_emps.Rate.ToString();
                //txt_rate.Text = hs.Hourly_rate.ToString();
                //txt_hours_worked.Text = hs.Hours.ToString();
                empSalary.Text = commission_emps.Base_salary.ToString();
                pb_picture.Image = new Bitmap(commission_emps.Picture);
            }
            else
                MessageBox.Show("No records are there");
        }
        void hourlyEmps (int position)
        {
            if (main_Menu.list_hourly.Count > 0)
            {
                HourlyEmployees hourly_emps = main_Menu.list_hourly[position];
                empFirstName.Text = hourly_emps.Firstname;
                empLastName.Text = hourly_emps.Lastname;
                cmb_gender.Text = hourly_emps.Gender;
                dtp_dob.Value = hourly_emps.Dob;
                empAddress.Text = hourly_emps.Address;
                empDepartment.Text = hourly_emps.Department;
                empNiNo.Text = hourly_emps.NiNo;
                empContactNo.Text = hourly_emps.Phone;
                empHoursRate.Text = hourly_emps.Hourly_rate.ToString();
                empHoursWorked.Text = hourly_emps.Hours.ToString();
                // txt_salary.Text = ss.Salary.ToString();
                pb_picture.Image = new Bitmap(hourly_emps.Picture);
            }
            else
                MessageBox.Show("No records are there");
        }
        
        void salaryEmps(int position)
        {
            if (main_Menu.list_salaried.Count > 0)
            {
                SalariedEmployees salaried_emps = main_Menu.list_salaried[position];
                empFirstName.Text = salaried_emps.Firstname;
                empLastName.Text = salaried_emps.Lastname;
                cmb_gender.Text = salaried_emps.Gender;
                dtp_dob.Value = salaried_emps.Dob;
                empAddress.Text = salaried_emps.Address;
                empContactNo.Text = salaried_emps.Phone;
                empDepartment.Text = salaried_emps.Department;
                empNiNo.Text = salaried_emps.NiNo;
                empSalary.Text = salaried_emps.Salary.ToString();
                pb_picture.Image = new Bitmap(salaried_emps.Picture);
            }
            else
                MessageBox.Show("No records are there");
        }
        private void btn_right_Click(object sender, EventArgs e)
        {
            if (cmb_staff_type.SelectedIndex == -1)
                MessageBox.Show("You need to select the staff type");
            else
            {
                position++;
                if (emps_type == 0 && position < main_Menu.list_salaried.Count())
                    salaryEmps(position);
                else
                    MessageBox.Show("No more elements");
                if (emps_type == 1 && position < main_Menu.list_hourly.Count())
                    hourlyEmps(position);
                else
                    MessageBox.Show("No more elements");

                if (emps_type == 2 && position < main_Menu.list_commission.Count())
                    commissionEmps(position);
                else
                    MessageBox.Show("No more elements");
            }
        }
        private void btn_left_Click(object sender, EventArgs e)
        {
            if (cmb_staff_type.SelectedIndex == -1)
                MessageBox.Show("You need to select the staff type");
            else
            {
                position--;
                if (emps_type == 0 && position >=0)
                    salaryEmps(position);
                else
                    MessageBox.Show("No more elements");
                if (emps_type == 1 && position >= 0)
                    hourlyEmps(position);
                else
                    MessageBox.Show("No more elements");

                if (emps_type == 2 && position >= 0)
                    commissionEmps(position);
                else
                    MessageBox.Show("No more elements");
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            emps_transfer.Show();
        }

        private void ViewEmployees_Load(object sender, EventArgs e)
        {
        }
    }
}
