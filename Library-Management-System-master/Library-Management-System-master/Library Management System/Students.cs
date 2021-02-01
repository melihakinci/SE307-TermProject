using DAL;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class Students : Form
    {
        public Students()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Students_Load(object sender, EventArgs e)
        {
            populate();
        }
        public void populate()
        {
            var myStudent = new Student();
            var ds = myStudent.GetAll();
            stdData.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (stdId.Text == "" || stdName.Text == "" || stdDep.Text == "" || comboBox1.Text == "" || stdPhone.Text == "" || stdEmail.Text == "")
            {
                MessageBox.Show("Please fill all the student informations!");
            }
            else
            {
                var newStd = new Student();
                newStd.stdDep = stdDep.Text;
                newStd.stdId = Convert.ToInt32(stdId.Text);
                newStd.stdPhone = stdPhone.Text;
                newStd.stdName = stdName.Text;
                newStd.stdSem = Convert.ToInt32(comboBox1.Text);
                newStd.stdMail = stdEmail.Text;

                var result = newStd.Add();


                if (result)
                {
                    MessageBox.Show("Student Added Successfully.");
                    populate();
                }
                else
                {
                    MessageBox.Show("Student could not add.");
                }

            }

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (stdId.Text == "")
            {
                MessageBox.Show("Please enter the Student ID");
            }

            else
            {
                var student = new Student();
                var IsStudentDeleted = student.Delete(stdId.Text);
                if (IsStudentDeleted)
                {
                    MessageBox.Show("Student Deleted Succesfully.");
                    populate();
                }
                else
                {
                    MessageBox.Show("Student could not delete.");
                }


            }
        }

        private void stdData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            stdId.Text = stdData.SelectedRows[0].Cells[0].Value.ToString();
            stdName.Text = stdData.SelectedRows[0].Cells[1].Value.ToString();
            stdDep.Text = stdData.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.Text = stdData.SelectedRows[0].Cells[3].Value.ToString();
            stdPhone.Text = stdData.SelectedRows[0].Cells[4].Value.ToString();
            stdEmail.Text = stdData.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (stdId.Text == "" || stdName.Text == "" || stdDep.Text == "" || comboBox1.Text == "" || stdPhone.Text == "" || stdEmail.Text == "")
            {
                MessageBox.Show("Please fill all student informations.");
            }
            else
            {
                var newStd = new Student();
                newStd.stdDep = stdDep.Text;
                newStd.stdId = Convert.ToInt32(stdId.Text);
                newStd.stdPhone = stdPhone.Text;
                newStd.stdName = stdName.Text;
                newStd.stdSem = Convert.ToInt32(comboBox1.Text);
                newStd.stdMail = stdEmail.Text;

                var result = newStd.Update();

                if (result)
                {
                    MessageBox.Show("Student Updated Successfully.");
                    populate();
                }
                else
                {
                    MessageBox.Show("Book Could not Updated.");
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            if (txtBookName.Text != "")
            {
                var searchText = txtBookName.Text;

                var student = new Student();

                var ds = student.Search(searchText);

                stdData.DataSource = ds.Tables[0];
            }
            else
            {
                populate();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtBookName.Clear();
        }
    }

}