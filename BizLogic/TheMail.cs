using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizLogic
{
    public class TheMail
    {
        Team4_ADEntities team = new Team4_ADEntities();
        public string getFromEmail(int id)
        {
            var x = (from m in team.Employees
                    where m.EmployeeID == id
                    select m).First<Employee>();

            return x.Email;
        }


        public string getToEmail(string dept)
        {
            var x = (from m in team.Departments
                    where m.Department_Name == dept
                    select m).First<Department>();

            var y = (from c in team.Employees
                    where c.EmployeeID == x.Department_Head
                    select c).First<Employee>();

            return y.Email.ToString();

        }
    }
}
