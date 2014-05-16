#region "Version Information"
/* Form Name       : Employee_Requisition.aspx
' Created By       : ZarNiMMM
' Description      : Employee requisition done by Department employee and department head
' Created Date     : 05/09/2013
' Version History  : 1.0
 * */
#endregion

#region "using"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Collections.ObjectModel;
using System.Data;

using BizLogic;
#endregion

namespace LogicUniversityWebLogic
{
    public partial class Employee_Requisition : System.Web.UI.Page
    {
        int totalqty = 0;
        Boolean detaildelete;
        EmployeeRequBLL emreqbll = new EmployeeRequBLL();
        DataTable itemdt = new DataTable(); //for temp table to collect item code
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ComboDataBind();
                gvRequestHeader_DataBind();
                EnableControls(false);

                TempTableforitem();
              
            }
        }


        protected void gvRequestHeader_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string argument = Page.Request.Params.Get("__EVENTARGUMENT");
                int id = Convert.ToInt32(argument.Remove(0, 7));
                if (argument.StartsWith("Select$"))
                {

                    int RequID = Convert.ToInt32(gvRequestHeader.Rows[id].Cells[0].Text);
                    String status = gvRequestHeader.Rows[id].Cells[3].Text;
                    status = status.Trim();
                    txtRequestID.Text = Convert.ToString(RequID);
                    btnSubmit.Text = "Update";
                    gvRequestDetail_DataBind(RequID);
                    if (status.Equals("Pending"))
                    {
                        EnableControls(true);
                        txtEvent.Text = "Enquiry";
                        // TempTableforitem();
                    }
                    else
                    {
                        EnableControls(false);

                    }

                    txtDeptCode.Text = gvRequestHeader.Rows[id].Cells[7].Text;
                    txtDeptName.Text = gvRequestHeader.Rows[id].Cells[5].Text;
                    txtTotalQty.Text = gvRequestHeader.Rows[id].Cells[4].Text;
                    txtStatus.Text = gvRequestHeader.Rows[id].Cells[3].Text;
                    txtRequestedDate.Text = gvRequestHeader.Rows[id].Cells[2].Text;
                    if (txtTotalQty.Text == "" || txtTotalQty.Text == "&nbsp;") txtTotalQty.Text = "0";

                }

                if (e.CommandName == "Update")
                {
                    ((TextBox)gvRequestDetail.Rows[id].Cells[6].FindControl("txtReqQtyupdate")).Enabled = true;
                }

            }

            catch (Exception ee)
            {
                string message = ee.Message;
            }



        }
        void TempTableforitem()
        {

            DataColumn dc = new DataColumn("ItemCode", typeof(String));
            itemdt.Columns.Add(dc);
            ViewState["TempTable"] = itemdt; //temptable


        }

        void ddlItem_DataBind(int categoryid)
        {
            StockItemBLL itembll = new StockItemBLL();

            var itemlist = itembll.GetStockItemByCategorID(categoryid);
            if (itemlist.Count != 0)
            {
                ddlItem.DataTextField = "Description";
                ddlItem.DataValueField = "Item_Code";
                ddlItem.DataSource = itemlist;
                ddlItem.DataBind();
            }
            else
            {
                ddlItem.Items.Clear();
                ddlItem.Items.Insert(0, "No Items for this Category");
            }
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            EnableControls(true);

            gvRequestDetail.DataSource = null;
            gvRequestDetail.DataBind();

            txtStatus.Text = "Pending";
            txtRequestedDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            txtEvent.Text = "Add";
            SaveHeaderRecord(); //save header record first to get requestid

        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int catid = Convert.ToInt32(ddlCategory.SelectedValue.ToString());
            ddlItem_DataBind(catid);
        }

        protected void gvRequestHeader_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRequestHeader.PageIndex = e.NewPageIndex;
            gvRequestHeader_DataBind();
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (gvRequestDetail.Rows.Count > 0)
            {
                int requestid = Convert.ToInt32(txtRequestID.Text);
                int totalqty = Convert.ToInt32(txtTotalQty.Text);
                Boolean result = emreqbll.updateTotalQty(requestid, totalqty);
                if (result)
                {
                    gvRequestHeader_DataBind();
                    EnableControls(false);
                    ResetControls();
                    txtRequestID.Text = "";
                    txtTotalQty.Text = "0";
                    gvRequestDetail.DataSource = null;
                    gvRequestDetail.DataBind();
                    SendNotification(); //send email to department head
                }
                if (btnSubmit.Text == "Submit")
                {
                    string script = "alert('Your Stationery Requisition have been requested!');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Information", script, true);
                }
                else
                {
                    string script = "alert('Your Stationery Requisition have been updated!');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Information", script, true);
                    btnSubmit.Text = "Submit";
                }
            }
            else
            {
                string script = "alert('Please select item to request!');";
                ClientScript.RegisterStartupScript(this.GetType(), "Information", script, true);
            }
        }
        protected void gvRequestDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRequestDetail.PageIndex = e.NewPageIndex;
            gvRequestDetail_DataBind(Convert.ToInt32(txtRequestID.Text));
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {

            string script = "alert('Your current transaction will be cancelled!');";
            ClientScript.RegisterStartupScript(this.GetType(), "Information", script, true);


            if (txtEvent.Text == "Enquiry")
            {
                DataTable dttemptable = ((DataTable)ViewState["TempTable"]);
                if (dttemptable.Rows.Count > 0)
                {
                    for (int i = 0; i < dttemptable.Rows.Count; i++)
                    {
                        detaildelete = emreqbll.deleteDetailItem(Convert.ToInt32(txtRequestID.Text), dttemptable.Rows[i]["ItemCode"].ToString());
                        txtEvent.Text = "";

                    }
                    dttemptable.Rows.Clear();
                    ViewState["TempTable"] = dttemptable;

                }
            }
            else
            {
                if (gvRequestDetail.Rows.Count > 0 && txtRequestID.Text != null)
                {

                    detaildelete = emreqbll.deleteDetail(Convert.ToInt32(txtRequestID.Text)); //delete detail first before header delete


                }
                if (txtRequestID.Text != null)
                {
                    emreqbll.deleteHeader(Convert.ToInt32(txtRequestID.Text)); //to delete header record
                }

            }

            gvRequestHeader_DataBind();
            gvRequestDetail_DataBind(Convert.ToInt32(txtRequestID.Text));
            EnableControls(false);
            ResetControls();
            txtRequestID.Text = "";
            txtTotalQty.Text = "0";

        }
        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            if (CheckDetailExisting())
            {
                lblMessage.Text = "You have chosen the selected item. So, Please update the quantity by selecting from list";
            }
            else
            {

                if (txtRequestID.Text != "")
                {
                    EmployeeRequBLL empbll = new EmployeeRequBLL();
                    empbll.insertDetailRecord(Convert.ToInt32(txtRequestID.Text), ddlItem.SelectedValue.ToString(), Convert.ToInt32(txtQty.Text));

                    gvRequestDetail_DataBind(Convert.ToInt32(txtRequestID.Text));

                    CalculateTotalQty();
                    if (txtEvent.Text == "Enquiry")
                    {
                        DataTable dttemptable = ((DataTable)ViewState["TempTable"]);//get records from viewstate
                        DataRow dr = dttemptable.NewRow();
                        dr["ItemCode"] = ddlItem.SelectedValue.ToString();
                        dttemptable.Rows.Add(dr);
                        ViewState["TempTable"] = dttemptable;
                    }
                    ComboDataBind();
                    txtQty.Text = "0";
                }
                lblMessage.Text = "";
            }
        }

        protected void gvRequestDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox updateqty = (TextBox)gvRequestDetail.Rows[e.RowIndex].FindControl("txtReqQtyupdate");
            ImageButton imgUpdate = (ImageButton)gvRequestDetail.Rows[e.RowIndex].FindControl("imgBtnUpdate");


            if (updateqty.Enabled == false)
            {
                updateqty.Enabled = true;

                imgUpdate.ImageUrl = "Images/Save.gif";

            }
            else
            {

                string qtystring = updateqty.Text;
                if (qtystring.Trim() == "" || qtystring.Trim() == "0")
                {
                    string script = "alert('Quantity must be number and greater than 0!');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Information", script, true);
                }
                else
                {
                    //check validation as cannot use validatin from client side
                    int qty = Convert.ToInt32(qtystring.Trim());
                    for (int i = 0; i < qtystring.Length; i++)
                    {
                        if (!char.IsNumber(qtystring[i]))
                        {
                            string script = "alert('Quantity must be number and greater than 0!');";
                            ClientScript.RegisterStartupScript(this.GetType(), "Information", script, true);
                            return;
                        }

                    }
                    //Update Qty to Detail table 

                    TableCell itemcodecell = gvRequestDetail.Rows[e.RowIndex].Cells[3];
                    emreqbll.updateQty(Convert.ToInt32(txtRequestID.Text), itemcodecell.Text, qty);
                    //Update qty to Detail table 
                    CalculateTotalQty();
                    updateqty.Enabled = false;
                    imgUpdate.ImageUrl = "Images/Edit.gif";
                }
                gvRequestDetail_DataBind(Convert.ToInt32(txtRequestID.Text));
                ResetControls();

            }
        }
        protected void gvRequestDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int count = gvRequestDetail.Rows.Count;

            TableCell itemcodecell = gvRequestDetail.Rows[e.RowIndex].Cells[3];

            Boolean result = emreqbll.deleteDetailItem(Convert.ToInt32(txtRequestID.Text), itemcodecell.Text);
            if (result)
            {
                gvRequestDetail_DataBind(Convert.ToInt32(txtRequestID.Text));
                EnableControls(true);
                ResetControls();
            }
        }
        protected void gvRequestHeader_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            TableCell reqID = gvRequestHeader.Rows[e.RowIndex].Cells[0];
            TableCell statuscell = gvRequestHeader.Rows[e.RowIndex].Cells[3];
            if (statuscell.Text.Trim().Equals("Pending"))
            {
                gvRequestDetail_DataBind(Convert.ToInt32(reqID.Text)); //need to bind detail records first before delete
                if (gvRequestDetail.Rows.Count > 0)
                {
                    for (int i = 0; i < gvRequestDetail.Rows.Count; i++)
                    {
                        detaildelete = emreqbll.deleteDetail(Convert.ToInt32(reqID.Text)); //delete detail first before header delete
                    }
                    if (detaildelete == true)
                    {
                        emreqbll.deleteHeader(Convert.ToInt32(reqID.Text));
                    }
                }
                else
                {
                    emreqbll.deleteHeader(Convert.ToInt32(reqID.Text));
                }
                gvRequestHeader_DataBind();
                gvRequestDetail_DataBind(0);
                ResetControls();
            }
            else
            {
                string script = "alert('Requisition has been approved or rejected, Cannot delete!');";
                ClientScript.RegisterStartupScript(this.GetType(), "Information", script, true);
            }
        }
        void SendNotification()
        {

            EmployeeBLL empbll = new EmployeeBLL();
            Employee employeeinfo = new Employee();
            Employee headinfo = new Employee();
            //int empid = Convert.ToInt32(Session["loginUser"]);

            //int empid = 1004; //to update empid
             int empid = Convert.ToInt32(Session["loginUser"]);
            employeeinfo = empbll.getEmployeebyempid(empid);

            headinfo = empbll.getEmailAddressbyempType(employeeinfo.DepartmentCode, "head"); //to update employee type

            String body = "Please help to approve my stationery request! Thanks.\n" + "Best Regards,\n" + employeeinfo.EmployeeName;
            String subject = "Stationery Request from " + employeeinfo.EmployeeName;

            emreqbll.sendNotificationToDeptHead(headinfo.Email, employeeinfo.Email, body, subject);

        }
        void ComboDataBind()
        {
            CategoryBLL catBll = new CategoryBLL();
            var cat = catBll.GetCategory();
            ddlCategory.DataTextField = "Category_Name";
            ddlCategory.DataValueField = "CategoryID";

            ddlCategory.DataSource = cat;
            ddlCategory.DataBind();
            //ddlCategory.Items.Insert(0, "Choose Category ...");
            int catid = Convert.ToInt32(ddlCategory.SelectedValue.ToString());
            ddlItem_DataBind(catid);

        }

        void gvRequestHeader_DataBind()
        {
            DepartmentBLL deptbll = new DepartmentBLL();
            int empid = Convert.ToInt32(Session["loginUser"]);

          //   int empid = Convert.ToInt32(Session["loginUser"]);
            EmployeeBLL empbll = new EmployeeBLL();
            Employee empinfo = empbll.getEmployeebyempid(empid);
            //Department depart = deptbll.getDeptCodebyEmpID(empid);
            if (empinfo.EmployeeType.ToLower().Trim() == "head")
            {

                gvRequestHeader.DataSource = emreqbll.GetHeaderRecordsforHead(empinfo.DepartmentCode); //to show all requisition if loginuser is department head
            }
            else
            {

                gvRequestHeader.DataSource = emreqbll.GetHeaderRecords(empinfo.DepartmentCode, empid); //to show only individual records if loginuser is employee
            }
            gvRequestHeader.DataBind();


        }

        void gvRequestDetail_DataBind(int requestid)
        {
            //EmployeeRequBLL empReqbll = new EmployeeRequBLL();
            if (requestid >= 0)
            {
                var detailrequitem = emreqbll.GetDetailRecords(requestid);
                gvRequestDetail.DataSource = detailrequitem;
                gvRequestDetail.DataBind();
            }

        }
        void EnableControls(Boolean result)
        {
            if (result)
            {
                // lblItemName.Enabled = true;
                // lblQuantity.Enabled = true;
                //lblSelectCategory.Enabled = true;
                txtQty.Enabled = true;
                ddlCategory.Enabled = true;
                ddlItem.Enabled = true;
                gvRequestDetail.Enabled = true;
                btnAddItem.Enabled = true;
                btnSubmit.Enabled = true;
                btnCancel.Enabled = true;
            }
            else
            {
                txtTotalQty.Enabled = false;
                txtQty.Enabled = false;
                ddlCategory.Enabled = false;
                ddlItem.Enabled = false;
                gvRequestDetail.Enabled = false;
                btnAddItem.Enabled = false;
                btnSubmit.Enabled = false;
                btnCancel.Enabled = false;
            }
        }

        void SaveHeaderRecord()
        {
            DepartmentBLL deptbll = new DepartmentBLL();
             int empid = Convert.ToInt32(Session["loginUser"]);
            Department depart = deptbll.getDeptCodebyEmpID(empid); //need to update session value of employee id

            int empreqid = emreqbll.insertHeaderRecord(empid, DateTime.Now, txtStatus.Text, depart.Department_Code);
            txtRequestID.Text = Convert.ToString(empreqid);
            txtDeptName.Text = depart.Department_Name; //need to bind the correct departname by empid

        }
        void ResetControls()
        {
            ComboDataBind();
            txtQty.Text = "0";
            lblMessage.Text = "";
        }
        void CalculateTotalQty()
        {
            int count = gvRequestDetail.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                TextBox updateqty = (TextBox)gvRequestDetail.Rows[i].FindControl("txtReqQtyupdate");
                totalqty = totalqty + Convert.ToInt32(updateqty.Text);
            }
            txtTotalQty.Text = totalqty.ToString();
        }

        Boolean CheckDetailExisting()
        {
            int emprequid = Convert.ToInt32(txtRequestID.Text);
            string itemcode = ddlItem.SelectedValue.ToString();
            Boolean result = emreqbll.CheckItemexisting(emprequid, itemcode);
            return result;
        }


    }
}