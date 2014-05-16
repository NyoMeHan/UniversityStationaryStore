using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizLogic;

namespace LogicUniversityWebLogic
{
    public partial class DeptView : System.Web.UI.Page
    {
        ItemRetrieve it = new ItemRetrieve();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Button1.Visible = false;
            }
        }

        protected void btnDeptReq_Click(object sender, EventArgs e)
        {

           // IList list = it.Dept_ItemsRetrieved(deptdropdown.SelectedValue.ToString());

            deptviewgrid.DataSource = it.Dept_ItemsRetrieved(deptdropdown.SelectedValue.ToString());
            deptviewgrid.DataBind();

            if (deptviewgrid.Rows.Count > 0)
            {
                Button1.Visible = true;
                Button1.Enabled = true;
            }
            else
            {
                Button1.Visible = false;

            }
        }

        protected void deptdropdown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            it.getRequests();
            Button1.Enabled = false;
            Button1.Visible = false;
            foreach (GridViewRow gvr in deptviewgrid.Rows)
            {

                //DepartmentRequestId.Add(int.Parse(((gvr.Cells[3]).Text).ToString()));
            }


        }

        protected void deptviewgrid_DataBound(object sender, EventArgs e)
        {
            //GridView gridView = (GridView)sender;

            //if (gridView.HeaderRow != null && gridView.HeaderRow.Cells.Count > 0)
            //{
            //    gridView.HeaderRow.Cells[0].Visible = false;
            //    gridView.HeaderRow.Cells[1].Visible = false;
            //}


            //foreach (GridViewRow row in deptviewgrid.Rows)
            //{
            //    row.Cells[0].Visible = false;
            //    row.Cells[1].Visible = false;
            //}


        }

        protected void deptviewgrid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}