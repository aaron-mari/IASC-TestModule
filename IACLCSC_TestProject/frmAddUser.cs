using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace IACLCSC_TestProject
{
    public partial class frmAddUser : Form
    {
        User user;
        public frmAddUser()
        {
            InitializeComponent();
            DbConnect db = new DbConnect();
            DataTable privs = db.retrieveTable("SELECT privilegeName from privilege");
            List<String> privileges = new List<String>();
            foreach(DataRow row in privs.AsEnumerable())
            {
                privileges.Add(row["privilegeName"].ToString());
            }
            cmbUserType.DataSource = privileges;
        }
        private void checkPassword(String password)
        {
            Regex hasNum = new Regex(@"\d");
            Regex hasLcLetter = new Regex(@"[a-z]");
            Regex hasCapLetter = new Regex(@"[A-Z]");
            Regex hasSpecChar = new Regex(@"[!@#\$%]");

            Exception needsNum = new Exception("Password must have at least 1 number!");
            Exception needsCap = new Exception("Password must have at least 1 capital letter!");
            Exception needsLow = new Exception("Password must have at least 1 lowercase letter!");
            Exception needsSpec = new Exception("Password must have at least 1 of the following special characters: !@#$%");
            
            if (!(hasNum.IsMatch(password)))
                throw needsNum;
            else if (!(hasLcLetter.IsMatch(password)))
                throw needsLow;
            else if (!(hasCapLetter.IsMatch(password)))
                throw needsCap;
            else if (!(hasSpecChar.IsMatch(password)))
                throw needsSpec;
            
        }
        
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            Exception emptyField = new Exception("Fields must not be empty!");
            Exception notSamePassword = new Exception("Passwords do not match!");
            
            try
            {
                if (txtUsername.Text == "" || mskPass.Text == "" || mskConfirmPass.Text == "")
                    throw emptyField;
                if (mskPass.Text != mskConfirmPass.Text)
                    throw notSamePassword;
                else
                    checkPassword(mskPass.Text);
                User user = new User(txtUsername.Text, mskPass.Text, cmbUserType.SelectedIndex);
                MessageBox.Show("Sucessfully added user!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void lblUsertype_Click(object sender, EventArgs e)
        {

        }

        private void cmbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblConfirm_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }
    }
}
