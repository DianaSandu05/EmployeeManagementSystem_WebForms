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
    public partial class UpdateEmployee : Form
    {
        main_Menu emps_transfer;
        int emps_type;
        SalariedEmployees salaried_emps;
        HourlyEmployees hourly_emps;
        CommissionEmployees commission_emps;
        public UpdateEmployee(main_Menu emps)
        {
            InitializeComponent();
            emps_type = -1;
            emps_transfer = emps;
            salaried_emps = new SalariedEmployees();
            hourly_emps = new HourlyEmployees();
            commission_emps = new CommissionEmployees();
        }
        private void frm_update_employee_Load(object sender, EventArgs e)
        {
        }
        private void cmb_staff_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            emps_type = cmb_staff_type.SelectedIndex;
        }

        private void btn_search_Click(object sender, EventArgs e)
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
                            salaried_emps = emp;
                            //txt_firstname.Text =emp.Firstname;
                            txt_lastname.Text = emp.Lastname;
                            cmb_gender.Text = emp.Gender;
                            dtp_dob.Value = emp.Dob;
                            txt_address.Text = emp.Address;
                            txt_contact.Text = emp.Phone;
                            txtNino.Text = emp.NiNo;
                            txt_department.Text = emp.Department;
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
                            hourly_emps = emp;
                            //txt_firstname.Text =emp.Firstname;
                            txt_lastname.Text = emp.Lastname;
                            cmb_gender.Text = emp.Gender;
                            dtp_dob.Value = emp.Dob;
                            txt_address.Text = emp.Address;
                            txt_contact.Text = emp.Phone;
                            txtNino.Text = emp.NiNo;
                            txt_department.Text = emp.Department;
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
                            commission_emps = emp;
                            //txt_firstname.Text =emp.Firstname;
                            txt_lastname.Text = emp.Lastname;
                            cmb_gender.Text = emp.Gender;
                            dtp_dob.Value = emp.Dob;
                            txt_address.Text = emp.Address;
                            txt_contact.Text = emp.Phone;
                            txtNino.Text = emp.NiNo;
                            txt_department.Text = emp.Department;
                            txt_salary.Text = emp.Base_salary.ToString();
                            txt_sales.Text = emp.Sales.ToString();
                            txt_rate.Text = emp.Rate.ToString();
                            pb_picture.Image = new Bitmap(emp.Picture);
                            break;
                        }
                    }
                    if (emps_found == false)
                        MessageBox.Show("Sorry no record found");
                }
       }

            }
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (emps_type == 0)
            {
                main_Menu.list_salaried.Remove(salaried_emps);
                salaried_emps.Firstname = txt_firstname.Text;
                salaried_emps.Lastname = txt_lastname.Text;
                salaried_emps.Gender = cmb_gender.SelectedItem.ToString();
                salaried_emps.Phone = txt_contact.Text;
                salaried_emps.Department = txt_department.Text;
                salaried_emps.NiNo = txtNino.Text;
                salaried_emps.Dob = dtp_dob.Value;
                salaried_emps.Address = txt_address.Text;
                salaried_emps.Salary = Convert.ToDouble(txt_salary.Text);
                
                main_Menu.list_salaried.Add(salaried_emps);
                MessageBox.Show("Updated Succesfully in Salried List");
            }

            if (emps_type == 1)
            {
                main_Menu.list_hourly.Remove(hourly_emps);
                hourly_emps.Firstname = txt_firstname.Text;
                hourly_emps.Lastname = txt_lastname.Text;
                hourly_emps.Gender = cmb_gender.SelectedItem.ToString();
                hourly_emps.Phone = txt_contact.Text;
                hourly_emps.Dob = dtp_dob.Value;
                hourly_emps.Address = txt_address.Text;
                hourly_emps.Department = txt_department.Text;
                hourly_emps.NiNo = txtNino.Text;
                hourly_emps.Hours = Convert.ToDouble(txt_hours_worked.Text);
                hourly_emps.Hourly_rate = Convert.ToDouble(txt_hourly_rate.Text);
                main_Menu.list_hourly.Add(hourly_emps);
                MessageBox.Show("Updated Succesfully");
                this.Hide();
                emps_transfer.Show();
            }
            if (emps_type == 2)
            {
                main_Menu.list_commission.Remove(commission_emps);
                commission_emps.Firstname = txt_firstname.Text;
                commission_emps.Lastname = txt_lastname.Text;
                commission_emps.Gender = cmb_gender.SelectedItem.ToString();
                commission_emps.Phone = txt_contact.Text;
                commission_emps.NiNo = txtNino.Text;
                commission_emps.Department = txt_department.Text;
                commission_emps.Dob = dtp_dob.Value;
                commission_emps.Address = txt_address.Text;
                commission_emps.Base_salary = Convert.ToDouble(txt_salary.Text);
                commission_emps.Sales = Convert.ToDouble(txt_sales.Text);
                commission_emps.Rate = Convert.ToDouble(txt_rate.Text);

                main_Menu.list_commission.Add(commission_emps);
                MessageBox.Show("update Succesfully");
            }
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            emps_transfer.Show();
        }
    }
    }
