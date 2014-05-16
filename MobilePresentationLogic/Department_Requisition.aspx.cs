#region "Version Information"
/* Form Name       : Department_Requisition.aspx
' Created By       : ZarNiMMM
' Description      : Department requisition done by Department Head
' Created Date     : 05/09/2013
' Version History  : 1.0
 * */
#endregion

#region "using"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizLogic;

#endregion

namespace MobilePresentationLogic
{
    public partial class Department_Requisition : System.Web.UI.Page
    {
        EmployeeRequBLL emreqbll = new EmployeeRequBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                gvRequest_DataBind();

            }
        }


        protected void gvRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRequest.PageIndex = e.NewPageIndex;
            gvRequest_DataBind();
        }
        protected void btnReject_Click(object sender, EventArgs e)
        {
            bool CheckTrue = false;
            try
            {
                for (int r = 0; r < gvRequest.Rows.Count; r++) //find checkbox checked or not
                {
                    CheckBox chkResult = (CheckBox)gvRequest.Rows[r].Cells[0].FindControl("chkResult1");
                    if (chkResult.Checked == true)
                    {

                        CheckTrue = true;
                    }
                }
                if (CheckTrue != true)
                {
                    string script = "alert('At least one check box need to selected to delete process.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "test", script, true);
                }
                else
                {
                    DateTime processdate = DateTime.Now;

                    for (int r = 0; r < gvRequest.Rows.Count; r++) //find checkbox checked or not
                    {
                        CheckBox chkResult = (CheckBox)gvRequest.Rows[r].Cells[0].FindControl("chkResult1");
                        if (chkResult.Checked == true)
                        {

                            string emp_reqID = gvRequest.DataKeys[r].Value.ToString();

                            updateStatustoEmpReq(Convert.ToInt32(emp_reqID), "Rejected");

                            String body = "Your registration have been rejected! \n The reason is " + txtRejectInfo.Text + "\n Thanks.\n" + "Best Regards,\n";
                            String subject = "Rejected your Stationery Request ";
                            String employeeid = gvRequest.DataKeys[r].Values["EmployeeID"].ToString();
                            SendNotification(Convert.ToInt32(employeeid), body, subject);
                        }
                    }

                }
                gvRequest_DataBind();
            }

            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            bool CheckTrue = false;
            try
            {
                for (int r = 0; r < gvRequest.Rows.Count; r++) //find checkbox checked or not
                {
                    CheckBox chkResult = (CheckBox)gvRequest.Rows[r].Cells[0].FindControl("chkResult1");
                    if (chkResult.Checked == true)
                    {

                        CheckTrue = true;
                    }
                }
                if (CheckTrue != true)
                {
                    string script = "alert('At least one check box need to selected to delete process.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "test", script, true);
                }
                else
                {
                    DepartmentBLL deptbll = new DepartmentBLL();
                    //int empid = 1004;// to update empid
                    int empid = Convert.ToInt32(Session["loginUser"]);

                    Department depart = deptbll.getDeptCodebyEmpID(empid); //need to update session value of employee id


                    DepartmentRequBLL deptreqBll = new DepartmentRequBLL();
                    DateTime processdate = DateTime.Now;

                    int dep_reqid = deptreqBll.insertHeaderRecord(processdate, "current", depart.Department_Code); //create header record first

                    if (dep_reqid > 0)
                    {
                        for (int r = 0; r < gvRequest.Rows.Count; r++) //find checkbox checked or not
                        {
                            CheckBox chkResult = (CheckBox)gvRequest.Rows[r].Cells[0].FindControl("chkResult1");
                            if (chkResult.Checked == true)
                            {

                                string emp_reqID = gvRequest.DataKeys[r].Values["Emp_ReqID"].ToString();
                                deptreqBll.insertDetailRecord(dep_reqid, Convert.ToInt32(emp_reqID), processdate);//insert detail records
                                updateStatustoEmpReq(Convert.ToInt32(emp_reqID), "Approved");//update request status

                                String body = "Your registration have been approved! \n" + txtRejectInfo.Text + "\n Thanks \nBest Regards,\n";
                                String subject = "Approved your Stationery Request ";
                                String employeeid = gvRequest.DataKeys[r].Values["EmployeeID"].ToString();
                                SendNotification(Convert.ToInt32(employeeid), body, subject);
                            }
                        }
                    }
                }
                gvRequest_DataBind();
            }

            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (btnSelectAll.Text == "Select All")
            {
                for (int r = 0; r < gvRequest.Rows.Count; r++)
                {
                    CheckBox chkResult = (CheckBox)gvRequest.Rows[r].Cells[0].FindControl("chkResult1");
                    chkResult.Checked = true;

                }
                btnSelectAll.Text = "UnSelect All";

            }

            else
            {
                for (int r = 0; r < gvRequest.Rows.Count; r++)
                {
                    CheckBox chkResult = (CheckBox)gvRequest.Rows[r].Cells[0].FindControl("chkResult1");
                    chkResult.Checked = false;
                }
                btnSelectAll.Text = "Select All";
            }
        }

        void gvRequest_DataBind()
        {
            DepartmentBLL deptbll = new DepartmentBLL();

           // int empid = 1004; //to update empid
            int empid = Convert.ToInt32(Session["loginUser"]);

            Department depart = deptbll.getDeptCodebyEmpID(empid);
            gvRequest.DataSource = emreqbll.GetPendingRequest(depart.Department_Code);
            gvRequest.DataBind();

        }
        void updateStatustoEmpReq(int reqid, string statusupdate)
        {
            EmployeeRequBLL empreqbll = new EmployeeRequBLL();
            empreqbll.updateStatus(reqid, statusupdate); //update employee request status.
        }

        void SendNotification(int empid, string body, string subject)
        {
            DepartmentRequBLL deptreqBll = new DepartmentRequBLL();
            //int currentuserid = Convert.ToInt32(Session["loginUser"]);

           //int currentuserid = 1004; //to update empid
            int currentuserid = Convert.ToInt32(Session["loginUser"]);

            EmployeeBLL empbll = new EmployeeBLL();
            Employee employeeinfo = new Employee();
            Employee currentuserinfo = new Employee();

            employeeinfo = empbll.getEmployeebyempid(empid);

            currentuserinfo = empbll.getEmployeebyempid(currentuserid); //to update employee type
            string body1 = body + currentuserinfo.EmployeeName;


            deptreqBll.sendNotificationToEmployee(employeeinfo.Email, currentuserinfo.Email, body1, subject);

        }

        protected void gvRequest_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)  //detail grid Databind
            {
                #region Detail Grid DataBinding
                string reqid = gvRequest.DataKeys[e.Row.RowIndex].Value.ToString();
                var detailitem = emreqbll.GetDetailRecords(Convert.ToInt32(reqid));
                GridView reqDetail = e.Row.FindControl("gvItemDetail") as GridView;
                reqDetail.DataSource = detailitem;
                reqDetail.DataBind();
                #endregion
            }
        }

        protected void gvItemDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            for (int i = 0; i < gvRequest.Rows.Count; i++)
            {
                GridView gvitemdetail = (GridView)gvRequest.Rows[1].FindControl("gvItemDetail");

                gvitemdetail.PageIndex = e.NewPageIndex;
                gvitemdetail.DataBind();
            }

        }
}
}