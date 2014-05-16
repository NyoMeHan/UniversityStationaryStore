#region "Version Information"
/* Class Name       : DepartmentRequisition.cs
' Created By       : ZarNiMMM
' Description      : Department requisition done by Department head
' Created Date     : 05/09/2013
' Version History  : 1.0
  */
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
    public class DepartmentRequBLL
    {
        Team4_ADEntities entity = new Team4_ADEntities();
        int j = 0;
        public int insertHeaderRecord(DateTime processdate, string status, string deptCode)
        {
            DeptRequisition header = new DeptRequisition();

            header.Department_Code = deptCode;
            header.Date = processdate;
            header.Status_Check = status;

            entity.DeptRequisitions.AddObject(header);
            entity.SaveChanges();

            j = header.Dept_ReqID;
            return j;
        }

        public void insertDetailRecord(int dept_reqID, int Emp_reqid, DateTime processdate)
        {
            DeptRequisitionDetail detail = new DeptRequisitionDetail();
            detail.Dept_ReqID = dept_reqID;
            detail.Emp_ReqID = Emp_reqid;
            detail.Date = processdate;

            entity.DeptRequisitionDetails.AddObject(detail);

            entity.SaveChanges();

            //j = detail.Emp_ReqID;
            //return j;
        }

        public void sendNotificationToEmployee(string toemail, string fromemail, string body, string subject)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(toemail); //text = to mail address
                mailMessage.From = new MailAddress(fromemail); //from mail address
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                SmtpClient smtpClient = new SmtpClient("lynx.iss.nus.edu.sg"); //no need to change
                smtpClient.Send(mailMessage);

            }
            catch (Exception ex)
            {
                // Response.Write("Could not send the e-mail - error: " + ex.Message);
            }
        }
    }
}
