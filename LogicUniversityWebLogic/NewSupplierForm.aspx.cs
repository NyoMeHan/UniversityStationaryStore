#region "Version Information"
/* Form Name       : NewStockItem.aspx
' Created By       : Muyar Phyo Han
' Description      : Adding New Supplier Information
' Created Date     : 09/09/2013
' Version History  : 1.0
 * */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BizLogic;

namespace LogicUniversityWebLogic
{
    public partial class NewSupplierForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Update"].ToString() == "Update")
                {
                    txtGstregno.Text = Session["gstregno"].ToString();
                    txtSuppliercode.Text = Session["supCode"].ToString();
                    txtSuppliername.Text = Session["suppliername"].ToString();
                    txtContactname.Text = Session["contactname"].ToString();
                    txtPhoneno.Text = Session["phone"].ToString();
                    txtFaxno.Text = Session["fax"].ToString();
                    txtAddress.Text = Session["address"].ToString();
                    txtEmail.Text = Session["email"].ToString();

                }
                else if (Session["AddNew"].ToString() == "Add")
                {
                    Session["gstregno"] = "";
                    Session["supCode"] = "";
                    Session["suppliername"] = "";
                    Session["contactname"] = "";
                    Session["phone"] = "";
                    Session["fax"] = "";
                    Session["address"] = "";
                    Session["eamil"] = "";

                    txtGstregno.Text = "";
                    txtSuppliercode.Text = "";
                    txtSuppliername.Text = "";
                    txtContactname.Text = "";
                    txtPhoneno.Text = "";
                    txtFaxno.Text = "";
                    txtAddress.Text = "";
                    txtEmail.Text = "";

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SupplierBLL supbll = new SupplierBLL();
            string gstregno = txtGstregno.Text;
            string suppliercode = txtSuppliercode.Text;
            string suppliername = txtSuppliername.Text;
            string contactname = txtContactname.Text;
            string phone = txtPhoneno.Text;
            string fax = txtFaxno.Text;
            string address = txtAddress.Text;
            string email = txtEmail.Text;


            string a = supbll.Createsupplier(gstregno, suppliercode, suppliername, contactname, phone, fax, address, email);

            Response.Redirect("~/UpdateSupplierInfo.aspx");
        }

        protected void bttnUpdate_Click(object sender, EventArgs e)
        {
            SupplierBLL supBll = new SupplierBLL();
            //Supplier sp = new Supplier();
            string Supplier_Code = txtSuppliercode.Text;
            string Supplier_Name = txtSuppliername.Text;
            string Contact_Name = txtContactname.Text;
            string phone = txtPhoneno.Text;
            string Fax = txtFaxno.Text;
            string Address = txtAddress.Text;
            string GST_RegNo = txtGstregno.Text;
            string email = txtEmail.Text;

            string s = supBll.Updatesupplier(Supplier_Code, Supplier_Name, Contact_Name, phone, Fax, Address, GST_RegNo, email);
            lblmsg.Text = s;

        }
    }
}