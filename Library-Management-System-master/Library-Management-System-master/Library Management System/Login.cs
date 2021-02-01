using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { 
            var loginScreen = new Logins();
            loginScreen.username = textUsername.Text;
            loginScreen.password = textPassword.Text;
            var returnVal = loginScreen.GetUsernamePass(); //it returns as dataTable

            if (returnVal.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Dashboard dash = new Dashboard();
                dash.Show();

            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textUsername_MouseClick(object sender, MouseEventArgs e)
        {
            if (textUsername.Text == "Username")
                textUsername.Clear();
        }

        private void textPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (textPassword.Text == "Password")
            { 
                textPassword.Clear();
                textPassword.PasswordChar = '*';
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void textUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSign_Click(object sender, EventArgs e)
        {
           
            SignUp su = new SignUp();
            su.Show();
            this.Hide();
        }
    }
}
