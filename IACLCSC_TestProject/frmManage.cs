using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IACLCSC_TestProject
{
    public partial class frmManage : Form
    {
        User currentUser;
        DbConnect db;
        DataTable dt;
        Student selectedStudent;

        public frmManage(User u, DbConnect db)
        {
            InitializeComponent();
            this.db = db;
            this.currentUser = u;
        }

        private void frmManage_Load(object sender, EventArgs e)
        {
            String sql = "SELECT firstName AS 'First Name', middleName AS 'Middle Name', lastName AS 'Last Name', birthDate AS 'Date of Birth', YEAR(CURRENT_DATE) - YEAR(birthDate) AS 'Age', address AS 'Address', contactNo 'Contact No.', email AS 'Email',  course.courseName AS 'Course', year.yearLevel AS 'Year Level' FROM studentsinfo JOIN course ON studentsinfo.courseId=course.id JOIN year ON studentsinfo.yearId=year.Id;";
            dt = db.retrieveTable(sql);
            dataGridView1.DataSource = dt;
        } 

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = String.Format("firstName LIKE '%{0}%'", textBox1.Text);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new frmUpdateStudent().ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
