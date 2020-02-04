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
        DataTable dtView;
        DataTable dtStudents;
        Student selectedStudent;

        public frmManage(User u, DbConnect db)
        {
            InitializeComponent();
            this.db = db;
            this.currentUser = u;
        }

        private void frmManage_Load(object sender, EventArgs e)
        {
            String sql = "SELECT firstName AS 'First Name', middleName AS 'Middle Name', lastName AS 'Last Name', gender AS 'Gender', birthDate AS 'Date of Birth', YEAR(CURRENT_DATE) - YEAR(birthDate) AS 'Age', address AS 'Address', contactNo 'Contact No.', email AS 'Email',  course.courseName AS 'Course', year.yearLevel AS 'Year Level' FROM studentsinfo JOIN course ON studentsinfo.courseId=course.id JOIN year ON studentsinfo.yearId=year.Id;";
            dtView = db.retrieveTable(sql);
            dtStudents = db.retrieveTable("SELECT * FROM studentsinfo");
            dataGridView1.DataSource = dtView;
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
                "[Email] LIKE '%{0}%' OR" +
                "[Course] LIKE '%{0}' OR " +
                "[Year Level] Like '%{0}%'",
                textBox1.Text, dob.Date.ToString(), age.ToString()
                );
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = filter;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new frmAddStudent().ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            new frmUpdateStudent(selectedStudent).ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.SelectedRows[0].Selected = true;
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count!=0)
            {
                selectedStudent = new Student(
                dataGridView1.SelectedRows[0].Cells["First Name"].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells["Middle Name"].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells["Last Name"].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells["Date of Birth"].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells["Gender"].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells["Address"].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells["Contact No."].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells["Email"].Value.ToString(),
                int.Parse(dtStudents.Rows[dataGridView1.SelectedRows[0].Index]["courseId"].ToString()),
                int.Parse(dtStudents.Rows[dataGridView1.SelectedRows[0].Index]["yearId"].ToString()),
                dtStudents.Rows[dataGridView1.SelectedRows[0].Index]["image"].ToString()
                );
                Console.WriteLine("Added Student!");
            }
            
            Console.WriteLine("Selection Changed! " + dataGridView1.CurrentRow.ToString());
        }
    }
}
