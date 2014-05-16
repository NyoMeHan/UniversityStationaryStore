#region "Version Information"
/* Form Name       : DepartmentDetails.aspx
' Created By       : Muyar Phyo Han
' Description      : Maintaining Depeartment Information
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
using System.Diagnostics;

namespace LogicUniversityWebLogic
{
    public partial class DepartmentDetail : System.Web.UI.Page
    {

        DepartmentBLL deptbll = new DepartmentBLL();
        EmployeeBLL empbll = new EmployeeBLL();
        CollectionBLL colbll = new CollectionBLL();
        DepartmentRepBLL repbll = new DepartmentRepBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            string newDept = "ENGL";//Session["selected"].ToString();
            if (newDept == "new")
            {
                if (!IsPostBack)
                {
                    txtWritable();
                    btnAdd.Visible = true;
                    btnEdit.Visible = false;
                    btnUpdate.Visible = false;
                    btnReset.Visible = true;
                    txtDeptCode.Enabled = true;
                    ddlDeptRep.Visible = true;
                    ddlDeptHead.Visible = true;
                    ddlContactEmp.Visible = true;
                    ddlCollectionPts.Visible = true;

                    List<string> contactEmp = new List<string>();
                    List<string> headEmp = new List<string>();
                    List<string> coll = new List<string>();
                    List<string> repEmp = new List<string>();

                    contactEmp = empbll.GetEmpNames();
                    ddlContactEmp.DataSource = contactEmp;
                    ddlContactEmp.DataBind();

                    headEmp = empbll.GetEmpNames();
                    ddlDeptHead.DataSource = headEmp;
                    //ddlDeptHead.DataTextField = "EmployeeName";
                    //ddlDeptHead.DataValueField = "id";
                    ddlDeptHead.DataBind();

                    coll = colbll.GetCollectionNames();
                    ddlCollectionPts.DataSource = coll;
                    ddlCollectionPts.DataBind();

                    repEmp = empbll.GetEmpNames();
                    ddlDeptRep.DataSource = repEmp;
                    ddlDeptRep.DataBind();
                }
            }
            else
            {
                if (!IsPostBack)
                {
                    //string deptcode = "myDataL";//Session["selected"].ToString();
					 int empid = Convert.ToInt32(Session["loginUser"]);
					Employee employee = empbll.GetEmployeeById(empid);
					string deptcode = employee.DepartmentCode;
                    Department d = deptbll.GetDepartmentByCode(deptcode);
                    DepartmentRep deptrep = repbll.GetRepsByDeptCode(deptcode);

                    Employee contact = empbll.GetEmployeeById(d.Contact_Person);
                    Employee head = empbll.GetEmployeeById(d.Department_Head);
                    Employee rep = empbll.GetEmployeeById(deptrep.EmployeeID);

                    txtDeptCode.Text = d.Department_Code;
                    txtDeptName.Text = d.Department_Name;

                    //contact emp
                    List<Employee> contactEmp = new List<Employee>();
                    contactEmp = empbll.GetEmployeesByDept(deptcode);
                    ddlContactEmp.DataSource = contactEmp;
                    ddlContactEmp.DataValueField = "EmployeeID";
                    ddlContactEmp.DataTextField = "EmployeeName";
                    ddlContactEmp.DataBind();
                    ddlContactEmp.Items.FindByText(contact.EmployeeName).Selected = true;
                    ddlContactEmp.Enabled = false;

                    txtPhoneNo.Text = d.Phone.ToString();
                    txtFaxNo.Text = d.Fax.ToString();

                    //dept head
                    List<Employee> headEmp = new List<Employee>();
                    headEmp = empbll.GetEmployeesByDept(deptcode);
                    ddlDeptHead.DataSource = headEmp;
                    ddlDeptHead.DataValueField = "EmployeeID";
                    ddlDeptHead.DataTextField = "EmployeeName";
                    ddlDeptHead.DataBind();
                    ddlDeptHead.Items.FindByText(head.EmployeeName).Selected = true;
                    ddlDeptHead.Enabled = false;

                    //collection point
                    List<CollectionPoint> coll = new List<CollectionPoint>();
                    coll = colbll.GetAllCollectionPoint();
                    ddlCollectionPts.DataSource = coll;
                    ddlCollectionPts.DataValueField = "CollectionID";
                    ddlCollectionPts.DataTextField = "Place";
                    ddlCollectionPts.DataBind();
                    ddlCollectionPts.Items.FindByText(d.CollectionPoint.Place).Selected = true;

                    //txtRepName.Text = rep.EmployeeName;
                    List<Employee> repEmp = new List<Employee>();
                    repEmp = empbll.GetEmployeesByDept(deptcode);
                    ddlDeptRep.DataSource = repEmp;
                    ddlDeptRep.DataValueField = "EmployeeID";
                    ddlDeptRep.DataTextField = "EmployeeName";
                    ddlDeptRep.DataBind();
                    ddlDeptRep.Items.FindByText(head.EmployeeName).Selected = true;
                    ddlDeptRep.Enabled = false;

                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //string deptcode = Session["selected"].ToString();
            txtWritable();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // Department d = new Department();
            string code = txtDeptCode.Text;
            string name = txtDeptName.Text;
            //int contact = Convert.ToInt32(txtContactName.Text);
            int contactID = empbll.GetEmpIdByName(ddlContactEmp.SelectedValue);
            int ph = Convert.ToInt32(txtPhoneNo.Text);
            int fax = Convert.ToInt32(txtFaxNo.Text);
            //int head = Convert.ToInt32(txtDeptHead.Text);
            int headID = empbll.GetEmpIdByName(ddlDeptHead.SelectedValue);
            //int col = Convert.ToInt32(txtCollectionPoint.Text);
            int colID = colbll.GetCollectionIdByName(ddlCollectionPts.SelectedValue);

            string s = deptbll.addNewDept(code, name, contactID, ph, fax, headID, colID);
            lblDisplay.Text = s;

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string deptcode = "myDataL";//Session["selected"].ToString();
            Department dept = deptbll.GetDepartmentByCode(deptcode);

            dept.Department_Name = txtDeptName.Text;

            //int contactID = empbll.GetEmpIdByName(txtContactName.Text);
            //dept.Contact_Person = ddlDeptHead.DataValueField;
            dept.Contact_Person = Convert.ToInt32(ddlContactEmp.SelectedItem.Value);

            dept.Phone = Convert.ToInt32(txtPhoneNo.Text);
            dept.Fax = Convert.ToInt32(txtFaxNo.Text);

            //int deptheadID = empbll.GetEmpIdByName(txtDeptHead.Text);
            dept.Department_Head = Convert.ToInt32(ddlDeptHead.SelectedItem.Value);

            //int colID = colbll.GetCollectionIdByName(txtCollectionPoint.Text);
            //dept.CollectionID = colID;
            dept.CollectionID = Convert.ToInt32(ddlCollectionPts.SelectedItem.Value);

            //int repID = empbll.GetEmpIdByName(txtRepName.Text);           

            string s = deptbll.UpdateDepartmentInfo(dept);

            int repID = Convert.ToInt32(ddlDeptRep.SelectedItem.Value);

            repbll.UpdateDeptRep(repID, deptcode);
            lblDisplay.Text = s;
        }

        public void txtWritable()
        {
            //txtDeptCode.Enabled = true;
            txtDeptName.Enabled = true;
            //txtContactName.Enabled = true;
            txtPhoneNo.Enabled = true;
            txtFaxNo.Enabled = true;
            //txtDeptHead.Enabled = true;
            //txtCollectionPoint.Enabled = true;
            //txtRepName.Enabled = true;

            ddlContactEmp.Enabled = true;
            ddlDeptHead.Enabled = true;
            ddlCollectionPts.Enabled = true;
            ddlDeptRep.Enabled = true;
        }

        protected void ddlContactEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtContactName.Text = ddlContactEmp.SelectedItem.Value.ToString();

        }

        protected void ddlDeptHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            // txtDeptHead.Text = ddlDeptHead.SelectedItem.Value.ToString();
            // empid = empbll.GetEmpIdByName(txtDeptHead.Text);
        }

        //protected void ddlCollectionPts_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    txtCollectionPoint.Text = ddlCollectionPts.SelectedItem.Value.ToString();
        //}

        //protected void ddlDeptRep_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    txtRepName.Text = ddlDeptRep.SelectedItem.Value.ToString();

        //}

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtDeptCode.Text = "";
            txtDeptName.Text = "";
           // txtContactName.Text = "";
            txtPhoneNo.Text = "";
            txtFaxNo.Text = "";
           // txtDeptHead.Text = "";
            //txtCollectionPoint.Text = "";

        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {
            string deptcode = "myDataL";//Session["selected"].ToString();

            Department d = deptbll.GetDepartmentByCode(deptcode);
            Employee contact = empbll.GetEmployeeById(d.Contact_Person);
            Employee head = empbll.GetEmployeeById(d.Department_Head);

            txtDeptCode.Text = d.Department_Code;
            txtDeptName.Text = d.Department_Name;
          //  txtContactName.Text = contact.EmployeeName;
            txtPhoneNo.Text = d.Phone.ToString();
            txtFaxNo.Text = d.Fax.ToString();
           // txtDeptHead.Text = head.EmployeeName;
          //  txtCollectionPoint.Text = colbll.GetCollectionNameById(d.CollectionID);

        }
    }
}