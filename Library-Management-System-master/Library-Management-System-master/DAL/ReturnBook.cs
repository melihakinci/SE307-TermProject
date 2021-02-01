using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReturnBook
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\excalibur\OneDrive\Masaüstü\LibraryManagementDB.mdf;Integrated Security=True;Connect Timeout=30");
        public int returnNum { get; set; }
        public int stdId { get; set; }
        public string stdName { get; set; }
        public string stdDep { get; set; }
        public string stdMail { get; set; }
        public string stdPhone { get; set; }
        public string bookReturned { get; set; }
        public string returnDate { get; set; }
        public string issueDate { get; set; }


        public ReturnBook()
        {

        }

        public DataSet GetAll()
        {
            try
            {
                con.Open();
                string query = "select * from IssueTbl";
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

        public DataSet GetAllReturn()
        {
            try
            {
                con.Open();
                string query = "select * from ReturnTbl";
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


        public bool Delete(string returnNos)
        {
            int returnNo = Convert.ToInt32(returnNos);

            try
            {
                con.Open();
                string query = "delete from ReturnTbl where returnNum=" + returnNo + "";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }


        }


        public bool Add()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into ReturnTbl values (" + this.returnNum + ", " + this.stdId + ", '" + this.stdName + "', '" + this.stdDep + "', '" + this.stdPhone + "','" + this.stdMail + "','" + this.bookReturned + "','" + this.issueDate + "','" + this.returnDate + "') ", con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

       
    }
}
