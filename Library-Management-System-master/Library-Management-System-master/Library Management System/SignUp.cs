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
    public partial class SignUp : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\excalibur\OneDrive\Masaüstü\LibraryManagementDB.mdf;Integrated Security=True;Connect Timeout=30");

        public SignUp()
        {
            InitializeComponent();
        }

        private void textPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (textPassword.Text == "Password")
            {
                textPassword.Clear();
                textPassword.PasswordChar = '*';
            }
        }

        private void textUsername_MouseClick(object sender, MouseEventArgs e)
        {
            if (textUsername.Text == "Username")
                textUsername.Clear();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (textUsername.Text == "" || textPassword.Text == "" )
            {
                MessageBox.Show("Please fill all informations.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                try
                {
                    con.Open();
                    string query = "insert into AdminTbl values('" + textUsername.Text + "', '" + textPassword.Text + "') ";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registered Successfully.");
                    con.Close();
                    this.Hide();
                    Login l = new Login();
                    l.Show();
                }
                catch(System.Data.SqlClient.SqlException ex)
                {
                    MessageBox.Show("This username is already registered.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    con.Close();
                }
               
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Login log = new Login();
            log.Show();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
