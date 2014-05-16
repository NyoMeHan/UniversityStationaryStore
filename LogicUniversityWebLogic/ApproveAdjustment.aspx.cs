using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizLogic;

namespace LogicUniversityWebLogic
{
    public partial class ApproveAdjustment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillAdjust_Id_List();
            }

        }


        private void FillAdjust_Id_List()
        {

            //string person = System.Web.HttpContext.Current.User.Identity.Name.ToString();// need to get login user id
            string person = Session["loginUser"].ToString();
            lblTest.Text = person;
            AdjustmentBLL adjust_bll = new AdjustmentBLL();
            //var list = adjust_bll.getIDList();
            IList list = adjust_bll.getAdjust_IDList(person);
            ddlAdjustID.DataSource = list;
            ddlAdjustID.DataTextField = "AdjustmentID";
            ddlAdjustID.DataValueField = "AdjustmentID";
            ddlAdjustID.DataBind();

        }

        /*
        protected void ddlAdjustID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id =Convert.ToInt32(ddlAdjustID.SelectedItem.Text);
            AdjustmentDetailsBLL adjust_detailsbll = new AdjustmentDetailsBLL();
            var list = adjust_detailsbll.getAdjustListByPerson(id);
            gvAdjustmentReport.DataSource = list;
            gvAdjustmentReport.DataBind();
         
        }
         */

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlAdjustID.SelectedItem.Text);
            AdjustmentDetailsBLL adjust_detailsbll = new AdjustmentDetailsBLL();
            var list = adjust_detailsbll.getAdjustListByPerson(id);
            gvAdjustmentReport.DataSource = list;
            gvAdjustmentReport.DataBind();
        }

        protected void btnApproveAdjust_Click(object sender, EventArgs e)
        {   /// update adjustmentInfo  ///
            int adjust_id = Convert.ToInt32(ddlAdjustID.SelectedItem.Text);
            //int ApprovedBy_ID = Convert.ToInt32(System.Web.HttpContext.Current.User.Identity.Name.ToString());
            int ApprovedBy_ID = Convert.ToInt32(Session["loginUser"]);
            DateTime currentDate = DateTime.Now;
            string status = "Approve";

            AdjustmentBLL adjust_bll = new AdjustmentBLL();
            string s = adjust_bll.updateAdjustmentInfo(adjust_id, ApprovedBy_ID, currentDate, status);

            /// update Stock Item Qty ///////
            foreach (GridViewRow row in gvAdjustmentReport.Rows)
            {
                string item_code = row.Cells[1].Text;
                int qty = Convert.ToInt32(row.Cells[2].Text);

                StockItemBLL stockItem_bll = new StockItemBLL();
                string updateStock_msg = stockItem_bll.updateStockQty(item_code, qty);

                string desc = stockItem_bll.GetItemDescription(item_code);
                StockHistoryBLL stockbll = new StockHistoryBLL();
                string history_msg = stockbll.AddStockHistoryForAdjustment(item_code, desc, qty, currentDate, ApprovedBy_ID);
                lblUpdateMsg.Text = updateStock_msg + history_msg;
            }
        }
    }
}