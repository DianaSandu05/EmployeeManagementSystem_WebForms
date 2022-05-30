using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Advanced_Programming
{
   public class Employees
    {
        private String firstname;
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        private String lastname;
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        private String gender;
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        private DateTime dob;
        public DateTime Dob
        {
            get { return dob; }
            set { dob = value; }
        }
        private String address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private String phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private String department;
        public string Department
        {
            get { return department; }
            set { department = value; }
        }
        private string nino;
        public string NiNo
        {
            get { return nino; }
            set { nino = value; }
        }
        private String picture;
        public string Picture
        {
            get { return picture; }
            set { picture = value; }
        }
    }
}
