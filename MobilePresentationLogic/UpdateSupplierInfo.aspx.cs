using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizLogic;

namespace MobilePresentationLogic
{
    public partial class UpdateSupplierInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SupplierBLL supBll = new SupplierBLL();
            var sup = supBll.GetAllSupplier();
            gvSupplierList.DataSource = sup;
            gvSupplierList.DataBind();

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Session["Update"] = "Update";
            Response.Redirect("~/NewSupplierForm.aspx");
        }

        protected void btnAddnewcustomer_Click(object sender, EventArgs e)
        {
            Session["AddNew"] = "Add";
            Response.Redirect("~/NewSupplierForm.aspx");
        }

        protected void gvSupplierList_SelectedIndexChanged(object sender, EventArgs e)
        {

            Session["supCode"] = gvSupplierList.SelectedRow.Cells[1].Text;
            Session["suppliername"] = gvSupplierList.SelectedRow.Cells[2].Text;
            Session["contactname"] = gvSupplierList.SelectedRow.Cells[3].Text;
            Session["phone"] = gvSupplierList.SelectedRow.Cells[4].Text;
            Session["fax"] = gvSupplierList.SelectedRow.Cells[5].Text;
            Session["address"] = gvSupplierList.SelectedRow.Cells[6].Text;
            Session["gstregno"] = gvSupplierList.SelectedRow.Cells[7].Text;
            Session["email"] = gvSupplierList.SelectedRow.Cells[8].Text;

        }
    }
}