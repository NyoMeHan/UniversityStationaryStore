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
    public partial class IssueStockAdjustment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillCategoryList();
                FillStockItemList();
                // ddlItemName.Items.Insert(0, new ListItem("<Select Item>", ""));

            }
        }

        private void FillCategoryList()
        {
            CategoryBLL categorybll = new CategoryBLL();
            var c = categorybll.GetCategory();
            ddlCategory.DataSource = c;
            ddlCategory.DataTextField = "Category_Name";
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataBind();

        }

        private void FillStockItemList()
        {
            StockItemBLL stockItembll = new StockItemBLL();
            Stock_Item stockitem = new Stock_Item();
            var itemList = stockItembll.GetStockItem();
            ddlItemName.DataSource = itemList;
            ddlItemName.DataTextField = "Description";
            ddlItemName.DataValueField = "Item_Code";
            ddlItemName.DataBind();


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            //DataRow datarow = null;
            DataRow datarow = dt.NewRow();

            dt.Columns.Add("RowNumber", typeof(string));
            dt.Columns.Add("ItemCode", typeof(string));
            dt.Columns.Add("QuantityAdjusted", typeof(string));
            dt.Columns.Add("Reason", typeof(string));
            dt.Columns.Add("Status", typeof(string));


            /* Adding First New Row  */
            int orgin_count = 0;
            if (orgin_count == gvAdjustList.Rows.Count)
            {
                int row_count = gvAdjustList.Rows.Count;
                // lblRowCount.Text = row_count.ToString();

                //DataRow datarow = dt.NewRow();
                datarow["RowNumber"] = 1;
                datarow["ItemCode"] = ddlItemName.SelectedItem.Value;
                datarow["QuantityAdjusted"] = txtAdjustQty.Text;
                datarow["Reason"] = txtReason.Text;
                datarow["Status"] = rbtnList.SelectedItem.Text;

                dt.Rows.Add(datarow);
                //dt.AcceptChanges();
                Session["AdjustItemList"] = dt;
                gvAdjustList.DataSource = dt;
                gvAdjustList.DataBind();

            }
            /* Adding next New Row  */

          // if ( gvAdjustList.Rows.Count > 0)
            else if (Session["AdjustItemList"] != null)
            {
                int rowIndex = 0;
                DataRow drCurrentRow = null;
                DataTable dtCurrentTable = (DataTable)Session["AdjustItemList"];


                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int count = 1; count <= dtCurrentTable.Rows.Count; count++)
                    {

                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["ItemCode"] = gvAdjustList.Rows[rowIndex].Cells[1].FindControl("ddlItemName.SelectedItem.Value");
                        drCurrentRow["QuantityAdjusted"] = gvAdjustList.Rows[rowIndex].Cells[2].FindControl("txtAdjustQty.Text");
                        drCurrentRow["Reason"] = gvAdjustList.Rows[rowIndex].Cells[3].FindControl(" txtReason.Text");
                        drCurrentRow["Status"] = gvAdjustList.Rows[rowIndex].Cells[4].FindControl("rbtnList.SelectedItem.Text");

                        drCurrentRow["RowNumber"] = count + 1;
                        drCurrentRow["ItemCode"] = ddlItemName.SelectedItem.Value;
                        drCurrentRow["QuantityAdjusted"] = txtAdjustQty.Text;
                        drCurrentRow["Reason"] = txtReason.Text;
                        drCurrentRow["Status"] = rbtnList.SelectedItem.Text;

                        rowIndex++;

                    } // end for loop
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    Session["AdjustItemList"] = dtCurrentTable;
                    dtCurrentTable.AcceptChanges();
                    gvAdjustList.DataSource = dtCurrentTable;
                    gvAdjustList.DataBind();
                } // end elseif

            }

        } //end btnAdd click 

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            adjustment_View adjust_view = new adjustment_View();
            AdjustmentBLL adjustbll = new AdjustmentBLL();

            //int adjustBy_Id = 1005;
          // int loginUserId = 1002;// current login User who will make Adjustment Report
            int loginUserId = Convert.ToInt32(Session["loginUser"]);
            DateTime adjustDate = DateTime.Now;
            //DateTime adjustDate = DateTime.Today;

            int itemPrice = Convert.ToInt32(ddlPrice.SelectedItem.Value);

            //int approvedBy = null;
            //DateTime approveDate = null;
            //string approveStatus = null;
            double total_price = 0;
            foreach (GridViewRow row in gvAdjustList.Rows)
            {

                string item_code = row.Cells[1].Text;
                int qty = Convert.ToInt32(row.Cells[2].Text);


                StockItemBLL itemBll = new StockItemBLL();
                double price = itemBll.GetItemPrice(item_code);

                total_price = total_price + (price * qty);

                /********* Don't delete lbl testing line **********/
                //lblPrice.Text = price.ToString();
                //lblTotalPrice.Text = total_price.ToString(); // don't delete

            }
            string authorizedBy = null;

            if (total_price <= 250)
            {
                authorizedBy = "Supervisor";
            }
            else
            {
                authorizedBy = "Manager";
            }
            int adjustid = adjustbll.addAdjustment(loginUserId, adjustDate, authorizedBy);

            foreach (GridViewRow row in gvAdjustList.Rows)
            {
                string item_code = row.Cells[1].Text;
                int qty = Convert.ToInt32(row.Cells[2].Text);
                string reason = row.Cells[3].Text;
                string status = row.Cells[4].Text;

                AdjustmentDetailsBLL adjust_details_bll = new AdjustmentDetailsBLL();
                int adjustment_details_Id = adjust_details_bll.addAdjustmentDetails(adjustid, item_code, qty, reason, status);

            }

            Employee emp_bll = new Employee();
            //int loginUserId = 1002;
            string email_body = "Adjustment Report is submitted to Supervier or Manager by StoreClerk";
            string email_subj = "Issue Adjustment Report";
            string email_msg = SendEmailNotification(loginUserId, email_body, email_subj, authorizedBy);

            lblSubmitMsg.Text = "Adjustment Report Submittion is successful. " + email_msg;
        }

        private string SendEmailNotification(int loginUserId, string body, string subject, string authorizedPerson)
        {
            EmployeeBLL emp_Bll = new EmployeeBLL();

            Employee login_EmpInfo = new Employee();
            login_EmpInfo = emp_Bll.GetEmp_Info(loginUserId);  //to get loginEmp_info

            int authorized_ID = 0;
            if (authorizedPerson == "Supervisor")
                authorized_ID = 1007;

            else if (authorizedPerson == "Manager")
                authorized_ID = 1009;

            Employee authorizedPerson_info = new Employee();
            authorizedPerson_info = emp_Bll.GetAuthorizedPersonInfo(authorized_ID);  ////get authorized emp_info

            string body_msg = "To " + authorizedPerson_info.EmployeeName + "<br/>" + body + "<br/>From" + login_EmpInfo.EmployeeName;


            //public void sendEmailNotification(string toEmail, string fromEmail, string body, string subject)
            string msg = emp_Bll.sendEmailNotification(authorizedPerson_info.Email, login_EmpInfo.Email, body_msg, subject);
            return msg;

        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            CategoryBLL category_bll = new CategoryBLL();
            StockItemBLL stock_bll = new StockItemBLL();

            string category_name = ddlCategory.SelectedItem.Text;
            int category_id = category_bll.GetCategoryId(category_name);

            /*****Testing for Category ID value
            //lblCategoryValue.Text = category_id.ToString(); */
            var item_list = stock_bll.GetCategoryList_ByItem(category_id);

            ddlItemName.DataSource = item_list;
            ddlItemName.DataTextField = "Description";
            ddlItemName.DataValueField = "Item_Code";
            ddlItemName.DataBind();

        }
       

    }
}