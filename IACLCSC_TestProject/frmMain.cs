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
    public partial class frmMain : Form
    {
        
        DataTable dt;
        User currentUser;
        DbConnect db;
        public frmMain(User u, DbConnect db)
        {
            InitializeComponent();
            currentUser = u;
            this.db = db;
            dt = new DataTable();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            String sql = "SELECT firstName AS 'First Name', middleName AS 'Middle Name', lastName AS 'Last Name', birthDate AS 'Date of Birth', YEAR(CURRENT_DATE) - YEAR(birthDate) AS 'Age', address AS 'Address', contactNo 'Contact No.', email AS 'Email',  course.courseName AS 'Course', year.yearLevel AS 'Year Level' FROM studentsinfo JOIN course ON studentsinfo.courseId=course.id JOIN year ON studentsinfo.yearId=year.Id;";
            dt = db.retrieveTable(sql);
            dataGridView1.DataSource = dt;
            if (!(currentUser.isAdminType()))
            {
                button1.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = String.Format("firstName LIKE '%{0}%'",textBox1.Text);
               

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmManage(currentUser, db).Show();
        }
    }
}

