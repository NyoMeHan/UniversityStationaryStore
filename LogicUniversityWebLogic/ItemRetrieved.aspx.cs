using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizLogic;

namespace LogicUniversityWebLogic
{
    public partial class ItemRetrieved : System.Web.UI.Page
    {
        ItemRetrieve it = new ItemRetrieve();
        DisbursementLogic dl = new DisbursementLogic();
        PendingLogic pl = new PendingLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            grvItemRetrieved.DataSource = it.viewRetrieve();
            grvItemRetrieved.DataBind();
        }

        protected void btnDisburse_Click(object sender, EventArgs e)
        {
            it.Disburse();
            dl.disburse();
            it.ProcessStatus();
        }
    }
}