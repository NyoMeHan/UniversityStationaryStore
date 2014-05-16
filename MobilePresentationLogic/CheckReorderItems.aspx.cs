using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BizLogic;

using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;

namespace MobilePresentationLogic
{
    public partial class CheckReorderItems : System.Web.UI.Page
    {
        StockItemBLL stbll = new StockItemBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
   
                var reorderItems = stbll.GetItemBelowReorderQty();
                gvReorderItems.DataSource = reorderItems;
                gvReorderItems.DataBind();


            }

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            //string path = Server.MapPath("~/");
            //string filename = "ItemBelowReorderLevel" + DateTime.Now.Ticks + ".pdf";
            //GeneratePDF(path, filename, false, "");
        }
        
    }
}