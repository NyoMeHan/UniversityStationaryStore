#region "Version Information"
/* Form Name       : UpdateStockItem.aspx
 ' Created By      : Muyar Phyo Han
' Description      : Updating Stock Item Information
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
    public partial class UpdateStockItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Update"].ToString() == "Update")
                {
                    lblItemCode.Text = Session["item_code"].ToString();
                    txtCategory.Text = Session["Category"].ToString();
                    txtDesc.Text = Session["Description"].ToString();
                    txtReorder.Text = Session["Reorder_level"].ToString();
                    txtReorderQty.Text = Session["Reorder_Quantity"].ToString();
                    txtUnit.Text = Session["Unit_of_Measure"].ToString();
                    txtQuantity.Text = Session["Quantity"].ToString();
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            StockItemBLL stock_bll = new StockItemBLL();
            //Stock_Item item = new Stock_Item();
            string tem_Code = Session["item_code"].ToString();
            int categoryID = Convert.ToInt32(txtCategory.Text);
            string description = txtDesc.Text;
            int reorder_Level = Convert.ToInt32(txtReorder.Text);
            int reorder_Qty = Convert.ToInt32(txtReorderQty.Text);
            string unit_of_Measure = txtUnit.Text;
            int qty = Convert.ToInt32(txtQuantity.Text);
            string update_msg = stock_bll.UpdateStockItem(tem_Code, categoryID, description, reorder_Level, reorder_Qty, unit_of_Measure, qty);
            lblmsg.Text = update_msg;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            lblItemCode.Text = "";
            txtCategory.Text = "";
            txtDesc.Text = "";
            txtReorder.Text = "";
            txtReorderQty.Text = "";
            txtUnit.Text = "";
            txtQuantity.Text = "";
        }
    }
}