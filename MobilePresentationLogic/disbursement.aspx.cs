using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizLogic;

namespace MobilePresentationLogic
{
    public partial class disbursement : System.Web.UI.Page
    {
        DisbursementLogic dl = new DisbursementLogic();
        PendingLogic pl = new PendingLogic();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            deptgridview.DataSource = dl.getDisburseView(DropDownList1.SelectedValue.ToString());
            deptgridview.DataBind();

        }

    }
}