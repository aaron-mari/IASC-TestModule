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
        private String userType;
        private bool isAdmin;
        private bool isLoggedIn;
        DbConnect db;

        public string UserType
        {
            get
            {
                return userType;
            }

            set
            {
                userType = value;
            }
        }

        public bool IsLoggedIn
        {
            get
            {
                return isLoggedIn;
            }

            set
            {
                isLoggedIn = value;
            }
        }

        public User(String username, String password)
        {
            this.username = username;
            this.password = password;
            this.isAdmin = false;
            db = new DbConnect();
            login();
        }

        //this is used for making a new user
        public User(String username, String password, int type)
        {
            this.username = username;
            this.password = password;
            this.isAdmin = false;
            db = new DbConnect();
            DataTable privileges = db.retrieveTable("SELECT * from privilege");
            if(privileges.Rows[type][1]!=null)
            {
                this.userType = privileges.Rows[type]["privilegeName"].ToString();
                try
                {
                    db.insertData(String.Format("INSERT INTO user VALUES('{0}','{1}',{2});", this.username, this.password, type + 1));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new Exception("privilege table not found!");
            }
            


        }

        private String getUserType()
        {
            return this.userType;
        }
        
        public void login()
        {
            DataTable dt = db.retrieveTable(String.Format("SELECT u.username, u.password, p.privilegeName FROM user AS u JOIN privilege as p ON u.privilegeId=p.id WHERE u.username='{0}' AND u.password='{1}';", this.username, this.password));
            if(dt.Rows.Count>0)
            {
                isLoggedIn = true;
                isAdmin = (dt.Rows[0]["privilegeName"].ToString() == "Administrator") ? true : false;
            }
            else
            {
                isLoggedIn = false;
            }
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
