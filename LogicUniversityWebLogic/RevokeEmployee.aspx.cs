#region "Version Information"
/* Form Name       : NewViewTrendForEachDept.aspx
' Created By       : Seinn Nu Aye
' Description      : Showing trend for Each Dept
' Created Date     : 08/09/2013
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
    public partial class RevokeEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
        }
    }
}