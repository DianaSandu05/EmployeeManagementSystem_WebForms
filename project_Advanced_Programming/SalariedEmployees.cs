using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Advanced_Programming
{
   public class SalariedEmployees : Employees
    {
        private double salary;

        public double Salary 
        {
            get { return salary; }
            set { salary = value; }
        }
    }
}
