using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizLogic;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace LogicUniversityWebLogic
{
    public partial class ViewTrendForEachDept : System.Web.UI.Page
    {
        CrystalReportBLL bll = new CrystalReportBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ddlDeptName.DataSource = bll.DeptName();
                ddlDeptName.DataTextField = "Department_Name";
                ddlDeptName.DataValueField = "Department_Code";
                ddlDeptName.DataBind();
                lblMessage.Visible = false;
            }



        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            CreateRpt();
        }

        protected void CreateRpt()
        {
            string code = ddlDeptName.SelectedValue;
            int cMonth = Convert.ToInt32(ddlCurrentMonth.SelectedValue);
            int pMonth = Convert.ToInt32(ddlPastMonth.SelectedValue);
            bool chk = bll.ChkMonth(cMonth, pMonth);

            if (chk == false)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "* please choose again......";
            }
            else
            {
                lblMessage.Visible = false;
                List<sp_DeptReqReport_Result> list = bll.DeptRequestReport(code, pMonth, cMonth);

                ReportDocument report = new TrendForEachDept();
                report.SetDataSource(list);
                rptDeptTrendView.ReportSource = report;
                rptDeptTrendView.RefreshReport();

            }
        }
    }
}