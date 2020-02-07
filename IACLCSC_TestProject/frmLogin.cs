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
        User user;
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
                try
                {
                    user = new User(txtUsername.Text, txtPassword.Text);
                    user.login();
                    if (user.IsLoggedIn)
                    {
                        new frmMain(user, db).ShowDialog();
                    }
                    else
                    {
                        throw new Exception("Username/password not found in database!");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error logging in: " + ex.Message, "Cannot login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            
            
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
