using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Book : IEntity
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\excalibur\OneDrive\Masaüstü\LibraryManagementDB.mdf;Integrated Security=True;Connect Timeout=30");

        public Book() { 
           
        } 
        
        public string bookName { get; set; }

        public string bookAuthor { get; set; }

        public string bookPublish { get; set; }

        public int bookPrice { get; set; }

        public int Qty { get; set; }

        public bool Delete(string name) {

            try
            {
                con.Open();
                string query = "delete from BookTbl where bookName='" + name + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally {
                con.Close();
            }
         

        }

        public bool Update()
        {
            try
            {
                con.Open();
                string query = "update BookTbl set bookName = '" + this.bookName + "',bookAuthor = '" + this.bookAuthor + "',bookPublish='" + this.bookPublish + "',bookPrice='" + this.bookPrice + "',Qty='" + this.Qty + "' where bookName='" + this.bookName + "';";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally {
                con.Close();
            }
           
        }

        public DataSet Search(string name)
        {

            try
            {
                con.Open();
                string query = "select * from BookTbl where bookName LIKE '" + name + "%'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }

        }

        public bool Add() {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into BookTbl values ('" + this.bookName + "', '" + this.bookAuthor + "', '" + this.bookPublish + "', " + this.bookPrice + ", " + this.Qty + ")", con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally {
                con.Close();
            }
        }

        public DataSet GetAll()
        {
            try
            {
                con.Open();
                string query = "select * from BookTbl";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable GetAllWithOneColumn(string colName)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select " + colName + " from  BookTbl where Qty>" + 0 + "", con); //bunda where den sonrası silinip issueboook buttonuna quantitiy checker eklenebilir.( where Qty>"+0+")
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("bookName", typeof(string));
                dt.Load(rdr);

                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void UpdateQuantity(string bookName) {
            try
            {
                int Qty, newQty;
                con.Open();
                string query = "select * from BookTbl where bookName = '" + bookName + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Qty = Convert.ToInt32(dr["Qty"].ToString());
                    newQty = Qty - 1;
                    if (newQty >= 0)
                    {
                        string query2 = "update BookTbl set Qty=" + newQty + " where bookName = '" + bookName + "'";
                        SqlCommand cmd2 = new SqlCommand(query2, con);
                        cmd2.ExecuteNonQuery();
                    }
                    else
                    {
                        Console.WriteLine("out of stock.");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally {
                con.Close();
            }
        
        }

        public void IncreaseQuantity(string bookName)
        {
            try
            {
                int Qty, newQty;
                con.Open();
                string query = "select * from BookTbl where bookName = '" + bookName + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Qty = Convert.ToInt32(dr["Qty"].ToString());
                    newQty = Qty + 1;
                    string query2 = "update BookTbl set Qty=" + newQty + " where bookName = '" + bookName + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd2.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally {
                con.Close();
            }
        }
    }
}
