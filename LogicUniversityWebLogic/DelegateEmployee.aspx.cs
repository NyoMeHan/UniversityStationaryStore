#region "Version Information"
/* Form Name       : DelegateEmployee.aspx
' Created By       : Seinn Nu Aye
' Description      : Delegate Employee when need
' Version History  : 1.0
 * */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizLogic;

namespace LogicUniversityWebLogic
{
    public partial class DelegateEmployee : System.Web.UI.Page
    {
        public string emp_Nmae = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            EmployeeBLL empBll = new EmployeeBLL();
            //Employee emp = new Employee();
            //emp.EmployeeName = txtEmpName.Text;
             emp_Nmae = txtEmpName.Text; 
           // emp.TempType = Convert.ToString(ddlEmpType.SelectedItem.Text);
            string Temp_role = "DeptHead";
           // emp.FromDate = DateTime.ParseExact(Convert.ToString(txtFromDate.Text), "M/d/yyyy", null);
            DateTime fromDate = DateTime.ParseExact(Convert.ToString(txtFromDate.Text), "M/d/yyyy", null);
            //emp.ToDate = DateTime.ParseExact(Convert.ToString(txtToDate.Text), "M/d/yyyy", null);
            DateTime toDate = DateTime.ParseExact(Convert.ToString(txtToDate.Text), "M/d/yyyy", null);
            string s = empBll.DelegateEmployeeInfo(emp_Nmae, Temp_role, fromDate, toDate);


            string assigned_emp_Name = txtEmpName.Text; // (need to change ddl for Employee Namel and ID for related Dept)
            int assigned_emp_Id = empBll.GetEmployeeIDByName(assigned_emp_Name);
            string body_info = assigned_emp_Name + "is assigned temporarily as Department Head";
            string subject_info = "Empoloyee Delegation";
            string email_msg = SendEmailNotification(assigned_emp_Id, body_info, subject_info);

            lblmsg.Text = email_msg + s;
        }

        protected void btnRevoke_Click(object sender, EventArgs e)
        {
            EmployeeBLL empBll = new EmployeeBLL();

            string empName = txtEmpName.Text;
            //DateTime endDate = Convert.ToDateTime(empBll.GetDelegateEndDate(empName));
            //lblDatetest.Text = empBll.GetDelegateEndDate(empName);
            //DateTime currentDate = DateTime.Today;
            //lblCurretDate.Text = currentDate.ToString();

            string revoke_info = empBll.RevokeEmployeeDelegation(empName);
            lblmsg.Text = revoke_info;

            // Response.Redirect("RevokeEmployee.aspx");

        }

        private string SendEmailNotification(int assignedEmpId, string body, string subject)
        {
            EmployeeBLL emp_Bll = new EmployeeBLL();

            Employee emp_info = new Employee();
            emp_info = emp_Bll.GetEmp_Info(assignedEmpId);  //get emp_info to assign

            int currentUser_Id = Convert.ToInt32(Session["loginUser"]); ;
            Employee currentUser_info = new Employee();
            currentUser_info = emp_Bll.GetEmp_Info(currentUser_Id); ////get emp_info(current logined user)

            string body_msg = "To" + emp_info.EmployeeName + body + "From" + currentUser_info.EmployeeName;
            string ToEmail = emp_Bll.getToEmailid(emp_Nmae);

            //public void sendEmailNotification(string toEmail, string fromEmail, string body, string subject)
            string msg = emp_Bll.sendEmailNotification(ToEmail, currentUser_info.Email, body_msg, subject);
            return msg;

        }
    }
}