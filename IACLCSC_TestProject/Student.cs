using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace IACLCSC_TestProject
{
    public class Student
    {
        int id;
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

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return middleName;
            }

            set
            {
                middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public DateTime Dob
        {
            get
            {
                return dob;
            }

            set
            {
                dob = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string ContactNo
        {
            get
            {
                return contactNo;
            }

            set
            {
                contactNo = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }

        public int Course
        {
            get
            {
                return course;
            }

            set
            {
                course = value;
            }
        }

        public int YearLevel
        {
            get
            {
                return yearLevel;
            }

            set
            {
                yearLevel = value;
            }
        }

        public string Picture
        {
            get
            {
                return picture;
            }

            set
            {
                picture = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public Student(String first_name, String middle_name, String last_name, 
            String date_of_birth, String gender, String address, String contact_no, 
            String f_email, int f_course, int f_yearLevel, String picture)
        {
            this.FirstName = first_name;
            this.MiddleName = middle_name;
            this.LastName = last_name;
            this.Dob = DateTime.Parse(date_of_birth);
            this.Gender = gender;
            this.Address = address;
            this.ContactNo = contact_no;
            this.Email = f_email;
            this.Course = f_course;
            this.YearLevel = f_yearLevel;
            this.Picture = picture;
            db = new DbConnect();
        }
        public Student()
        {
            FirstName = "";
            MiddleName = "";
            LastName = "";
            Dob = DateTime.MinValue;
            Gender = "";
            Address = "";
            ContactNo = "";
            Email = "";
            course = 1;
            YearLevel = 1;
            Picture = "";
            db = new DbConnect();

        }
        public void addRecord()
        {
            String sql = String.Format("INSERT INTO studentsinfo VALUES(NULL, '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8},{9},'{10}')",
                FirstName,
                MiddleName, 
                LastName,
                Gender,
                Dob.ToShortDateString(),
                Address,
                ContactNo,
                Email,
                Course.ToString(),
                YearLevel.ToString(),
                Picture);
            MessageBox.Show("SQL STATEMENT: " + sql);
            db.insertData(sql);
        }

        public void updateRecord()
        {
            String sql = String.Format("UPDATE studentsinfo SET firstName='{1}', middleName='{2}', lastName='{3}' WHERE id={0}",
                this.id, this.firstName, this.middleName,this.lastName);
            db.insertData(sql);
        }
        

    }
}
