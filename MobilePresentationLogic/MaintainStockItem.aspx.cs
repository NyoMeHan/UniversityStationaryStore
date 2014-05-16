using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using BizLogic;

namespace MobilePresentationLogic
{
    public partial class MaintainStockItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillCategoryList();
                //FillStockItemList();
            }


        }

        private void FillCategoryList()
        {
            CategoryBLL categorybll = new CategoryBLL();
            var c = categorybll.GetCategory();
            ddlCateogryList.DataSource = c;
            ddlCateogryList.DataTextField = "Category_Name";
            ddlCateogryList.DataValueField = "CategoryID";
            ddlCateogryList.DataBind();

        }


        protected void btnCheck_Click(object sender, EventArgs e)
        {
            StockItemBLL stockBll = new StockItemBLL();
            int cat_Id = Convert.ToInt32(ddlCateogryList.SelectedItem.Value);
            var item_list = stockBll.GetCategoryList_ByItem(cat_Id);

            gvItemInfoList.DataSource = item_list;
            gvItemInfoList.DataBind();
        }

        protected void gvItemInfoList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Update"] = "Update";
            Session["item_code"] = gvItemInfoList.SelectedRow.Cells[2].Text;
            Session["Category"] = gvItemInfoList.SelectedRow.Cells[3].Text;
            Session["Description"] = gvItemInfoList.SelectedRow.Cells[4].Text;
            Session["Reorder_level"] = gvItemInfoList.SelectedRow.Cells[5].Text;
            Session["Reorder_Quantity"] = gvItemInfoList.SelectedRow.Cells[6].Text;
            Session["Unit_of_Measure"] = gvItemInfoList.SelectedRow.Cells[7].Text;
            Session["Quantity"] = gvItemInfoList.SelectedRow.Cells[8].Text;
            Session["Price"] = gvItemInfoList.SelectedRow.Cells[9].Text;
            //Response.Redirect("NewStockItem.aspx");
            Response.Redirect("UpdateStockItem.aspx");


        }


        protected void btnNewStockItem_Click(object sender, EventArgs e)
        {
            Session["AddNew"] = "AddNew";
            Response.Redirect("NewStockItem.aspx");
        }

        /*

         protected void gvItemInfoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
         {
             StockItemBLL stockBll = new StockItemBLL();
              string item_code = gvItemInfoList.SelectedRow.Cells[2].Text;   
             // string delete_msg = stockBll.DeleteStockItem(item_code);
             // lblmsg.Text = delete_msg;

             //string item_code = gvItemInfoList.SelectedRow.FindControl("Item_Code").ToString();
            // int index = gvItemInfoList.SelectedIndex;
             //Label itemCode = (Label)gvItemInfoList.Rows[index].FindControl("Item_Code");


             string delete_msg = stockBll.DeleteStockItem(item_code);
             lblmsg.Text = delete_msg;
               
         } */

        private DataTable getDataTableInfo
        {
            get
            {
                if (ViewState["DT"] == null)
                { ViewState["DT"] = NewTable(); }

                return ViewState["DT"] as DataTable;
            }
            set { ViewState["DT"] = value; }
        }

        private object NewTable()
        {
            DataTable r_Table = new DataTable("ReqTempTable");
            //r_Table.Columns.Add(new DataColumn("ItemCode"));
            // r_Table.Columns.Add(new DataColumn("ItemDescription"));
            return r_Table;
        }

        /*
        public DataSet myDataSet
        {
            get
            {
                return ViewState["myDataSet"] != null ? (DataSet)ViewState["myDataSet"] : null;
            }
            set
            {
                ViewState["myDataSet"] = value;
            }
        }
       * */

        protected void gvItemInfoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            StockItemBLL stockBll = new StockItemBLL();
            int index = Convert.ToInt32(e.RowIndex);
            string itemCode = gvItemInfoList.Rows[index].Cells[2].Text;
            string delete_msg = stockBll.DeleteStockItem(itemCode);
            lblmsg.Text = delete_msg;
            gvItemInfoList.EditIndex = -1;

            int cat_Id = Convert.ToInt32(ddlCateogryList.SelectedItem.Value);
            var item_list = stockBll.GetCategoryList_ByItem(cat_Id);

            gvItemInfoList.DataSource = item_list;
            gvItemInfoList.DataBind();
            //gvItemInfoList.DataSource = gvItemInfoList;
            gvItemInfoList.DataBind();

        }



        protected void gvItemInfoList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            /*
            int index = Convert.ToInt32(e.CommandArgument); 
            if(e.CommandName == "delete")
             {      
                 //int id = int.Parse(gvItemInfoList.DataKeys[index].Value.ToString());//the primary key for your table.
               //  int row = gvItemInfoList.SelectedRow.FindControl("Item_Code");
                
                
                 //Delete(id);//method which use (Delete From .... Where id = ....).
                 //gvItemInfoList.DeleteRow(id); 
            }


            gvItemInfoList.DataBind();
             * */
        }

        /*
         protected void gvItemInfoList_RowDeleted(object sender, GridViewDeletedEventArgs e)
         {
             StockItemBLL stockBll = new StockItemBLL();
             string item_code = gvItemInfoList.SelectedRow.Cells[2].Text;
             // string delete_msg = stockBll.DeleteStockItem(item_code);
             // lblmsg.Text = delete_msg;

             //string item_code = gvItemInfoList.SelectedRow.FindControl("Item_Code").ToString();
             // int index = gvItemInfoList.SelectedIndex;
             //Label itemCode = (Label)gvItemInfoList.Rows[index].FindControl("Item_Code");                
            
         }
         */
        
    }
}