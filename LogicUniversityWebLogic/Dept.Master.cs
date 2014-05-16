#region "Version Information"
/* Form Name       : Dept.Master
' Created By       : Seinn Nu Aye
' Description      : Designing as a Layout for all pages of Department
' Created Date     : 09/09/2013
' Version History  : 1.0
 * */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace LogicUniversityWebLogic
{
    public partial class Dept : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            Response.Redirect("CommonLogin.aspx");
        }
    }
}