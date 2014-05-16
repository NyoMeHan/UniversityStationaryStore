using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobilePresentationLogic.Account
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

     

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str="DepartmentEmployee";
            

            FormsAuthentication.SetAuthCookie(TextBox1.Text, false);
            Roles.AddUserToRole(TextBox1.Text, str);

        }

    }
}
