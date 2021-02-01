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
    public partial class Books : Form
    {
        public Books()
        {
            InitializeComponent();
        }

        private void Books_Load(object sender, EventArgs e)
        {
            populate();
        }

        public void populate()
        {
            var myBook = new Book();
            var ds = myBook.GetAll();
            bookData.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bookName.Text == "" || bookAuthor.Text == "" || bookPublish.Text == "" || bookPrice.Text == "" || Qty.Text == ""  )
            {
                MessageBox.Show("Please fill all informations");
            }
            else if(Qty.Text == "0")
            {
                MessageBox.Show("Quantity cannot be 0.");
            }
            else
            {
                var newBook = new Book();
                newBook.bookName = bookName.Text;
                newBook.bookAuthor = bookAuthor.Text;
                newBook.bookPublish = bookPublish.Text;
                newBook.bookPrice = Convert.ToInt32(bookPrice.Text);
                newBook.Qty = Convert.ToInt32(Qty.Text);

                var result = newBook.Add();


                if (result)
                {
                    MessageBox.Show("Book Added Successfully.");
                    populate();
                }
                else {
                    MessageBox.Show("Book could not add.");
                }
                
            }
        }

        private void bookData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bookName.Text = bookData.SelectedRows[0].Cells[0].Value.ToString();
            bookAuthor.Text = bookData.SelectedRows[0].Cells[1].Value.ToString();
            bookPublish.Text = bookData.SelectedRows[0].Cells[2].Value.ToString();
            bookPrice.Text = bookData.SelectedRows[0].Cells[3].Value.ToString();
            Qty.Text = bookData.SelectedRows[0].Cells[4].Value.ToString();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (bookName.Text == "")
            {
                MessageBox.Show("Please enter the Book Name");
            }
            else
            {
                var book = new Book();

                var isDeleted = book.Delete(bookName.Text);

                if (isDeleted)
                {
                    MessageBox.Show("Book Deleted Succesfully.");
                    populate();
                }
                else {
                    MessageBox.Show("Book could not delete.");
                }
               
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (bookName.Text == "" || bookAuthor.Text == "" || bookPublish.Text == "" || bookPrice.Text == "" || Qty.Text == "")
            {
                MessageBox.Show("Please fill all informations.");
            }
            else
            {
                var newBook = new Book();
                newBook.bookName = bookName.Text;
                newBook.bookAuthor = bookAuthor.Text;
                newBook.bookPublish = bookPublish.Text;
                newBook.bookPrice = Convert.ToInt32(bookPrice.Text);
                newBook.Qty = Convert.ToInt32(Qty.Text);
                
                var result = newBook.Update();

                if (result)
                {
                    MessageBox.Show("Book Updated Successfully.");
                    populate();
                }
                else {
                    MessageBox.Show("Book Could not Updated.");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            if (txtBookName.Text != "")
            {
                var searchText = txtBookName.Text;

                var book = new Book();

                var ds = book.Search(searchText);

                bookData.DataSource = ds.Tables[0];
            } else {
                populate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtBookName.Clear();
        }
    }
}
