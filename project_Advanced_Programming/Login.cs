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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = usernameTxtBox.Text;
            String password = passwordtxtBox.Text;
            if ( username == "" || password == "")
                MessageBox.Show("You need to fill the id as well as password");
            else if ((username=="student") && (password=="16451"))
            {
                main_Menu emps_transfer = new main_Menu();
                this.Hide();
                emps_transfer.Show();
            }
            else
                MessageBox.Show("You enter a wrong password or username! Please try again!");

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
