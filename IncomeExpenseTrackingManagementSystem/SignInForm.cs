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
        DatabaseHelper db = new DatabaseHelper();
        public SignInForm()
        {
            InitializeComponent();
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtSingInUserName.Text.Trim();
            string password = txtSignInPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            string query = $"SELECT * FROM Users WHERE Username='{username}' AND Password='{password}'";
            var dt = db.GetDataTable(query);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login successful!");

                FromDashboard dashboard = new FromDashboard();
                dashboard.Show();
                this.Hide(); // hide login form
                // You can open another form here
                // Example: new DashboardForm().Show(); this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    
    }
}