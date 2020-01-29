using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace IACLCSC_TestProject
{
    class Student
    {
        String firstName, middleName, lastName;
        DateTime dob;
        String address;
        String contactNo;
        String email;
        String gender;
        int course;
        int yearLevel;
        String picture;
        DbConnect db;
        public Student(String first_name, String middle_name, String last_name, 
            String date_of_birth, String gender, String address, String contact_no, 
            String f_email, int f_course, int f_yearLevel, String picture)
        {
            this.firstName = first_name;
            this.middleName = middle_name;
            this.lastName = last_name;
            this.dob = DateTime.Parse(date_of_birth);
            this.gender = gender;
            this.address = address;
            this.contactNo = contact_no;
            this.email = f_email;
            this.course = f_course;
            this.yearLevel = f_yearLevel;
            this.picture = picture;
            db = new DbConnect();
        }
        public void addRecord()
        {
            String sql = String.Format("INSERT INTO studentsinfo VALUES(NULL, '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8},{9},'{10}')",
                firstName,
                middleName, 
                lastName,
                gender,
                dob.ToShortDateString(),
                address,
                contactNo,
                email,
                course.ToString(),
                yearLevel.ToString(),
                picture);
            MessageBox.Show("SQL STATEMENT: " + sql);
            db.insertData(sql);
        }

        

    }
}
