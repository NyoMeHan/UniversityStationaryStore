using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizLogic;
using System.Web.Security;

namespace MobilePresentationLogic
{
    public partial class CommonLogin : System.Web.UI.Page
    {
        LoginCheck login = new LoginCheck();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    Label3.Text = "Invalid Login/UnAuthorised";
            //}
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //string str = login.login(Convert.ToInt32(txtEmpID.Text));


            if (Membership.ValidateUser(txtEmpID.Text, txtPassword.Text))
            {
                FormsAuthentication.SetAuthCookie(txtEmpID.Text, false);
                FormsAuthentication.RedirectFromLoginPage(txtEmpID.Text, false);
                
            }
            else
            {
                lblMessage.Text = "Invalid/UnAuthorized Login";
                lblMessage.Visible = true;
            }
            string[] str = Roles.GetRolesForUser(txtEmpID.Text);
           
            foreach (string st in str)
            {
                if (st == "DepartmentHead" || st == "DepartmentEmployee" || st == "DepartmentRepresentative")
                {
                  

                    Response.Redirect("DepartmentWelcomePage.aspx");
                }

                if (st == "StoreClerk" || st == "StoreManager" || st == "StoreSupervisor")
                {
                    Response.Redirect("StoreClerkWelcomePage.aspx");
                }
            }
         
        }


    }
}