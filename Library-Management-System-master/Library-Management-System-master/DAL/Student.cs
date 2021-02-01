using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Student : IEntity
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\excalibur\OneDrive\Masaüstü\LibraryManagementDB.mdf;Integrated Security=True;Connect Timeout=30");
        public int stdId { get; set; }
        public int stdSem { get; set; }
        public string stdName { get; set; }
        public string stdDep { get; set; }
        public string stdPhone { get; set; }
        public string stdMail { get; set; }


        public Student()
        {

        }


        public bool Delete(string id)
        {
            int StdId = Convert.ToInt32(id);

            try
            {
                con.Open();
                string query = "delete from StudentTbl where stdId=" + StdId + "";
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

        public bool Update()
        {
            try
            {
                con.Open();
                string query = "update StudentTbl set stdId = '" + this.stdId + "',stdName = '" + this.stdName + "',stdDep='" + this.stdDep + "',stdSem='" + this.stdSem + "',stdPhone='" + this.stdPhone + "',stdMail='" + this.stdMail + "' where stdId=" + this.stdId + ";";
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

        public DataSet GetAll()
        {
            try
            {
                con.Open();
                string query = "select * from StudentTbl";
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

        public DataSet Search(string id)
        {
           // int stdId = Convert.ToInt32(id);

            try
            {
                con.Open();
                string query = "select * from StudentTbl where stdId LIKE '" + id + "%'";
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

        public bool Add()
        {
            try
            {
                con.Open();
                string query = "insert into StudentTbl values(" + this.stdId + ", '" + this.stdName + "', '" + this.stdDep + "', '" + stdSem + "', '" + this.stdPhone + "', '" + this.stdMail + "') ";
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

        public DataTable GetAllWithOneColumn(string colName)
        {
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("select " + colName + " from  StudentTbl ", con);
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("stdId", typeof(int));
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

        public DataTable GetStudentById(string stdId) {

            try
            {
                con.Open();
                string query = "select * from StudentTbl where stdId = " + stdId + "";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
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
