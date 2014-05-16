using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BizLogic;
using System.Diagnostics;

namespace MobilePresentationLogic
{
    public partial class ViewDepartmentInfo : System.Web.UI.Page
    {
        DepartmentBLL deptbll = new DepartmentBLL();
        EmployeeBLL ebll = new EmployeeBLL();

        List<string> code = new List<string>();
        List<string> name = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddDept_Click(object sender, EventArgs e)
        {
            Session["selected"] = "new";
            Response.Redirect("DepartmentDetail.aspx");
        }

        protected void gvDeptList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dcode = gvDeptList.SelectedDataKey.Value.ToString();
            //Debug.WriteLine("selected: " + dcode);
            Session["selected"] = dcode;
            Response.Redirect("DepartmentDetail.aspx");
        }
    }
}