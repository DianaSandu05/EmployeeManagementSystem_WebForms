using PdfSharp.Pdf;
using PdfSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Drawing;
using System.Diagnostics;

namespace project_Advanced_Programming
{
    public partial class EmployeesPayslips : Form
    {
        main_Menu emps_transfer;
        int emps_type;
        Boolean emps_found;
        String find_emp;
        SalariedEmployees salaried_emps;
        HourlyEmployees hourly_emps;
        CommissionEmployees commission_emps;
        public EmployeesPayslips(main_Menu emps)
        {
            InitializeComponent();
            this.emps_transfer = emps;
            find_emp = "";
            emps_type = -1;
            salaried_emps = new SalariedEmployees();
            hourly_emps = new HourlyEmployees();
            commission_emps = new CommissionEmployees();
        }
        private void cmb_staff_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            emps_type = cmb_staff_type.SelectedIndex;
        }
        void payslip(int emps_type)
        {
            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = "Payslips";
            PdfPage page1 = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(page1);
            XFont font = new XFont("Arial", 20, XFontStyle.Bold);
            graph.DrawString("Payslips", font, XBrushes.Black, 200, 10, XStringFormats.TopLeft);
            graph.DrawString("Firstname :"+salaried_emps.Firstname, font, XBrushes.Black, 20, 30, XStringFormats.TopLeft);
            graph.DrawString("Lastname : "+salaried_emps.Lastname, font, XBrushes.Black, 20, 55, XStringFormats.TopLeft);
            graph.DrawString("Gender : "+salaried_emps.Gender, font, XBrushes.Black, 20, 80, XStringFormats.TopLeft);
            graph.DrawString("Address : " + salaried_emps.Address, font, XBrushes.Black, 20, 105, XStringFormats.TopLeft);
            graph.DrawString("Dob : " + salaried_emps.Dob.ToString(), font, XBrushes.Black, 20, 130, XStringFormats.TopLeft);

            XImage image = XImage.FromFile(salaried_emps.Picture);
            graph.DrawImage(image, 200, 10, 200, 200);

            if (emps_type == 0)
            {
                Double salary = (salaried_emps.Salary / 12);
                Double tax = .20 * salary;
                Double nino = .10 * salary;
                graph.DrawString("Basic Salary : " + salary.ToString(), font, XBrushes.Black, 20, 155, XStringFormats.TopLeft);
                graph.DrawString("TAX : " + tax.ToString(), font, XBrushes.Black, 20, 180, XStringFormats.TopLeft);
                graph.DrawString("NI : " + nino.ToString(), font, XBrushes.Black, 20, 205, XStringFormats.TopLeft);
                graph.DrawString("Final Money : " + (salary -tax-nino).ToString(), font, XBrushes.Black, 20, 230, XStringFormats.TopLeft);
            }
            if (emps_type == 1)
            {
                Double salary;
                if (hourly_emps.Hours > 40)
                  {
                    salary = (hourly_emps.Hourly_rate * 40) + (hourly_emps.Hourly_rate *1.5* (hourly_emps.Hours-40)); }
                else
                 salary = (hourly_emps.Hourly_rate*hourly_emps.Hours);
                Double tax = .20 * salary;
                Double nino = .10 * salary;
                graph.DrawString("Basic Salary : " + salary.ToString(), font, XBrushes.Black, 20, 155, XStringFormats.TopLeft);
                graph.DrawString("TAX : " + tax.ToString(), font, XBrushes.Black, 20, 180, XStringFormats.TopLeft);
                graph.DrawString("NI : " + nino.ToString(), font, XBrushes.Black, 20, 205, XStringFormats.TopLeft);
                graph.DrawString("Final Money : " + (salary - tax - nino).ToString(), font, XBrushes.Black, 20, 230, XStringFormats.TopLeft);
            }
            if (emps_type == 2)
            {
                Double salary = (commission_emps.Base_salary+commission_emps.Sales*commission_emps.Rate/100);
                Double tax = .20 * salary;
                Double nino = .10 * salary;
                graph.DrawString("Basic Salary : " + salary.ToString(), font, XBrushes.Black, 20, 155, XStringFormats.TopLeft);
                graph.DrawString("TAX : " + tax.ToString(), font, XBrushes.Black, 20, 180, XStringFormats.TopLeft);
                graph.DrawString("NI : " + nino.ToString(), font, XBrushes.Black, 20, 205, XStringFormats.TopLeft);
                graph.DrawString("Final Money : " + (salary - tax - nino).ToString(), font, XBrushes.Black, 20, 230, XStringFormats.TopLeft);
            }
            pdf.Save("ps.pdf");
            Process.Start("ps.pdf");
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            find_emp = txt_firstname.Text;
            if (find_emp == "" || emps_type == -1)
                MessageBox.Show("You need to select stafft type or need to enter the staff name");
            else
            {
                if (emps_type == 0)
                {
                    emps_found = false;
                    foreach (var emp in main_Menu.list_salaried)
                    {
                        if (emp.Firstname == find_emp)
                        {
                            emps_found = true;
                            salaried_emps = emp; // the found salaried employee (emp) is  stored in object salaried_emps
                            
                            payslip(0);
                            break;
                        }
                    }
                    if (emps_found == false)
                        MessageBox.Show("Sorry no record found");
                }
                if (emps_type == 1)
                {
                    emps_found = false;
                    foreach (var emp in main_Menu.list_hourly)
                    {
                        if (emp.Firstname == find_emp)
                        {
                            emps_found = true;
                            hourly_emps = emp; // the found hourly employee (emp) is  stored in object hourly_emps
                            payslip(1);
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
                        if (emp.Firstname == find_emp)
                        {
                            emps_found = true;
                            commission_emps = emp; // the found commission employee (emp) is  stored in object commission_emps
                            payslip(2);
                            break;
                        }
                    }
                    if (emps_found == false)
                        MessageBox.Show("Sorry no record found");
                }
            }
            } 

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            emps_transfer.Show();
        }
        private void EmployeesPayslips_Load(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
