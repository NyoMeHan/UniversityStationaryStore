using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizLogic;

using System.Data.Entity;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace LogicUniversityWebLogic
{
    public partial class ViewTrendForEachItem : System.Web.UI.Page
    {
        CrystalReportBLL bll = new CrystalReportBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ddlStockItem.DataSource = bll.ItemName();
                ddlStockItem.DataTextField = "Description";
                ddlStockItem.DataValueField = "Item_Code";
                ddlStockItem.DataBind();
                lblMessage.Visible = false;
            }
        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            CreateRpt();
        }

        public void CreateRpt()
        {
            int cMonth = Convert.ToInt32(ddlCurrentMonth.SelectedValue);
            int pMonth = Convert.ToInt32(ddlPastFirstMonth.SelectedValue);
            string code = ddlStockItem.SelectedValue;

            bool chk = bll.ChkMonth(cMonth, pMonth);
            if (chk == false)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "* please choose again......";
            }
            else  
            {
                List<sp_CurrMonthInfo_Result> list = bll.DeptItemLst(code, cMonth, pMonth);
                ReportDocument report = new TrendForEachItem();
                report.SetDataSource(list);
                rptEachItemView.ReportSource = report;
                rptEachItemView.RefreshReport();
                lblMessage.Visible = false;
            }
        }
    }
}