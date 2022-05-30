using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Advanced_Programming
{
   public class HourlyEmployees: Employees
    {
        private double hourly_rate;
        public double Hourly_rate
        {
            get { return hourly_rate; }
            set { hourly_rate = value; }
        }

        private double hours;
        public double Hours
        {
            get { return hours; }
            set { hours = value; }
        }
    }
}
