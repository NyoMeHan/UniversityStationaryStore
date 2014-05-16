using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BizLogic;
using System.Data;
using System.Diagnostics;

namespace MobilePresentationLogic
{
    public partial class StoreDeliveryRecords : System.Web.UI.Page
    {
        StockItemBLL stkbll = new StockItemBLL();
        CategoryBLL cbll = new CategoryBLL();
        StockHistoryBLL hisbll = new StockHistoryBLL();
        PurchaseOrderBLL pobll = new PurchaseOrderBLL();

        PurchaseOrderDetailBLL podetailbll = new PurchaseOrderDetailBLL();

        static DataTable dataValues = new DataTable();

        List<string> pending_ponums = new List<string>();
        PurchaseOrder pendingPO = new PurchaseOrder();

        int recievedById;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDeliveredDate.Text = DateTime.Today.ToShortDateString();

                IList pending_ponums = pobll.GetPendingPONums();
                ddlPONumber.DataSource = pending_ponums;
                ddlPONumber.SelectedValue = "PONumber";
                ddlPONumber.DataBind();

                ddlPONumber.Items.Insert(0, new ListItem("<Select PO NUmber>", ""));

                EmployeeBLL emp = new EmployeeBLL();
                recievedById = Convert.ToInt32(Session["loginUser"]);
				
				 
                txtRecievedBy.Text = emp.GetEmployeeNameById(recievedById);

            }

        }

        protected void imgbtnCalendar_Click(object sender, ImageClickEventArgs e)
        {
            CalendarDeliveredDate.Visible = true;
        }

        protected void CalendarDeliveredDate_SelectionChanged(object sender, EventArgs e)
        {
            txtDeliveredDate.Text = CalendarDeliveredDate.SelectedDate.ToShortDateString();
            CalendarDeliveredDate.Visible = false;
        }


        protected void ddlPONumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPONumber.SelectedIndex != 0)
            {

                string ponum = ddlPONumber.SelectedValue;
                pendingPO = pobll.GetPurchaseOrderByPONum(ponum);

                EmployeeBLL emp = new EmployeeBLL();
                int orderById =(Int32)pendingPO.Ordered_By;
                //string supcode = ;

                SupplierBLL supbll = new SupplierBLL();
                Supplier sup = supbll.GetSupplierByCode(pendingPO.Supplier_Code);

                txtSupplierName.Text = sup.Supplier_Name;

                txtOrderBy.Text = emp.GetEmployeeNameById(orderById);
                txtOrderDate.Text = pendingPO.Order_Date.ToShortDateString();

                txtSupplierName.ReadOnly = true;
                txtOrderBy.ReadOnly = true;
                txtOrderDate.ReadOnly = true;

                List<PurchaseOrderDetail> pendingPOD = new List<PurchaseOrderDetail>();

                pendingPOD = podetailbll.GetPendingPODetails(ponum);
                gvPODetailList.Visible = true;

            }

        }

        protected void btnStoreRecord_Click(object sender, EventArgs e)
        {
            //Purchase Order Table Update
            string pon = ddlPONumber.SelectedValue;
            string dno = txtDeliveryRefNo.Text;
            DateTime deliverDate = DateTime.Parse(txtDeliveredDate.Text);

            //recievedById = 1010; //Convert.ToInt32(Session["LoginUser"].ToString());
            recievedById = Convert.ToInt32(Session["loginUser"]);
            pobll.updatePO(pon, dno, deliverDate, recievedById);
            Debug.WriteLine("po is successfully updated");


            //Purchase Order Detail Table Update
            PurchaseOrderDetail pods = podetailbll.GetPODetailsByPONum(pon);

            int podid = pods.PODetailID;

            foreach (GridViewRow row in gvPODetailList.Rows)
            {
                string code = row.Cells[0].Text;
                TextBox qtyBox = (TextBox)(row.FindControl("txtDeliveredQty"));
                int qty = Convert.ToInt32(qtyBox.Text);

                //purchase order detail table update
                podetailbll.updatePODetail(pon, podid, qty);

                //stock table update
                stkbll.updateStockQtyAfterDelivery(code, qty);

                //stock history update
                string desc = "From Supplier - " + txtSupplierName.Text;
                DateTime updateDate = DateTime.Today;
                hisbll.AddStockHistory(code, desc, qty, updateDate, recievedById);


                podid++;
            }

            //Debug.WriteLine("PODetail is successfully updated");
            //Debug.WriteLine("Stock Table is successfully updated");


        }

        protected void lblItemDesc_DataBinding(object sender, EventArgs e)
        {

        }

    }
}