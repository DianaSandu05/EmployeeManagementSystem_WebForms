using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Advanced_Programming
{
  public  class CommissionEmployees : Employees
    {


        private double base_salary;
        public double Base_salary {
            get { return base_salary; }
            set { base_salary = value; }
        }


        private double sales;
        public double Sales
        {
            get { return sales; }
            set { sales = value; }
        }

        private double rate;
        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }
    }
}
