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


    public partial class DeleteReturn : Form
    {
   
        public DeleteReturn()
        {
            InitializeComponent();
        }

        private void ReturnBooks_Load(object sender, EventArgs e)
        {
            FillBook();
            FillStudents();
            populate();
            populateReturn();
        }

        private void FillStudents()
        {
            var student = new Student();
            var dt = student.GetAllWithOneColumn("stdId");
            Usn.ValueMember = "stdId";
            Usn.DataSource = dt;
        }
        private void FillBook()
        {
            var book = new Book();
            var dt = book.GetAllWithOneColumn("bookName");
            Book.ValueMember = "bookName";
            Book.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void populate()
        {
            var myReturnBook = new ReturnBook();
            var ds = myReturnBook.GetAll();
            IssueData.DataSource = ds.Tables[0];
          
         
        }
        public void populateReturn()
        {
            var myReturnBook = new ReturnBook();
            var ds = myReturnBook.GetAllReturn();
            ReturnData.DataSource = ds.Tables[0];
            
        }

 
        private void IssueData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Num.Text = IssueData.SelectedRows[0].Cells[0].Value.ToString();
            Usn.SelectedValue = IssueData.SelectedRows[0].Cells[1].Value.ToString();
            textBox1.Text = IssueData.SelectedRows[0].Cells[2].Value.ToString();
            Dep.Text = IssueData.SelectedRows[0].Cells[3].Value.ToString();
            Phone.Text = IssueData.SelectedRows[0].Cells[4].Value.ToString();
            email.Text = IssueData.SelectedRows[0].Cells[5].Value.ToString();
            Book.SelectedValue = IssueData.SelectedRows[0].Cells[6].Value.ToString();
            IssueDate.Text = IssueData.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (returnNo.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Please fill all informations.");
            }
            else
            {
                var returnbook = new ReturnBook();
                returnbook.stdMail = email.Text;
                returnbook.stdName = textBox1.Text;
                returnbook.stdId = Convert.ToInt32(Usn.SelectedValue.ToString()); 
                returnbook.stdDep = Dep.Text;
                returnbook.stdPhone = Phone.Text;
                returnbook.bookReturned = Book.SelectedValue.ToString();
                returnbook.returnNum =Convert.ToInt32(returnNo.Text);
                returnbook.issueDate= IssueDate.Value.Month.ToString() + "/" + IssueDate.Value.Day.ToString() + "/" + IssueDate.Value.Year.ToString();
                returnbook.returnDate = ReturnDate.Value.Month.ToString() + "/" + ReturnDate.Value.Day.ToString() + "/" + ReturnDate.Value.Year.ToString();
                var isAdded= returnbook.Add();

                if (isAdded)
                {
                    MessageBox.Show("Book Returned Successfully.");
                    IncreaseQuantity();
                    populate();
                    populateReturn();
                }
                else
                {
                    MessageBox.Show("mal");
                }

            }
        }
        private void IncreaseQuantity()
        {
            var book = new Book();
            book.UpdateQuantity(Book.SelectedValue.ToString());
        }
        

        private void button1_Click(object sender, EventArgs e)
        {

            if (returnNo.Text == "")
            {
                MessageBox.Show("Please enter the Return Number");
            }

            else
            {
                var returnbook = new ReturnBook();
                var isDeleted = returnbook.Delete(returnNo.Text);

                if (isDeleted)
                {
                    MessageBox.Show("Returned information Deleted Succesfully.");
                    populateReturn();
                }
                else
                {
                    MessageBox.Show("Returned information could not delete succesfully.");
                }
                
             
            }

        }


        private void ReturnData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            returnNo.Text = ReturnData.SelectedRows[0].Cells[0].Value.ToString();
        }
    }
}
