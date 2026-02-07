using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace IncomeExpenseTrackingManagementSystem
{
    public partial class RegistrationForm : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void lblRegisterFromClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnSingnIN_Click(object sender, EventArgs e)
        {
            // If go to SignIn form  From Registration form to click Sign IN Button
            //1. Create a object of which Form you go to ( here Sing in Form)
            SignInForm signInFrom = new SignInForm();
            signInFrom.Show();
            this.Hide();

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
           // UseSystemPasswordChar is  property of checkbox
            //Check if the checkbox is checked. Checked is a property of checkBox
            if (chkShowPassword.Checked)
            {
                // Show the password in the textBox by disabling password char marking
                textRegistrationComfirmPassword.UseSystemPasswordChar = true;
                txtRegistrationPassword.UseSystemPasswordChar = true;
            }
            else
            {
                textRegistrationComfirmPassword.UseSystemPasswordChar = false;
                txtRegistrationPassword.UseSystemPasswordChar = false;
            }
        }

        private void btnSingup_Click(object sender, EventArgs e)
        {


            string username = txtRegistrationUserName.Text.Trim();
            string password = txtRegistrationPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            // Check if user already exists
            string checkQuery = $"SELECT * FROM Users WHERE Username='{username}'";
            var dt = db.GetDataTable(checkQuery);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Username already exists! Please choose another.");
                return;
            }

            // Insert new user
            string insertQuery = $"INSERT INTO Users (Username, Password) VALUES ('{username}', '{password}')";
            bool success = db.InsertUpdateDelete(insertQuery);

            if (success)
            {
                // Verify insertion
                string verifyQuery = $"SELECT * FROM Users WHERE Username='{username}'";
                var dtVerify = db.GetDataTable(verifyQuery);

                if (dtVerify.Rows.Count > 0)
                {
                    MessageBox.Show("Registration successful and verified in database!");
                    
                    SignInForm singIn = new SignInForm();
                    singIn.Show();
                    this.Hide();

                    // Optionally, open login form
                    // LoginForm loginForm = new LoginForm();
                    // loginForm.Show();
                    // this.Hide();
                }
                else
                {
                    MessageBox.Show("Registration failed: data not stored in database.");
                }
            }
            else
            {
                MessageBox.Show("Registration failed. Try again.");
            }
        }
    }
}
