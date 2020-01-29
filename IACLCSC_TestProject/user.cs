using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace IACLCSC_TestProject
{
    public class User
    {
        private String username;
        private String password;
        private bool isAdmin;
        DbConnect db;
        public User(String username, String password, DbConnect db)
        {
            this.username = username;
            this.password = password;
            this.isAdmin = false;
            this.db = db;
            login(this.username, this.password);
        }

        private bool ValidateLogin()
        {
            DataTable dt = db.retrieveTable(String.Format("SELECT * FROM user where username='{0}' AND password='{1}'", this.username, this.password));
            if (dt.Rows[0][2].ToString() == "1")
            {
                isAdmin = true;
            }
            else
            {
                isAdmin = false;
            }
            return dt.Rows.Count>0?true:false;
        }
        public bool login(String username, String password)
        {
            this.username = username;
            this.password = password;
            return ValidateLogin() ? true : false;
        }
        public bool isAdminType()
        {
            return this.isAdmin;
        }
        public void setAdminType()
        {
            this.isAdmin = true;
        }

    }
}
