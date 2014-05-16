using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizLogic;

namespace MobilePresentationLogic
{
    public partial class NewStockItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {  
                
                /*
                if(Session["Update"] == "Update")
                {
                txtItemNo.Text = Session["item_code"].ToString();
                txtCategory.Text = Session["Category"].ToString();
                txtDesc.Text = Session["Description"].ToString();
                txtReorder.Text = Session["Reorder_level"].ToString();
                txtQty.Text = Session["Reorder_Quantity"].ToString();
                //txtUnit.Text = Session["Unit_of_Measure"].ToString();
                }
                * */


                /* ##################### redo it later #####################
                 * 
                 * 
                if (Session["AddNew"].ToString() =="AddNew")
                {
                    Clear_Session();

                }
                */
            }
        }

        private void Clear_Session()
        {
            Session["item_code"] = "";
            Session["Category"] = "";
            Session["Description"] = "";
            Session["Reorder_level"] = "";
            Session["Reorder_Quantity"] = "";
            Session["Unit_of_Measure"] = "";
            Session["Quantity"] = "";


            txtItemNo.Text = "";
            txtCategory.Text = "";
            txtDesc.Text = "";
            txtReorderLevel.Text = "";
            txtReorderQty.Text = "";
            txtQuantity.Text = "";

        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            CategoryBLL category_bll = new CategoryBLL();
            string category_name = txtCategory.Text;
            int cat_id = category_bll.AddNewCategory(category_name);

            StockItemBLL stockBll = new StockItemBLL();
            string item_Code = txtItemNo.Text;
            // int categoryID = Convert.ToInt32(txtCategory.Text);
            string description = txtDesc.Text;
            int reorder_Level = Convert.ToInt32(txtReorderLevel.Text);
            int reorder_Qty = Convert.ToInt32(txtReorderQty.Text);
            string unit = ddlUnit.SelectedItem.Text;
            int qty = Convert.ToInt32(txtQuantity.Text);

            string add_info = stockBll.AddNewStockItem(item_Code, cat_id, description, reorder_Level, reorder_Qty, unit, qty);
            lblmsg.Text = add_info;

        }
        /*
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            StockItemBLL stock_bll = new StockItemBLL();
            //Stock_Item item = new Stock_Item();
           string tem_Code = txtItemNo.Text;
            int categoryID = Convert.ToInt32(txtCategory.Text);
           string description = txtDesc.Text;
            int reorder_Level = Convert.ToInt32(txtReorder.Text);
            int reorder_Qty = Convert.ToInt32(txtReorderQty.Text);
            string unit_of_Measure = ddlUnit.SelectedItem.Text;
            int qty = Convert.ToInt32(txtQuantity.Text);
            string update_msg = stock_bll.UpdateStockItem(tem_Code, categoryID, description, reorder_Level, reorder_Qty, unit_of_Measure, qty);
            lblmsg.Text = update_msg;

        }
         * */
    }
}