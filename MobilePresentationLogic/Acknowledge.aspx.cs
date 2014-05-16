using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using BizLogic;

namespace MobilePresentationLogic
{
    public partial class Acknowledge : System.Web.UI.Page
    {

        AdjustmentLogic al = new AdjustmentLogic();
        Pending pend = new Pending();
        private DataTable dataTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            btnAck.Visible = false;

            if (!IsPostBack)
            {
                bindDropDown();
            }
        }

        public void bindDropDown()
        {
            dropdownItem.DataSource = al.getData(DropDownList1.SelectedValue);
            dropdownItem.DataBind();

        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow dr;

            DataColumn dc = new DataColumn("DepartmentRequestID", typeof(String));
            dataTable.Columns.Add(dc);
            dc = new DataColumn("ItemCategory", typeof(String));
            dataTable.Columns.Add(dc);
            dc = new DataColumn("ItemDescription", typeof(String));
            dataTable.Columns.Add(dc);
            dc = new DataColumn("Type", typeof(String));
            dataTable.Columns.Add(dc);
            dc = new DataColumn("Quantity", typeof(String));
            dataTable.Columns.Add(dc);

            if (Cache["table"] != null)
            {
                dataTable = (DataTable)Cache["table"];
            }

            dr = dataTable.NewRow();

            dr["DepartmentRequestID"] = txtDisburseID.Text;
            dr["ItemCategory"] = DropDownList1.SelectedItem.Text;
            dr["ItemDescription"] = "";
            if (RadioButton1.Checked)
                dr["Type"] = RadioButton1.Text;
            else
                dr["Type"] = RadioButton2.Text;

            dr["Quantity"] = txtDamaged.Text;


            dataTable.Rows.Add(dr);



            Cache["table"] = dataTable;
            GridView1.DataSource = dataTable;

            GridView1.DataBind();

            if (GridView1.Rows.Count > 0)
                btnAck.Visible = true;

        }

        protected void btnAck_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvr in GridView1.Rows)
            {
                int disburseid = int.Parse(((gvr.Cells[0]).Text).ToString());


                string category = gvr.Cells[1].Text.ToString().Trim();
                string description = HttpUtility.HtmlDecode(gvr.Cells[2].Text.ToString());
                int quantity = int.Parse(((gvr.Cells[3]).Text).ToString());
                string type = gvr.Cells[4].Text.ToString().Trim();

                al.delivery_adjust(disburseid, category, description, quantity, type);
            }
        
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (radioYes.Checked)
            {

                MultiView1.SetActiveView(AdjustmentView);
            }

            if (radioNo.Checked)
            {

                MultiView1.SetActiveView(NoadjustmentView);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
          
        }

        protected void btnNoACK_Click(object sender, EventArgs e)
        {
            
        }
    }
}