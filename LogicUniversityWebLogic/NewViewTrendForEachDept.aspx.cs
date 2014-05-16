#region "Version Information"
/* Form Name       : NewViewTrendForEachDept.aspx
' Created By       : Zay Yar Lin Tun
' Description      : Showing trend for Each Dept
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

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace LogicUniversityWebLogic
{
    public partial class NewViewTrendForEachDept : System.Web.UI.Page
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
                ddlSecPreviousMonth.Visible = false;
                lblMessage.Visible = false;
                lblMessages.Visible = false;
            }
        }

        protected void btnViewRpt_Click(object sender, EventArgs e)
        {
            CreateView();
               
       }


        public void CreateView()
        {
            string status = ddlStatus.SelectedValue;
            string code = ddlDeptName.SelectedValue;
            int cMonth = Convert.ToInt32(ddlCurrMonth.SelectedValue);
            int fMonth = Convert.ToInt32(ddlFirstPreviousMonth.SelectedValue);
            int sMonth = Convert.ToInt32(ddlSecPreviousMonth.SelectedValue);

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
                    IList list = bll.DeptRequestReportMultiple(code, fMonth, cMonth, status);
                    if (list.Count <= 0)
                    {
                        lblMessages.Visible = true;
                        lblMessages.Text = "No Data Found in One or More Months";
                    }
                    else
                    {
                        ReportDocument doc = new TrendForEachDept();
                        doc.SetDataSource(list);
                        rptViewTrendForDept.ReportSource = doc;
                        rptViewTrendForDept.RefreshReport();
                        //ddd
                    }
                }
            }
            else
            {
                int fmYear = bll.GetYear(cMonth, fMonth);
                int smYear = bll.GetYear(cMonth, sMonth);

                IList list = bll.DeptRequestRepostThree(code, fMonth, sMonth, cMonth, fmYear, smYear, status);
                ReportDocument doc = new TrendForEachDept();
                doc.SetDataSource(list);
                rptViewTrendForDept.ReportSource = doc;
                rptViewTrendForDept.RefreshReport();
            }
        }
      

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (ddlSelectType.SelectedValue == "Multiple")
            {
                ddlSecPreviousMonth.Visible = false;
            }
            else
            {
                ddlSecPreviousMonth.Visible = true;
            }
        }

        
        }
    }
