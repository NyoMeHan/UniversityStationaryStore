using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizLogic;

namespace MobilePresentationLogic
{
   
    public partial class ChangeCollectionPt : System.Web.UI.Page
    {
        ChangeCollectionPtBLL bll = new ChangeCollectionPtBLL();
        CollectionBLL collect = new CollectionBLL();
        EmployeeBLL emp = new EmployeeBLL();
       string deptCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["loginUser"]);
            deptCode = bll.getcurrentdeparmentcode(id);
            if (!IsPostBack)
            {
                String curr = bll.GetCurrCollectionPt(deptCode);
                txtCurrCollectionPt.Text = curr.ToString();

                IList list = bll.CollectionPt();
                ddlCollectionPt.DataSource = list;
                ddlCollectionPt.DataTextField = "Place";
                ddlCollectionPt.DataValueField = "CollectionID";
                ddlCollectionPt.DataBind();

            }

        }
        protected void btnChange_Click(object sender, EventArgs e)
        {
            UpdateCollectionPt();
        }

        public void UpdateCollectionPt()
        {
            int id = Convert.ToInt32(ddlCollectionPt.SelectedValue);
            bll.UpdateDeptInfo(deptCode, id);
            lblMessage.Text = "Update Successful";


            int currentid = Convert.ToInt32(Session["loginUser"]);
            
            string emailsubject = "Change Collection Point";
            string emailBody = ddlCollectionPt.SelectedItem.Text.ToString();

            SendEmailToClerk(currentid, emailBody, emailsubject);
        }

        public void SendEmailToClerk(int empid, string body, string subject)
        {
            
             EmployeeBLL empbll = new EmployeeBLL();
            Employee currentuser = new Employee();
            //Employee storeclerk = new Employee();
            currentuser = empbll.GetEmployeeById(empid);
            string toemail = bll.getstoreClerk();

            string bodymsg = "New collection point is :"+ "<br/>" + body + "<br/>With Regards,<br/>" + currentuser.EmployeeName;

            bll.SendEmailToStore(toemail, currentuser.Email, bodymsg, subject);

        }


    }
}