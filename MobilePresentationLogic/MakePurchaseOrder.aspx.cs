using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BizLogic;
using System.Diagnostics;
using System.Data;

using System.IO;
using System.Net.Mail;


namespace MobilePresentationLogic
{
    public partial class MakePurchaseOrder : System.Web.UI.Page
    {
        SupplierBLL supbll = new SupplierBLL();
        StockItemBLL stkbll = new StockItemBLL();
        CategoryBLL cbll = new CategoryBLL();

        List<string> supNames = new List<string>();
        List<string> itemDesc = new List<string>();
        List<string> catNames = new List<string>();
        string poNum;

        static DataTable dataValues = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                txtRequestDeliveryDate.Text = DateTime.Today.AddDays(7).ToShortDateString(); //req date is one week from ordering date in default

                supNames = supbll.GetSupplierNames();
                ddlSupplierList.DataSource = supNames;
                ddlSupplierList.DataBind();

                ddlSupplierList.Items.Insert(0, new ListItem("<Select Supplier>", ""));

                catNames = cbll.GetCatNames();
                ddlCategoryList.DataSource = catNames;
                ddlCategoryList.DataBind();
                ddlCategoryList.Items.Insert(0, new ListItem("<Select Category>", ""));

                ddlItemList.Enabled = false;
                ddlItemList.Items.Insert(0, new ListItem("<Select Item>", ""));

                CreateDataTable();

            }
        }


        protected void imgbtnCalendar_Click(object sender, ImageClickEventArgs e)
        {
            CalendarDelReqDate.Visible = true;
        }

        protected void CalendarDelReqDate_SelectionChanged(object sender, EventArgs e)
        {
            txtRequestDeliveryDate.Text = CalendarDelReqDate.SelectedDate.ToShortDateString();
            CalendarDelReqDate.Visible = false;
        }

        protected void ddlSupplierList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ddlCategoryList.SelectedIndex = 0;
            //ddlItemList.SelectedIndex = 0;
        }

        protected void ddlCategoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlItemList.Enabled = true;
            ddlItemList.Items.Clear();

            txtQty.Text = "";
            txtQty.Enabled = false;
            lblUOM.Text = "";


            if (ddlCategoryList.SelectedIndex != 0)
            {
                string cat = ddlCategoryList.SelectedItem.Text;

                int cid = cbll.GetCatIdByName(cat);
                itemDesc = stkbll.GetItemDescByCat(cid);

                ddlItemList.DataSource = itemDesc;
                ddlItemList.DataBind();

            }

            ddlItemList.Items.Insert(0, new ListItem("<Select Item>", ""));

        }

        protected void ddlItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlItemList.SelectedIndex != 0)
            {

                string desc = ddlItemList.SelectedItem.Text;

                txtQty.Enabled = true;

                Stock_Item sitem = stkbll.GetItembyDesc(desc);

                txtQty.Text = sitem.Reorder_Qty.ToString();
                lblUOM.Visible = true;

                lblUOM.Text = sitem.Unit_of_Measure.ToString();

            }
        }


        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            ddlSupplierList.Enabled = false;

            int serialNum = gvPurchaseOrder.Rows.Count;
            serialNum++;
            DataRow drValues = dataValues.NewRow();

            drValues["Sr.No"] = serialNum.ToString();
            drValues["Category"] = ddlCategoryList.SelectedItem.Value;
            drValues["Item Desc"] = ddlItemList.SelectedItem.Value;
            drValues["Order Qty"] = txtQty.Text;
            drValues["Unit of Measurement"] = lblUOM.Text;

            dataValues.Rows.Add(drValues);

            gvPurchaseOrder.DataSource = dataValues;
            gvPurchaseOrder.DataBind();

            //ddlItemList.Items.Insert(0, new ListItem("<Select Item>", ""));
            ddlItemList.SelectedIndex = 0;
            txtQty.Text = "";
            txtQty.Enabled = false;
            lblUOM.Text = "";

            btnSubmit.Enabled = true;
        }

        void CreateDataTable()
        {
            dataValues = new DataTable();
            dataValues.Columns.Add("Sr.No");
            dataValues.Columns.Add("Category");
            dataValues.Columns.Add("Item Desc");
            dataValues.Columns.Add("Order Qty");
            dataValues.Columns.Add("Unit of Measurement");
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //int orderBy = Convert.ToInt32(Session["LoginUser"].ToString());  //need to change later. has to be the login user
            int orderBy = Convert.ToInt32(Session["loginUser"]);
            DateTime orderDate = DateTime.Today;
            DateTime reqDate = DateTime.Parse(txtRequestDeliveryDate.Text);
            string sup = ddlSupplierList.SelectedValue.ToString();
            Supplier s = supbll.GetSupplierByName(sup);
            string scode = s.Supplier_Code;
            //string record_status = "NO";

            PurchaseOrderBLL pobll = new PurchaseOrderBLL();
            poNum = pobll.addNewPO(orderDate, scode, orderBy, reqDate);

            foreach (GridViewRow row in gvPurchaseOrder.Rows)
            {
                string itemDesc = HttpUtility.HtmlDecode(row.Cells[2].Text);

                Stock_Item stock = stkbll.GetItembyDesc(itemDesc);

                string itemcode = stock.Item_Code;

                int qty = Convert.ToInt32(row.Cells[3].Text);

                PurchaseOrderDetailBLL podbll = new PurchaseOrderDetailBLL();
                int poDetailID = podbll.addNewPOD(poNum, itemcode, qty);        //////change type
            }

            lblMsg.Text = "Inserted into PO and POD";

            //SendUsingGmail();

            //send using logic uni email            
            // int currentid = Convert.ToInt32(Session["LoginUser"].ToString());

            int currentid = Convert.ToInt32(Session["loginUser"]); //change later

            string gridviewforemail = formatGridview();
            string emailsubject = "Purchase order from Logic University Stationery Store: (PONumber" + poNum + ")";
            string emailBody = gridviewforemail;

            SendEmailToSupplier(currentid, emailBody, emailsubject);

            //Debug.WriteLine("email sent successfully");

        }


        public void SendEmailToSupplier(int empid, string body, string subject)
        {
            PurchaseOrderBLL pobll = new PurchaseOrderBLL();

            EmployeeBLL empbll = new EmployeeBLL();
            Employee currentuser = new Employee();
            currentuser = empbll.GetEmployeeById(empid);

            Supplier toSupplier = new Supplier();
            toSupplier = supbll.GetSupplierByName(ddlSupplierList.SelectedValue);

            string bodymsg = "Purchase Order Number: " + poNum + "<br/>" + body + "<br/>With Regards,<br/>" + currentuser.EmployeeName;

            pobll.SendEmailToSupplier(toSupplier.Email, currentuser.Email, bodymsg, subject);

        }

        public string formatGridview()
        {
            string gridviewAsBody;

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    gvPurchaseOrder.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());

                    gridviewAsBody = "I would like to place odrer for the following items." + sw.ToString();

                }
            }
            return gridviewAsBody;
        }


        /*
        public void SendUsingGmail()
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    gvPurchaseOrder.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    MailMessage mm = new MailMessage("sebby.zml@gmail.com", "a.phantom.mask@gmail.com");
                    mm.Subject = "GridViewEmail";
                    mm.Body = "GridView: <hr />" + sw.ToString();
                    mm.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;

                    System.Net.NetworkCredential networkcred = new System.Net.NetworkCredential();
                    networkcred.UserName = "sebby.zml@gmail.com";
                    networkcred.Password = "********"; //password

                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkcred;
                    smtp.Port = 587;
                    smtp.Send(mm);

                }
            }
        }
        */

        public override void VerifyRenderingInServerForm(Control control)
        {
            // base.VerifyRenderingInServerForm(control);
        }


        protected void btnChangeSupplier_Click(object sender, EventArgs e)
        {
            string messageFormat = "Changing supplier will lose the added ino in below table. Do you want to continue?";
            // btnChangeSupplier.OnClientClick = " return confirm('Changing supplier will lose the added ino in below table. Do you want to continue?')";
            //btnChangeSupplier.OnClientClick = "return confirm('" + messageFormat + "');";

        }
    }
}