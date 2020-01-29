using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace IACLCSC_TestProject
{
    public partial class frmUpdateStudent : Form
    {
        Image picture;
        String imagePath;

        public frmUpdateStudent()
        {
            InitializeComponent();
            imagePath = "C:\\Inventory System\\Records\\images\\";
        }
        private void btnAddImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            // the regex accepts the following image files: png, jpg, bmp
            Regex imageExt = new Regex(".*.png|.*.jpg|.*.jpeg|.*.bmp");
            
            try
            {
                String path = openFileDialog1.FileName;
                if (imageExt.IsMatch(path))
                {
                    picture = Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.BackgroundImage = picture;
                    
                }
                else
                {
                    throw new Exception("File selected is not a valid image file!");
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening image: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void adduser_Load(object sender, EventArgs e)
        {
            DbConnect db = new DbConnect();
            cmCourse.Items.Clear();
            DataTable courses = db.retrieveTable("SELECT courseName FROM course");
            foreach (DataRow r in courses.AsEnumerable())
            {
                cmCourse.Items.Add(r[0].ToString());
            }
            cmYearLvl.Items.Clear();
            DataTable yearLvl = db.retrieveTable("SELECT yearLevel from year");
            foreach (DataRow r in yearLvl.AsEnumerable())
            {
                cmYearLvl.Items.Add(r[0].ToString());
            }
        }

        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //validate the input
            //catch empty textbox
            Exception emptyField = new Exception("Fields must not be empty!");
            Exception invalidEmail = new Exception("Email Address is not in valid format!");
            Exception invalidContact = new Exception("Contact number is not in a valid format!(xxx-xxx-xxxx)");
            Exception invalidDob = new Exception("Student must be at least 16 years old!");
            try
            {
                if (txtFirstName.Text == "")
                    throw emptyField;
                if (txtMiddleName.Text == "")
                    throw emptyField;
                if (txtLastName.Text == "")
                    throw emptyField;
                if (txtAddress.Text == "")
                    throw emptyField;
                if (txtContactNo.Text == "")
                    throw emptyField;
                if (txtEmail.Text == "")
                    throw emptyField;
                
                //TODO: validate DOB 
                DateTime dob = dateTimePicker1.Value;
                int age = DateTime.Now.Year - dob.Year;
                if(age<16)
                    throw invalidDob;

                //TODO: validate email
                Regex email_regex = new Regex(@"^[\w\d\-_]*@[\w\d]+.\w{2,3}$");
                if (!(email_regex.IsMatch(txtEmail.Text)))
                {
                    throw invalidEmail;
                }
                //TODO: validate contact no.
                Regex contact = new Regex(@"^\d{3}\-\d{3}\-\d{4}");
                if (!(contact.IsMatch(txtContactNo.Text)))
                {
                    throw invalidContact;
                }
                //save the image to a folder in C:/ Drive
                if (!(Directory.Exists(imagePath)))
                    Directory.CreateDirectory(imagePath);
                picture.Save(imagePath + openFileDialog1.SafeFileName.ToString());

                //TODO: make student, add to Database
                Student stud = new Student(
                    txtFirstName.Text, 
                    txtMiddleName.Text, 
                    txtLastName.Text, 
                    dob.ToShortDateString(),
                    txtGender.Text, 
                    txtAddress.Text, 
                    txtContactNo.Text, 
                    txtEmail.Text, 
                    cmCourse.SelectedIndex+1, 
                    cmYearLvl.SelectedIndex+1, 
                    imagePath + openFileDialog1.SafeFileName.ToString()
                    );

                stud.addRecord();
                
                //Success
                MessageBox.Show("Added new record to database!", "Add Success", MessageBoxButtons.OK);
                //MessageBox.Show(openFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding Student: " + ex.Message, "Error!", MessageBoxButtons.OK);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
