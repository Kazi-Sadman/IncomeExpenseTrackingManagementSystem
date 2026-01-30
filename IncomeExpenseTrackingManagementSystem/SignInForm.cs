using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // use this namespace for database connection

namespace IncomeExpenseTrackingManagementSystem
{
    public partial class SignInForm : Form
    {
        //1.For database connection at first we create object of SqlConnection Class and we pass connetion string to constructor of the calss , here we pass databse name , databse server name
        SqlConnection con = new SqlConnection("");
        public SignInForm()
        {
            InitializeComponent();
        }

        public bool checkConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void lblClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSingnUp_Click(object sender, EventArgs e)
        {
            // If go to Registration form  From Sing Up form to click Sign Up Button
            //1. Create a object of which Form you go to ( here Regristration Form)
            RegistrationForm Registragtion = new RegistrationForm();
            Registragtion.Show(); // use Show() becasue application show one time , if we use ShowDialog()then multiple cliking the button , show multiple same form
            this.Hide();

        }

        private void chkSignInShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSignInShowPassword.Checked)
            {
                txtSignInPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtSignInPassword.UseSystemPasswordChar = false;
            }
            //alternative
            //bool isChecked = chkSignInShowPassword.Checked;
            //txtSignInPassword.UseSystemPasswordChar = !isChecked;


        }
    }
}