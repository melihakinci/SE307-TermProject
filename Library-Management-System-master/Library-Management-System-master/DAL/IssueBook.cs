using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class IssueBook  
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\excalibur\OneDrive\Masaüstü\LibraryManagementDB.mdf;Integrated Security=True;Connect Timeout=30");

        public int issueNum { get; set; }
        public int stdId { get; set; }
        public string stdName { get; set; }
        public string stdDep { get; set; }
        public string stdPhone { get; set; }

        public string stdMail { get; set; }
        public string bookIssued  { get; set; }

        public string issueDate { get; set; }


        public DataSet GetAll() {
            try
            {
                con.Open();
                string query = "select * from IssueTbl";
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
            finally {
                con.Close();
            }
        }

        public bool Save() {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into IssueTbl values (" + this.issueNum + ", " + this.stdId + ", '" + this.stdName + "', '" + this.stdDep + "', '" + this.stdPhone + "','" + this.stdMail + "','" + this.bookIssued + "','" + this.issueDate + "') ", con);
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

        public bool Delete(string issueNum) {
            try
            {
                int num = Convert.ToInt32(issueNum);

                con.Open();
                string query = "delete from IssueTbl where issueNum='" + num + "'";
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
    }
}
