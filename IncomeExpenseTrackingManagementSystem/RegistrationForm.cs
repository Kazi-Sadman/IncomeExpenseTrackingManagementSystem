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
            //Text is the property of text box and we check if text box is empty then show a message 
            if(txtRegistrationUserName.Text == "" || txtRegistrationPassword.Text == "" || textRegistrationComfirmPassword.Text == "")
            {
                MessageBox.Show("Please fill all the blank fileds", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

            }
        }
    }
}
