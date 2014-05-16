#region "Version Information"
/* Class Name       : EmployeeRequisition
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
using System.Text;
using System.Net.Mail;

#endregion 


namespace BizLogic
{
    public class EmployeeRequBLL
    {
        Team4_ADEntities entity = new Team4_ADEntities();
        int j = 0;
        public List<SelectEmpRequisition_View> GetHeaderRecords(String DeptCode, int empid)
        {
            var headerrecords = (from m in entity.SelectEmpRequisition_View where m.Department_Code == DeptCode && m.EmployeeID == empid select m);
            return headerrecords.ToList();

        }

        public List<SelectEmpRequisition_View> GetHeaderRecordsforHead(String DeptCode)
        {
            var headerrecords = (from m in entity.SelectEmpRequisition_View where m.Department_Code == DeptCode select m);
            return headerrecords.ToList();

        }
        public List<SelectEmpRequisition_View> GetPendingRequest(String DeptCode)
        {
            var pendingrecords = (from m in entity.SelectEmpRequisition_View where m.Department_Code == DeptCode && m.Status == "Pending" select m);

            return pendingrecords.ToList();

        }
        public List<SelectRequestDetail_View> GetDetailRecords(int emp_reqId)
        {
            var detailitem = (from m in entity.SelectRequestDetail_View where m.Emp_ReqID == emp_reqId select m);

            return detailitem.ToList();



        }
        public EmpRequisition getEmpReqbyID(int Emp_ReqID)
        {

            EmpRequisition reqheader = entity.EmpRequisitions.First<EmpRequisition>(x => x.Emp_ReqID == Emp_ReqID);
            return reqheader;

        }

        public EmpRequisitionDetail getRequestDetail(int Emp_ReqID)
        {

            EmpRequisitionDetail reqdetail = entity.EmpRequisitionDetails.First<EmpRequisitionDetail>(x => x.Emp_ReqID == Emp_ReqID);
            return reqdetail;

        }
        public EmpRequisitionDetail getRequestDetailbyItemCode(int emp_reqID, string itemCode)
        {

            EmpRequisitionDetail reqdetail = entity.EmpRequisitionDetails.First<EmpRequisitionDetail>(m => (m.Emp_ReqID == emp_reqID) && (m.Item_Code == itemCode));
            return reqdetail;
        }

        public Boolean CheckItemexisting(int emp_reqID, string itemCode)
        {
            var reqdetail = (from m in entity.EmpRequisitionDetails where m.Emp_ReqID == emp_reqID && m.Item_Code == itemCode select m);
            if (reqdetail.Count() > 0)
            { return true; }
            else return false;


        }
        public int insertHeaderRecord(int employeeid, DateTime requestedDate, string status, string deptCode)
        {
            EmpRequisition header = new EmpRequisition();

            header.EmployeeID = employeeid;
            header.Requested_Date = requestedDate;
            header.Status = status;
            header.Department_Code = deptCode;

            entity.EmpRequisitions.AddObject(header);
            entity.SaveChanges();

            j = header.Emp_ReqID;
            return j;
        }

        public void insertDetailRecord(int emp_requid, string itemCode, int reqQty)
        {
            EmpRequisitionDetail detail = new EmpRequisitionDetail();
            detail.Emp_ReqID = emp_requid;
            detail.Item_Code = itemCode;
            detail.Requested_Qty = reqQty;

            entity.EmpRequisitionDetails.AddObject(detail);

            entity.SaveChanges();

        }

        public string updateQty(int empreqid, string item_code, int reqqty)
        {
            EmpRequisitionDetail detailinfo = this.getRequestDetailbyItemCode(empreqid, item_code);
            if (detailinfo != null)
            {
                detailinfo.Requested_Qty = reqqty;
            }
            this.entity.SaveChanges();
            string result = "Update Quantity Successful";
            return result;

        }

        public Boolean updateTotalQty(int emp_reqID, int totalqty)
        {
            EmpRequisition info = this.getEmpReqbyID(emp_reqID);
            if (info != null)
            {
                info.TotalRequested_Qty = totalqty;
            }
            this.entity.SaveChanges();

            return true;

        }
        public void updateStatus(int reqid, String status)
        {
            EmpRequisition requestinfo = this.getEmpReqbyID(reqid);
            if (requestinfo != null)
            {
                requestinfo.Status = status;
            }
            this.entity.SaveChanges();


        }
        public void deleteHeader(int emp_reqID)
        {

            var headerrecord = entity.EmpRequisitions.First<EmpRequisition>(m => (m.Emp_ReqID == emp_reqID));
            entity.DeleteObject(headerrecord);
            entity.SaveChanges();

        }
        public Boolean deleteDetail(int emp_reqID)
        {

            var detailitemdelete = entity.EmpRequisitionDetails.First<EmpRequisitionDetail>(m => (m.Emp_ReqID == emp_reqID));
            entity.DeleteObject(detailitemdelete);
            entity.SaveChanges();
            return true;
        }
        public Boolean deleteDetailItem(int emp_reqID, string item_code)
        {

            var detailitembycode = entity.EmpRequisitionDetails.First<EmpRequisitionDetail>(m => (m.Emp_ReqID == emp_reqID) && (m.Item_Code == item_code));
            entity.DeleteObject(detailitembycode);
            entity.SaveChanges();

            return true;
        }

        public void sendNotificationToDeptHead(string toemail, string fromemail, string body, string subject)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(toemail); //text = to mail address
                mailMessage.From = new MailAddress(fromemail); //from mail address
                // mailMessage.CC.Add("michael_liau@hotmail.com"); //up to 

                mailMessage.Subject = subject;
                mailMessage.Body = body;
                //  SmtpClient smtpClient = new SmtpClient("mail.singnet.com.sg");
                SmtpClient smtpClient = new SmtpClient("lynx.iss.nus.edu.sg"); //no need to change
                smtpClient.Send(mailMessage);
                // Response.Write("E-mail sent!");
            }
            catch (Exception ex)
            {
                // Response.Write("Could not send the e-mail - error: " + ex.Message);
            }
        }
    }
}
