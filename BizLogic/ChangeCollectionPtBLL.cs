using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace BizLogic
{
    public class ChangeCollectionPtBLL
    {
        Team4_ADEntities context = new Team4_ADEntities();
        public string GetCurrCollectionPt(string deptCode)
        {
            string place = " ";
            context = new Team4_ADEntities();
            var point = from dt in context.Departments from cp in context.CollectionPoints where cp.CollectionID == ((from d in context.Departments where d.Department_Code == deptCode select new { d.CollectionID }).FirstOrDefault().CollectionID) select new { cp.Place };
            foreach (var p in point)
            {
                place = p.Place.ToString();
            }
            return place;
        }

        public IList CollectionPt()
        {
            context = new Team4_ADEntities();
            var point = from pt in context.CollectionPoints select new { pt.CollectionID, pt.Place };
            return point.ToList();
        }

        public void UpdateDeptInfo(string dName, int id)
        {
            context = new Team4_ADEntities();
            var query = (from dt in context.Departments where dt.Department_Code == dName select dt).FirstOrDefault();

            if (query != null)
            {
                //list.CollectionID = id;
                //cntx.AddToDepartments(list);
                query.CollectionID = id;
                context.SaveChanges();
            }

        }

        public void SendEmailToStore(string toEmail, string fromEmail, string body, string subject)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(toEmail);
                mailMessage.From = new MailAddress(fromEmail);
                mailMessage.Body = body;
                mailMessage.Subject = subject;

                mailMessage.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient("lynx.iss.nus.edu.sg"); //no need to change
                smtpClient.Send(mailMessage);

            }
            catch (Exception ex)
            {
                // Response.Write("Could not send the e-mail - error: " + ex.Message);
            }
        }



        public string getstoreClerk()
        {
            var x = (from m in context.Employees
                    where m.EmployeeType == "StoreClerk"
                    select m).First<Employee>();

            return x.Email;

        }

        public String getcurrentdeparmentcode(int id)
        {

            var x = (from m in context.Employees
                     where m.EmployeeID == id
                     select m).First<Employee>();

           return  x.DepartmentCode.ToString();
        }

    }
}
