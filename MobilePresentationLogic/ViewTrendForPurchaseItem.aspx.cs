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
    public partial class ViewTrendForPurchaseItem : System.Web.UI.Page
    {
        CrystalReportBLL bll = new CrystalReportBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {

                lblMessage.Visible = false;

            }
        }
        protected void btnView_Click(object sender, EventArgs e)
        {

            checkMonth();


        }

        public void checkMonth()
        {

            int cMonth = Convert.ToInt32(ddlCurrentMonth.SelectedValue);
            int pMonth = Convert.ToInt32(ddlPastFirstMonth.SelectedValue);
            bool chk = bll.ChkMonth(cMonth, pMonth);
            if (chk == false)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "* please choose again......";
            }
            else
            {
                List<sp_CurrMonthPurchase_Result> cList = bll.CurrMonthPurchase(pMonth, cMonth);
                ReportDocument report = new TrendForPurchasedItems();
                report.SetDataSource(cList);
                rptPurchaseItemView.ReportSource = report;
                rptPurchaseItemView.RefreshReport();
                lblMessage.Visible = false;
            }
        }
    }
}