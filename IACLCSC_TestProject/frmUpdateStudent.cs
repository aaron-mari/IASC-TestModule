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
        Student currentStudent;
        DbConnect db;
        DataTable courses, yearLevels;
        String imagePath;
        Image picture;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Use the same validations as the Add Form
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
                if (age < 16)
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

                currentStudent.updateRecord(
                    txtFirstName.Text, 
                    txtMiddleName.Text,
                    txtLastName.Text,
                    dateTimePicker1.Value,
                    txtGender.Text,
                    txtAddress.Text,
                    txtContactNo.Text,
                    txtEmail.Text,
                    cmbCourse.SelectedIndex+1,
                    cmbYearLevel.SelectedIndex+1,
                    imagePath + openFileDialog1.SafeFileName.ToString());
                //Success
                MessageBox.Show("Sucessfuly updated record!", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message, "Error!", MessageBoxButtons.OK);
            }

            //Success; close form
            this.Close();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            // the regex accepts the following image files: png, jpg, bmp
            Regex imageExt = new Regex(".*.png|.*.jpg|.*.jpeg|.*.bmp");

            try
            {
                String path = openFileDialog1.FileName;
                if(!(path==""))
                {
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
                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening image: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmUpdateStudent_Load(object sender, EventArgs e)
        {

        }

        public frmUpdateStudent(Student stud)
        {
            InitializeComponent();
            currentStudent = stud;
            db = new DbConnect();
            courses = db.retrieveTable("SELECT courseName FROM course");
            yearLevels = db.retrieveTable("SELECT yearLevel FROM yearLevel");
            imagePath = @"C:\\Inventory System\\Records\\images\\";

            foreach (DataRow r in courses.AsEnumerable())
            {
                cmbCourse.Items.Add(r[0].ToString());
            }
            foreach(DataRow r in yearLevels.AsEnumerable())
            {
                cmbYearLevel.Items.Add(r[0].ToString());
            }

            //set the fields
            txtFirstName.Text = currentStudent.FirstName;
            txtMiddleName.Text = currentStudent.MiddleName;
            txtLastName.Text = currentStudent.LastName;
            txtGender.Text = currentStudent.Gender;
            dateTimePicker1.Value = currentStudent.Dob;
            txtAddress.Text = currentStudent.Address;
            txtContactNo.Text = currentStudent.ContactNo;
            txtEmail.Text = currentStudent.Email;
            //combo box is 0 based
            cmbCourse.SelectedIndex= currentStudent.Course-1;
            cmbYearLevel.SelectedIndex = currentStudent.YearLevel-1;
            try
            {
                picture = Image.FromFile(currentStudent.Picture);
                pictureBox1.BackgroundImage = picture;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot load picture: " + ex.Message, "Error loading picture", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
