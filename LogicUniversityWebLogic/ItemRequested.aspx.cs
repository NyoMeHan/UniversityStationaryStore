


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizLogic;
using System.Web.UI.HtmlControls;
using System.IO;

namespace LogicUniversityWebLogic
{
    public partial class ItemRequested : System.Web.UI.Page
    {
        ItemRetrieve ir = new ItemRetrieve();

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = ir.viewRequests();
            GridView1.DataBind();
        }

    
    }
}