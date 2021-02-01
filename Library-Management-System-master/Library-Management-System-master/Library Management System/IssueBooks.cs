using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DAL;

namespace Library_Management_System
{
    public partial class IssueBooks : Form
    {
        
        public IssueBooks()
        {
            InitializeComponent();
        }

        private void IssueBook_Load(object sender, EventArgs e)
        {
            fillStudents();
            fillBook();
            populate();
        }

        private void fillStudents()
        {
            var student = new Student();
            var dt = student.GetAllWithOneColumn("stdId");
            Usn.ValueMember = "stdId";
            Usn.DataSource = dt;
        }
        private void fillBook()
        {
            var book = new Book();
            var dt = book.GetAllWithOneColumn("bookName");
            Book.ValueMember = "bookName";
            Book.DataSource = dt;
        }
      
        private void fetData()
        {
            var student = new Student();
            var dt = student.GetStudentById(Usn.SelectedValue.ToString());
           
            foreach(DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["stdName"].ToString();
                Dep.Text = dr["stdDep"].ToString();
                Phone.Text = dr["stdPhone"].ToString();
                email.Text = dr["stdMail"].ToString();
            }
        }

        private void UpdateQuantity()
        {
            var book = new Book();
            book.UpdateQuantity(Book.SelectedValue.ToString());
        }

        private void IncreaseQuantity()
        {
            var book = new Book();
            book.IncreaseQuantity(Book.SelectedValue.ToString());
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Usn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Usn_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetData();
        }
        public void populate()
        {
            var issueBook = new IssueBook();
            var ds = issueBook.GetAll();
            IssueData.DataSource = ds.Tables[0];
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (Num.Text == "" || textBox1.Text == "" )
            {
                MessageBox.Show("Please fill all informations", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                try
                {
                    var issueBook = new IssueBook();
                    issueBook.issueNum = Convert.ToInt32(Num.Text);
                    issueBook.stdId = Convert.ToInt32(Usn.SelectedValue.ToString());
                    issueBook.stdName = textBox1.Text;
                    issueBook.stdDep = Dep.Text;
                    issueBook.stdPhone = Phone.Text;
                    issueBook.stdMail = email.Text;
                    issueBook.bookIssued = Book.SelectedValue.ToString();
                    issueBook.issueDate = Date.Value.Month.ToString() + "/" + Date.Value.Day.ToString() + "/" + Date.Value.Year.ToString();


                    var result = issueBook.Save();

                    if (result) {
                        MessageBox.Show("Book Issued Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateQuantity();
                        populate();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void IssueData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Num.Text = IssueData.SelectedRows[0].Cells[0].Value.ToString();
            Usn.SelectedValue = IssueData.SelectedRows[0].Cells[1].Value.ToString();
            textBox1.Text = IssueData.SelectedRows[0].Cells[2].Value.ToString();
            Dep.Text = IssueData.SelectedRows[0].Cells[3].Value.ToString();
            Phone.Text = IssueData.SelectedRows[0].Cells[4].Value.ToString();
            email.Text = IssueData.SelectedRows[0].Cells[5].Value.ToString();
            Book.SelectedValue = IssueData.SelectedRows[0].Cells[6].Value.ToString();
            Date.Text = IssueData.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Num.Text == "")
            {
                MessageBox.Show("Please enter the Issue Number","Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else {

                var issueBook = new IssueBook();
                var isDeleted = issueBook.Delete(Num.Text);

                if (isDeleted)
                {
                    MessageBox.Show("Issue Deleted Succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IncreaseQuantity();
                    populate();
                }
                
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {

        }
    }
}
