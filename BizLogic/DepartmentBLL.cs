using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizLogic
{
    public class DepartmentBLL
    {
        Team4_ADEntities entity = new Team4_ADEntities();

        //created by ZarNiMMM on 05/09/2013
        public Department getDeptCodebyEmpID(int employeeid)
        {


            //Department departmentreturn = entity.Departments.Join(entity.Employees,dept => dept.Department_Code,emp =>emp.DepartmentCode,(dept,emp)=> new {dept = dept,emp=emp});
            var department = (from dept in entity.Departments join emp in entity.Employees on dept.Department_Code equals emp.DepartmentCode where emp.EmployeeID == employeeid select dept );


            return department.First() ;


        }

        #region 
        public List<Department> GetAllDepartment()
        {
            //count = this.entity.Departments.Count();
            return this.entity.Departments.ToList();
        }

        public List<string> GetDeptName()
        {
            var deptnames = (from r in entity.Departments select r.Department_Name);
            return deptnames.ToList<string>();
        }

        public List<string> GetDeptCode()
        {
            var deptcode = (from r in entity.Departments select r.Department_Code);
            return deptcode.ToList<string>();
        }

        public Department GetDepartmentByCode(string c)
        {
            Department d = entity.Departments.First<Department>(x => x.Department_Code == c);
            return d;
        }

        public string UpdateDepartmentInfo(Department updateDeptInfo)
        {
            //Department updateInfo = this.GetDepartmentByCode(updateDeptInfo.Department_Code);

            Department updateInfo = entity.Departments.First(c => c.Department_Code == updateDeptInfo.Department_Code);

            if (updateInfo != null)
            {
                //Debug.WriteLine("DeptBLL update if loop.");
                //updateInfo.Department_Code = updateDeptInfo.Department_Code;
                updateInfo.Department_Name = updateDeptInfo.Department_Name;
                updateInfo.Contact_Person = updateDeptInfo.Contact_Person;
                updateInfo.Phone = updateDeptInfo.Phone;
                updateInfo.Fax = updateDeptInfo.Fax;
                updateInfo.Department_Head = updateDeptInfo.Department_Head;
                updateInfo.CollectionID = updateDeptInfo.CollectionID;
                //updateInfo.CollectionPoint = updateDeptInfo.CollectionPoint;

            }
            this.entity.SaveChanges();
            string s = "Update is successful";
            return s;
        }

        public string addNewDept(string code, string name, int contact, int ph, int fax, int head, int col)
        {
            Department dept = new Department();

            dept.Department_Code = code;
            dept.Department_Name = name;
            dept.Contact_Person = contact;
            dept.Phone = ph;
            dept.Fax = fax;
            dept.Department_Head = head;
            dept.CollectionID = col;

            entity.Departments.AddObject(dept);
            entity.SaveChanges();

            string z = "New Dept \"" + code + "\" is added.";
            return z;

        }
        #endregion


    }
}
