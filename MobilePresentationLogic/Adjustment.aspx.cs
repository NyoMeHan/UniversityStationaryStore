using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BizLogic;

namespace MobilePresentationLogic
{
    public partial class Adjustment : System.Web.UI.Page
    {
        AdjustmentLogic al = new AdjustmentLogic();
        private DataTable dataTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //Cache["data"] = null;
            }


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
            dr["ItemDescription"] = DropDownList2.SelectedItem.Text;
            if (RadioButton1.Checked)
                dr["Type"] = RadioButton1.Text;
            else
                dr["Type"] = RadioButton2.Text;

            dr["Quantity"] = txtDamaged.Text;


            dataTable.Rows.Add(dr);



            Cache["table"] = dataTable;
            GridView1.DataSource = dataTable;

            GridView1.DataBind();


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}