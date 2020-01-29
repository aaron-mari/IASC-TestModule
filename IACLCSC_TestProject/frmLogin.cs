using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace IACLCSC_TestProject
{
    public partial class frmLogin : Form
    {
        DbConnect db;
        DataTable dt;
        public frmLogin()
        {
            InitializeComponent();
            db = new DbConnect();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Form Validation
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Fields must not be empty!", "Error Logging in!", MessageBoxButtons.OK);
            }
            else
            {
                // check to database
            dt = db.retrieveTable(String.Format("SELECT * FROM user WHERE username='{0}' AND password='{1}';", txtUsername.Text, txtPassword.Text));
            if(dt.Rows.Count>0)
            {
                User user = new User(txtUsername.Text, txtPassword.Text, db);
                if(dt.Rows[0][2].ToString() == "1")
                    user.setAdminType();
                    
                new frmMain(user, db).ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid user!");
            }
            }
            
            
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
