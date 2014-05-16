#region "Version Information"
/* Form Name       : NewViewTrendForEachDept.aspx
' Created By       : Zay Yar Lin Tun
' Description      : Showing New View trend for Each Dept
' Created Date     : 08/09/2013
' Version History  : 1.0
 * */
#endregion

using System;
using System.Collections.Generic;
using System.Collections;
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
    public partial class NewViewTrendForEachItem : System.Web.UI.Page
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
                ddlSecondMonth.Visible = false;
            }
        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            CreateRpt();
        }

        public void CreateRpt()
        {
            int cMonth = Convert.ToInt32(ddlCurrentMonth.SelectedValue);
            int fMonth = Convert.ToInt32(ddlFirstMonth.SelectedValue);
            int sMonth = Convert.ToInt32(ddlSecondMonth.SelectedValue);
            string code = ddlStockItem.SelectedValue;

            if (ddlSelectType.SelectedValue == "Multiple")
            {
                bool chk = bll.ChkMonth(cMonth, fMonth);
                if (chk == false)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "* please choose again......";
                }
                else
                {
                    List<sp_CurrMonthInfo_Result> list = bll.DeptItemLst(code, cMonth, fMonth);
                    ReportDocument report = new TrendForEachItem();
                    report.SetDataSource(list);
                    rptEachItemView.ReportSource = report;
                    rptEachItemView.RefreshReport();
                    lblMessage.Visible = false;
                }
            }
            else
            {

                int fmYear = bll.GetYear(cMonth, fMonth);
                int smYear = bll.GetYear(cMonth, sMonth);

                IList list = bll.DeptItemLstByThreeMonths(code, cMonth, fMonth,sMonth, fmYear, smYear);
                ReportDocument report = new TrendForEachItem();
                report.SetDataSource(list);
                rptEachItemView.ReportSource = report;
                rptEachItemView.RefreshReport();
                lblMessage.Visible = false;
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (ddlSelectType.SelectedValue == "Multiple")
            {
                ddlSecondMonth.Visible = false;
            }
            else
            {
                ddlSecondMonth.Visible = true;
            }
        }
    }
}