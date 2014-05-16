using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizLogic;
using System.Web.Security;

namespace LogicUniversityWebLogic
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
            string str = login.login(Convert.ToInt32(txtEmpID.Text));
            Boolean check = false;
            /*
            if (Membership.ValidateUser(txtEmpID.Text, txtPassword.Text))
            {
                FormsAuthentication.SetAuthCookie(txtEmpID.Text, false);
                FormsAuthentication.RedirectFromLoginPage(txtEmpID.Text, false);
                
            }
            else
            {
                Label3.Text = "Invalid/UnAuthorized Login";
            }
             * 
             * 
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
             * */

            if (str == "head" || str == "staff")
            {
                FormsAuthentication.SetAuthCookie(txtEmpID.Text, false);
                FormsAuthentication.RedirectFromLoginPage(txtEmpID.Text, false);
                Session["loginUser"] = txtEmpID.Text;
                Response.Redirect("DepartmentWelcomePage.aspx"); check = true;
            }
            else if (str == "StoreClerk" || str == "Manager" || str == "Supervisor")
            
            {
                FormsAuthentication.SetAuthCookie(txtEmpID.Text, false);
                FormsAuthentication.RedirectFromLoginPage(txtEmpID.Text, false);
                Session["loginUser"] = txtEmpID.Text;
                Response.Redirect("StoreClerkWelcomePage.aspx"); check = true;
            }
            else
            {
                Label3.Text = "Invalid/UnAuthorized Login";
                Response.Redirect("CommonLogin.aspx"); check = false;
            }
            /*
            switch (str)
            {
                case "head": Response.Redirect("DepartmentWelcomePage.aspx"); check = true; break;
                case "staff": Response.Redirect("DepartmentWelcomePage.aspx"); check = true; break;
                //case "staff": Response.Redirect("DepartmentWelcomePage.aspx"); check = true; break;
                case "StoreClerk": Response.Redirect("StoreClerkWelcomePage.aspx"); check = true; break;
                case "Manager": Response.Redirect("StoreClerkWelcomePage.aspx"); check = true; break;
                case "Supervisor": Response.Redirect("StoreClerkWelcomePage.aspx"); check = true; break;
                default: Response.Redirect("CommonLogin.aspx"); break;
            }
             * */
          
         
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

    }
}