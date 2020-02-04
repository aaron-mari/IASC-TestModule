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
            String sql = "SELECT firstName AS 'First Name', middleName AS 'Middle Name', lastName AS 'Last Name', gender AS 'Gender', birthDate AS 'Date of Birth', YEAR(CURRENT_DATE) - YEAR(birthDate) AS 'Age', address AS 'Address', contactNo 'Contact No.', email AS 'Email',  course.courseName AS 'Course', year.yearLevel AS 'Year Level' FROM studentsinfo JOIN course ON studentsinfo.courseId=course.id JOIN year ON studentsinfo.yearId=year.Id;";
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
            int course, year, age;
            DateTime dob;
            if (!(int.TryParse(textBox1.Text, out course)))
                course = 0;
            if (!(int.TryParse(textBox1.Text, out year)))
                year = 0;
            if (!(DateTime.TryParse(textBox1.Text, out dob)))
                dob = DateTime.Now;
            if (!(int.TryParse(textBox1.Text, out age)))
                age = 0;

            String filter = String.Format(
                "[First Name] LIKE'%{0}%' OR" +
                "[Middle Name] LIKE '%{0}%' OR" +
                "[Last Name] LIKE '%{0}%' OR" +
                "[Gender] LIKE '%{0}%' OR" +
                "[Date of Birth]=#{1}# OR" +
                "[Address] LIKE '%{0}%' OR" +
                "[Age]={2} OR" +
                "[Contact No.] LIKE '%{0}%' OR" +
                "[Email] LIKE '%{0}%' OR"+
                "[Course] LIKE '%{0}' OR " +
                "[Year Level] Like '%{0}%'",
                textBox1.Text, dob.Date.ToString(), age.ToString()
                );
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = filter;
            //(dataGridView1.DataSource as DataView).RowFilter = String.Format("('First Name'LIKE'%{0}%') OR ('Middle Name'LIKE'%{0}%') OR ('Last Name'LIKE'%{0}%')",textBox1.Text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmManage(currentUser, db).Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

