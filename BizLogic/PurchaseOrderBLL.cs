using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.Net.Mail;

namespace BizLogic
{
    public class PurchaseOrderBLL
    {
        Team4_ADEntities edm = new Team4_ADEntities();
        public List<PurchaseOrder> GetAllPO()
        {
            return this.edm.PurchaseOrders.ToList();
        }

        public List<PurchaseOrder> GetPendingPOList()
        {
            var result = (from r in edm.PurchaseOrders
                          where r.StoredRecord_Status.Equals("NO")
                          select r);
            return result.ToList<PurchaseOrder>();
        }

        public IList GetPendingPONums()
        {
            var result = (from r in edm.PurchaseOrders
                          where r.StoredRecord_Status.Equals("NO")
                          select r);
            return result.ToList();
        }

        public PurchaseOrder GetPurchaseOrderByPONum(string pon)
        {
            var q = (from r in edm.PurchaseOrders where r.PONumber == pon select r);
            PurchaseOrder po = new PurchaseOrder();
            po = q.First<PurchaseOrder>();

            return po;
        }

        public string createPO_ID()
        {
            string id = "";
            var poId = (from po in edm.PurchaseOrders orderby po.PONumber descending select po.PONumber).Take(1).SingleOrDefault();
            int ponum = Convert.ToInt32(poId.Substring(3, 5)) + 1;

            if (ponum < 10)
            {
                id = "PO 0000" + ponum;
            }
            else if (ponum < 100)
            {
                id = "PO 000" + ponum;
            }
            else if (ponum < 1000)
            {
                id = "PO 00" + ponum;
            }
            else if (ponum < 10000)
            {
                id = "PO 0" + ponum;
            }
            else if (ponum < 100000)
            {
                id = "PO " + ponum;
            }

            return id;
        }

        public string addNewPO(DateTime orderdate, string supcode, int orderby, DateTime reqdate)
        {

            PurchaseOrder po = new PurchaseOrder();

            po.PONumber = createPO_ID();
            po.Order_Date = orderdate;
            po.Supplier_Code = supcode;
            po.Department_Code = "UNISTR";   //change later
            po.Ordered_By = orderby;
            po.Request_Date = reqdate;
            po.StoredRecord_Status = "NO"; //at first status will be "NO" Will be changed to "YES" only when it is updated.
            edm.PurchaseOrders.AddObject(po);
            this.edm.SaveChanges();

            string pon = po.PONumber;

            return pon;
        }

        public void updatePO(string pon, string dno, DateTime deliverDate, int recievedBy)
        {

            PurchaseOrder po = GetPurchaseOrderByPONum(pon);

            po.Delivery_Number = dno;
            po.Received_By = recievedBy;
            po.Deliver_Date = deliverDate;
            po.StoredRecord_Status = "YES"; ;
            //edm.PurchaseOrders.AddObject(po);
            this.edm.SaveChanges();


        }


        public void SendEmailToSupplier(string toemail, string fromemail, string body, string subject)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(toemail); //text = to mail address
                mailMessage.From = new MailAddress(fromemail); //from mail address
                mailMessage.Subject = subject;
                mailMessage.Body = body;

                mailMessage.IsBodyHtml = true; //add by zml
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
