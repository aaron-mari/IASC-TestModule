using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace IACLCSC_TestProject
{
    public class DbConnect
    {
        String server;
        String user;
        String password;
        String db;
        public MySqlConnection con;
        MySqlDataAdapter dataAdapter;
        
        public DbConnect()
        {
            this.server = "localhost";
            this.db = "IACSC-TestProject";
            this.user = "root";
            this.password = "toor";
            //initalize the connection object
            con = new MySqlConnection();
            // string = server=localhost;database=iacsc-testproject;uid=root;
            con.ConnectionString = String.Format("server={0};database={1};uid={2};pwd={3};", this.server, this.db, this.user, this.password);
            //MessageBox.Show(con.ConnectionString);
        }
        public DataTable retrieveTable(String sqlcmd)
        {
            //executes an SQL command in the database and returns a DataTable
            DataTable dt = new DataTable();
            dataAdapter = new MySqlDataAdapter(sqlcmd, con);
            try
            {
                con.Open();
                dataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Cannot retrieve data from database: " + ex.Message);
                throw ex;
            }
            
            finally
            {
                con.Close();
            }
            return dt;
        }
        public void insertData(String cmd)
        {
            MySqlCommand c = new MySqlCommand(cmd);
            c.Connection = con;
            try
            {
                con.Open();
                c.ExecuteNonQuery();
                
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
        public void removeData(String cmd)
        {
            MySqlCommand c = new MySqlCommand(cmd,con);
            try
            {
                con.Open();
                c.ExecuteNonQuery();
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
