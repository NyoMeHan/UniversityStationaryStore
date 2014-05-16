using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizLogic
{
     
    public class LoginCheck
    {
        Team4_ADEntities team = new Team4_ADEntities();

        public string login(int empid)
        {
            var x = (from m in team.Employees
                    where m.EmployeeID == empid
                    select m).First<Employee>();

            return x.EmployeeType.ToString();

        }
            
    }
}
