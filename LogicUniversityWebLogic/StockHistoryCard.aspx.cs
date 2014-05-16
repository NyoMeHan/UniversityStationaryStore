using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizLogic;

using System.Collections;
using System.Data.Entity;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace LogicUniversityWebLogic
{
    public partial class StockHistoryCard : System.Web.UI.Page
    {
        CrystalReportBLL bll = new CrystalReportBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                List<Category> catList = bll.Category_Name();
                ddlCategories.DataSource = catList;
                ddlCategories.DataTextField = "Category_Name";
                ddlCategories.DataValueField = "CategoryID";
                ddlCategories.DataBind();
                ddlCategories.Items.Insert(0, new ListItem("<Select Categories>", ""));
                ddlItems.Visible = false;
                lblItemName.Visible = false;
                lblMessage.Visible = false;
            }

        }

        protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(ddlCategories.SelectedItem.Value);
            ddlItems.DataSource = bll.GetItembyCatId(id);
            ddlItems.DataTextField = "Description";
            ddlItems.DataValueField = "Item_Code";
            ddlItems.DataBind();
            ddlItems.Items.Insert(0, new ListItem("<Select Items>", ""));
            ddlItems.Visible = true;
            lblItemName.Visible = true;
        }



        protected void btnView_Click(object sender, EventArgs e)
        {
            string itemCode = ddlItems.SelectedValue;
            int month = Convert.ToInt32(ddlMonths.SelectedValue);

            IList list = bll.GetStockHistory(itemCode, month);
            if (list.Count <= 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "No Records Found in One or More Months";
            }
            else
            {
                ReportDocument report = new StockHistoryView();
                report.SetDataSource(list);
                rptStockHistory.ReportSource = report;
                rptStockHistory.RefreshReport();
                lblMessage.Visible = false;
            }

            ddlItems.Visible = false;
            lblItemName.Visible = false;
        }
    }
}