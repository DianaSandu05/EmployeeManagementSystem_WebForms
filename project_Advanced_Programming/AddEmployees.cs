using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_Advanced_Programming
{
    public partial class AddEmployee : Form
    {
        String filename_storage;  // this will store the file name
        String filename_source;  // this will store the source path  plus the file name together
        String destination_pic; //this will save to your destination folder
        int emps_type;
        main_Menu emps_transfer; 
        public AddEmployee(main_Menu emp)
        {
            emps_transfer = emp;
            InitializeComponent();
            filename_source = "";  
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                // image filters  
                Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp"
            };
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pb_picture.Image = new Bitmap(open.FileName);
                // image file path  
                filename_source = open.FileName;
                filename_storage = Path.GetFileName(open.FileName);
            }
        }



        private void cmb_staff_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            emps_type = cmb_staff_type.SelectedIndex;

            if (cmb_staff_type.SelectedIndex==0)
            { 
                salariedGroupBox.Enabled = true;
                hourlyGroupBox.Enabled = false;
                commissionGroupBox.Enabled = false;
                
            }
            else if (cmb_staff_type.SelectedIndex ==1)
            {   
                salariedGroupBox.Enabled = false;
                hourlyGroupBox.Enabled = true;
                commissionGroupBox.Enabled = false;
            }
            else if (cmb_staff_type.SelectedIndex == 2)
            {
                salariedGroupBox.Enabled = false;
                hourlyGroupBox.Enabled = false;
                commissionGroupBox.Enabled = true;
            }

        }

        private void btn_add_employee_Click_1(object sender, EventArgs e)
        {
            destination_pic = "staff";
            var directory = new DirectoryInfo(destination_pic);

            if (directory.Exists == false)
            {
                directory.Create();
            }

           

            if (filename_source != "")
            {
                var destination_file = Path.Combine(destination_pic, filename_storage);

                File.Copy(filename_source, destination_file, true);

                if (emps_type == 0)
                {


                    SalariedEmployees salaried_emps = new SalariedEmployees();
                    salaried_emps.Firstname = firstNameTxtBox.Text;
                    salaried_emps.Lastname = lastNameTxtBox.Text;
                    salaried_emps.Gender = cmb_gender.SelectedItem.ToString();
                    salaried_emps.Phone = contactNoTxtBox.Text;
                    salaried_emps.Dob = dtp_dob.Value;
                    salaried_emps.Address = addressTxtBox.Text;
                    salaried_emps.Department = departmentTxtBox.Text;
                    salaried_emps.NiNo = ninoTxtBox.Text;
                    salaried_emps.Salary = Convert.ToDouble(salaryTxtBox.Text);
                    salaried_emps.Picture = destination_file;
                    main_Menu.list_salaried.Add(salaried_emps);
                    MessageBox.Show("Added Succesfully");
                    this.Hide();
                    emps_transfer.Show();


                }

                if (emps_type == 1)
                {


                    HourlyEmployees hourly_emps = new HourlyEmployees();
                    hourly_emps.Firstname = firstNameTxtBox.Text;
                    hourly_emps.Lastname = lastNameTxtBox.Text;
                    hourly_emps.Gender = cmb_gender.SelectedItem.ToString();
                    hourly_emps.Phone = contactNoTxtBox.Text;
                    hourly_emps.Dob = dtp_dob.Value;
                    hourly_emps.Address = addressTxtBox.Text;
                    hourly_emps.Department = departmentTxtBox.Text;
                    hourly_emps.NiNo = ninoTxtBox.Text;
                    hourly_emps.Hours = Convert.ToDouble(hoursWorkedTxtBox.Text);
                    hourly_emps.Hourly_rate = Convert.ToDouble(hourRateTxtBox.Text);
                    hourly_emps.Picture = destination_file;
                    main_Menu.list_hourly.Add(hourly_emps);
                    MessageBox.Show("Added Succesfully");
                    this.Hide();
                    emps_transfer.Show();

                }

                if (emps_type == 2)
                {


                    CommissionEmployees commission_emps = new CommissionEmployees();
                    commission_emps.Firstname = firstNameTxtBox.Text;
                    commission_emps.Lastname = lastNameTxtBox.Text;
                    commission_emps.Gender = cmb_gender.SelectedItem.ToString();
                    commission_emps.Phone = contactNoTxtBox.Text;
                    commission_emps.Dob = dtp_dob.Value;
                    commission_emps.Address = addressTxtBox.Text;
                    commission_emps.Department = departmentTxtBox.Text;
                    commission_emps.NiNo = ninoTxtBox.Text;
                    commission_emps.Sales = Convert.ToDouble(salesTxtBox.Text);
                    commission_emps.Rate = Convert.ToDouble(cmsRateTxtBox.Text);
                    commission_emps.Picture = destination_file;
                    main_Menu.list_commission.Add(commission_emps);
                    MessageBox.Show("Added Succesfully");
                    this.Hide();
                    emps_transfer.Show();

                }

            }
            else
                MessageBox.Show("You need to upload the picture");
         
            this.Hide();
            emps_transfer.Show();


        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            //main_page mp = new main_page();
            this.Hide();
            emps_transfer.Show();
        }

        private void AddEmployees_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
