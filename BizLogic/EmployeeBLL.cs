using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Web;

namespace BizLogic
{
    public class EmployeeBLL
    {
        //Team4_ADEntities entity = new Team4_ADEntities();
        //Created by SeinnNA
        Team4_ADEntities edm = null;

        public EmployeeBLL()
        {
            this.edm = new Team4_ADEntities();
        }

        public EmployeeBLL(Team4_ADEntities edm)
        {
            this.edm = edm;
        }

        public List<Employee> GetEmployee()
        {
            return this.edm.Employees.ToList();
        }

        public string DelegateEmployeeInfo(string empName, string temp_role, DateTime fromDate, DateTime toDate)
        {
            Employee TempEmpInfo = edm.Employees.FirstOrDefault(m => m.EmployeeName == empName);
            if (TempEmpInfo != null)
            {

                //TempEmpInfo.EmployeeName = empInfo.EmployeeName;
                TempEmpInfo.TempType = temp_role;
                TempEmpInfo.FromDate = fromDate;
                TempEmpInfo.ToDate = toDate;
            }
            this.edm.SaveChanges();
            string info = "Delegation Successful";
            return info;
        }

        public string GetDelegateEndDate(string name)
        {
            //var list = (from r in edm.adjustmentId_list_View where r.Authorized_By == "Manager"  select r);
            Employee info = edm.Employees.FirstOrDefault(e => e.EmployeeName == name);
            //Employee emp_info = (from e in edm.employee_View where e.EmployeeName == name select e);

            string date = info.ToDate.ToString();
            return date;
        }

        public string RevokeEmployeeDelegation(string emp_name)
        {

            Employee emp_info = edm.Employees.FirstOrDefault(e => e.EmployeeName == emp_name);
            string s;
            if (emp_info != null )
            {
                emp_info.FromDate = null;
                emp_info.ToDate = null;
                emp_info.TempType = null;
                this.edm.SaveChanges();
                s = "Revoke Employee is Successful";
            }
            else { s = "Revoke Employee is not  Successful"; }

            return s;
        }
        //ended by SeinnNA

        //created by ZarniMMM on 06/09/2013
        public Employee getEmailAddressbyempType(string dept_code, string empType)
        {

            Employee email = edm.Employees.First<Employee>(m => (m.DepartmentCode == dept_code) && (m.EmployeeType == empType.ToLower()));
            return email;

        }

        public Employee getEmployeebyempid(int empid)
        {

            Employee email = edm.Employees.First<Employee>(m => (m.EmployeeID == empid));
            return email;

        }
        //ended by ZarniMMM

        #region

        public Employee GetAuthorizedPersonInfo(int authorizedPersonID)
        {
            Employee emp_info = edm.Employees.FirstOrDefault(e => e.EmployeeID == authorizedPersonID);

            return emp_info;
        }

        public int GetEmployeeIDByName(string assigned_empName)
        {
            Employee emp_info = edm.Employees.FirstOrDefault(e => e.EmployeeName == assigned_empName);
            int Id = emp_info.EmployeeID;
            return Id;
        }

        public Employee GetEmp_Info(int emp_ID)
        {
            Employee Emp_Info = edm.Employees.FirstOrDefault(e => e.EmployeeID == emp_ID);
            return Emp_Info;
        }

        public string sendEmailNotification(string toEmail, string fromEmail, string body, string subject)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(toEmail);
                // mailMessage.From = new MailAddress("Jason@LogicUniversity");
                mailMessage.From = new MailAddress(fromEmail);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                //SmtpClient smtpClient = new SmtpClient("mail.singnet.com.sg");
                SmtpClient smtpClient = new SmtpClient("lynx.iss.nus.edu.sg");
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                /// Response.Write("Could not send the e-mail - error: " + ex.Message);
            }
            return "Sending Email Notification is successful";
        }

        public List<Employee> GetAllEmployees()
        {
            return this.edm.Employees.ToList();
        }


        public string getToEmailid(string name)
        {
            var x = (from m in edm.Employees
                    where m.EmployeeName == name
                    select m).First<Employee>();

            return x.Email;
        }

        public Employee GetEmployeeById(int id)
        {
            var q = (from r in edm.Employees where r.EmployeeID == id select r);
            Employee e = new Employee();
            e = q.First<Employee>();
            return e;
        }

        public List<Employee> GetEmployeesByDept(string dcode)
        {
            var q = (from r in edm.Employees where r.DepartmentCode.Equals(dcode) select r);
            return q.ToList();
        }

        public List<Employee> GetEmployeeByDept(string dcode)
        {
            var q = (from r in edm.Employees where r.DepartmentCode.Equals(dcode) select r);
            return q.ToList();
        }

        public List<string> GetEmpNamesByDept(string dcode)
        {
            var names = (from r in edm.Employees where r.DepartmentCode.Equals(dcode) select r.EmployeeName);
            return names.ToList<string>();
        }


        public List<string> GetEmpNames()
        {
            var names = (from r in edm.Employees select r.EmployeeName);
            return names.ToList<string>();
        }

        public string GetEmployeeNameById(int id)
        {
            var query = (from r in edm.Employees where r.EmployeeID == id select r);
            Employee e = new Employee();
            e = query.First<Employee>();
            string name = e.EmployeeName;

            return name;
        }

        public int GetEmpIdByName(string name)
        {
            var query = (from r in edm.Employees where r.EmployeeName == name select r);
            Employee e = new Employee();
            e = query.First<Employee>();
            int id = e.EmployeeID;

            return id;
        }
        #endregion
    }
}
