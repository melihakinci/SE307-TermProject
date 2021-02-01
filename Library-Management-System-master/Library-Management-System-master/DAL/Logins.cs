using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Logins
    {


        public string username { get; set; }
        public string password { get; set; }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\excalibur\OneDrive\Masaüstü\LibraryManagementDB.mdf;Integrated Security=True;Connect Timeout=30");
        public Logins()
        {

        }
        public DataTable GetUsernamePass()
        {
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from AdminTbl where username='" + this.username+ "' and password='" + this.password + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
