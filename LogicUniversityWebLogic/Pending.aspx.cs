using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizLogic;

namespace LogicUniversityWebLogic
{
    public partial class Pending : System.Web.UI.Page
    {
        PendingLogic pdl = new PendingLogic();
        DisbursementLogic dl = new DisbursementLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnProcess.Visible = false;
                lblTitle.Visible = false;
                DropDownList1.Visible = false;
                btnRetrieve.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            pdl.ProcessPending();
            Response.Redirect("StoreClerkWelcomePage.aspx");
        }
            
        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = pdl.RetrievePending(DropDownList1.SelectedValue.ToString());
            GridView1.DataBind();

            if (GridView1.Rows.Count == 0)
            {
                btnProcess.Visible = false;
            }
            else
            {
                btnProcess.Visible = true;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            pdl.changeStatus();
            pdl.pendingQuantityDisburse();
            dl.processUpdation();
            dl.changeStatusforDisbursement();
        }

        protected void btnSelect_Click1(object sender, EventArgs e)
        {

            if (dropdownview.SelectedValue == "Department Based")
            {
                MultiView1.SetActiveView(DepartmentView);
                lblTitle.Visible = true;
                DropDownList1.Visible = true;
                btnRetrieve.Visible = true;
                btnProcess.Visible = false;
            }
            else
            {
                MultiView1.SetActiveView(ItemView);
                GridView2.DataSource = pdl.retrieveItemBased();
                GridView2.DataBind();
                lblTitle.Visible = false;
                DropDownList1.Visible = false;
                btnRetrieve.Visible = false;

                if (GridView2.Rows.Count == 0)
                {
                    btnProcess.Visible = false;
                }
                else
                {
                    btnProcess.Visible = true;
                }

            }
            
        }
    }
}