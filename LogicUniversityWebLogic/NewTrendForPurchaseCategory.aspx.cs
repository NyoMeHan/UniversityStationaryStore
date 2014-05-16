#region "Version Information"
/* Form Name       : NewTrendForPurchaseCatgory.aspx
' Created By       : Zay Yar Lin Tun
' Description      :Showing trend for Purchase Category
' Created Date     : 09/09/2013
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
    public partial class NewTrendForPurchaseCategory : System.Web.UI.Page
    {
        CrystalReportBLL bll = new CrystalReportBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ddlSecondMonth.Visible = false;
                lblMessage.Visible = false;
                lblMessages.Visible = false;

            }
        }
        protected void btnView_Click(object sender, EventArgs e)
        {

            checkMonth();


        }

        public void checkMonth()
        {

            int cMonth = Convert.ToInt32(ddlCurrentMonth.SelectedValue);
            int fMonth = Convert.ToInt32(ddlFirstMonth.SelectedValue);
            int sMonth = Convert.ToInt32(ddlSecondMonth.SelectedValue);
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
                
                List<sp_CurrMonthPurchase_Result> cList = bll.CurrMonthPurchase(fMonth, cMonth);
                ReportDocument report = new TrendForPurchasedItems();
                report.SetDataSource(cList);
                rptPurchaseItemView.ReportSource = report;
                rptPurchaseItemView.RefreshReport();
                lblMessage.Visible = false;
                }
            }
            else
            {
                  //bool chk = bll.ChkMonth(fMonth, sMonth);
                  //if (chk == false)
                  //{
                  //    lblMessage.Visible = true;
                  //    lblMessage.Text = "* please choose again......";
                  //}
                  //else
                  //{
                      int fmYear = bll.GetYear(cMonth, fMonth);
                      int smYear = bll.GetYear(cMonth, sMonth);
                        
                      IList cList = bll.PurchaseCatByThreeMonth(cMonth, fMonth, sMonth, fmYear, smYear);
                      if (cList.Count <= 0)
                      {
                          lblMessages.Visible = true;
                          lblMessages.Text = "No Data Found In One or More Months";

                      }
                      else
                      {
                          ReportDocument report = new TrendForPurchasedItems();
                          report.SetDataSource(cList);
                          rptPurchaseItemView.ReportSource = report;
                          rptPurchaseItemView.RefreshReport();
                          lblMessage.Visible = false;
                          lblMessages.Visible = false;
                      }
                  //}
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