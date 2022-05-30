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
    public partial class SearchEmployees : Form
    {
        main_Menu emps_transfer;
        int emps_type; // 0 means salary emps , 1 means hourly emps and 2 means commission emps
        public SearchEmployees(main_Menu  emp)
        {
            emps_transfer = emp;
            InitializeComponent();
        }
        private void SearchEmployees_Load(object sender, EventArgs e)
        {
        }
        private void btn_search_Click_1(object sender, EventArgs e)
        {

            if ((cmb_staff_type.SelectedIndex == -1) || txt_firstname.Text == "")
                MessageBox.Show("You need to select the staff type and also input the staff name");
            else
            {
                if (emps_type == 0)
                {
                    Boolean emps_found = false;
                    foreach (var emp in main_Menu.list_salaried)
                    {
                        if (emp.Firstname == txt_firstname.Text)
                        {
                            emps_found = true;
                            //txt_firstname.Text =emp.Firstname;
                            txt_lastname.Text = emp.Lastname;
                            cmb_gender.Text = emp.Gender;
                            dtp_dob.Value = emp.Dob;
                            txt_address.Text = emp.Address;
                            txt_contact.Text = emp.Phone;
                            txt_salary.Text = emp.Salary.ToString();
                            pb_picture.Image = new Bitmap(emp.Picture);
                            break;
                        }
                    }
                    if (emps_found == false)
                        MessageBox.Show("Sorry no record found");
                }

                if (emps_type == 1)
                {
                    Boolean emps_found = false;
                    foreach (var emp in main_Menu.list_hourly)
                    {
                        if (emp.Firstname == txt_firstname.Text)
                        {
                            emps_found = true;
                            //txt_firstname.Text =emp.Firstname;
                            txt_lastname.Text = emp.Lastname;
                            cmb_gender.Text = emp.Gender;
                            dtp_dob.Value = emp.Dob;
                            txt_address.Text = emp.Address;
                            txt_contact.Text = emp.Phone;
                            txt_hourly_rate.Text = emp.Hourly_rate.ToString();
                            txt_hours_worked.Text = emp.Hours.ToString();
                            pb_picture.Image = new Bitmap(emp.Picture);
                            break;
                        }
                    }
                    if (emps_found == false)
                        MessageBox.Show("Sorry no record found");
                }
                if (emps_type == 2)
                {
                    Boolean emps_found = false;
                    foreach (var emp in main_Menu.list_commission)
                    {
                        if (emp.Firstname == txt_firstname.Text)
                        {
                            emps_found = true;
                            //txt_firstname.Text =emp.Firstname;
                            txt_lastname.Text = emp.Lastname;
                            cmb_gender.Text = emp.Gender;
                            dtp_dob.Value = emp.Dob;
                            txt_address.Text = emp.Address;
                            txt_contact.Text = emp.Phone;
                            txt_salary.Text = emp.Base_salary.ToString();
                            txt_sales.Text = emp.Sales.ToString();
                            txt_rate.Text = emp.Rate.ToString();
                            pb_picture.Image = new Bitmap(emp.Picture);
                            break;
                        }
                    }
                    if (emps_found == false)
                    {
                        MessageBox.Show("Sorry no record found");
                        txt_lastname.Text = "";
                        cmb_gender.Text = "";
                        // dtp_dob.Value = emp.Dob;
                        txt_address.Text = "";
                        txt_contact.Text = "";
                        txt_salary.Text = "";
                        txt_sales.Text = "";
                        txt_rate.Text = "";
                        pb_picture.Image = null;
                    }
                }
            }
        }
        private void btn_exit_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            emps_transfer.Show();
        }
        private void cmb_staff_type_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmb_staff_type.SelectedIndex == 0)
                emps_type = 0;
            if (cmb_staff_type.SelectedIndex == 1)
                emps_type = 1;
            if (cmb_staff_type.SelectedIndex == 2)
                emps_type = 2;
        }
    }
}
