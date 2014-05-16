using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizLogic;

namespace MobilePresentationLogic
{
    public partial class ItemRetrieved1 : System.Web.UI.Page
    {
        ItemRetrieve it = new ItemRetrieve();
        DisbursementLogic dl = new DisbursementLogic();
        PendingLogic pl = new PendingLogic();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = it.viewRetrieve();
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
          //  it.ProcessStatus();

            it.Disburse();
            dl.disburse();
            dl.processUpdation();

        }


    }
}