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
    public partial class DeleteEmployees : Form
    {
        main_Menu emps_transfer;
        int emps_type;
        public DeleteEmployees(main_Menu emp)
        {
            emps_transfer = emp;
            InitializeComponent();
        }
        private void cmb_staff_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_staff_type.SelectedIndex == 0)
                emps_type = 0;
            if (cmb_staff_type.SelectedIndex == 1)
                emps_type = 1;
            if (cmb_staff_type.SelectedIndex == 2)
                emps_type = 2;
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (cmb_staff_type.SelectedIndex == -1 || txt_firstname.Text == "")
                MessageBox.Show("you need to select the staff type and fill the employee name");
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
                            if (MessageBox.Show("Warning", "Record was found, are you sure you want to delete it?: ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                main_Menu.list_salaried.Remove(emp);
                                MessageBox.Show("Deleted...");
                                cmb_staff_type.Text = "";
                                txt_firstname.Text = "";
                            }
                            break;
                        }
                    }
                    if (emps_found == false)
                    {
                        MessageBox.Show("Sorry no record found");
                        cmb_staff_type.Text = "";
                        txt_firstname.Text = "";
                    }
                }
                if (emps_type == 1)
                {
                    Boolean emps_found = false;
                    foreach (var emp in main_Menu.list_hourly)
                    {
                        if (emp.Firstname == txt_firstname.Text)
                        {
                            emps_found = true;
                            if (MessageBox.Show("Warning", "Record was found, are you sure you want to delete it?: ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                main_Menu.list_hourly.Remove(emp);
                                MessageBox.Show("Deleted...");
                                cmb_staff_type.Text = "";
                                txt_firstname.Text = "";
                            }
                            break;
                        }
                    }
                    if (emps_found == false)
                    {
                        MessageBox.Show("Sorry no record found");
                        cmb_staff_type.Text = "";
                        txt_firstname.Text = "";
                    }
                }
                if (emps_type == 2)
                {
                    Boolean emps_found = false;
                    foreach (var emp in main_Menu.list_commission)
                    {
                        if (emp.Firstname == txt_firstname.Text)
                        {
                            emps_found = true;
                            if (MessageBox.Show("Warning", "Record was found, are you sure you want to delete it?: ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                main_Menu.list_commission.Remove(emp);
                                MessageBox.Show("Deleted...");
                                cmb_staff_type.Text = "";
                                txt_firstname.Text = "";
                            }
                            break;
                        }
                    }
                    if (emps_found == false)
                    {
                        MessageBox.Show("Sorry no record found");
                        cmb_staff_type.Text = "";
                        txt_firstname.Text = "";
                    }
                }
            } 
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            emps_transfer.Show();
        }
        private void DeleteEmployees_Load(object sender, EventArgs e)
        {
        }
    }
}
