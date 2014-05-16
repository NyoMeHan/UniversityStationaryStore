using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace MobilePresentationLogic
{
    public partial class Department_Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnlogof_Click(object sender, ImageClickEventArgs e)
        {
            FormsAuthentication.SignOut(); 
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}