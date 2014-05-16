using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Entity;
using System.Diagnostics;

namespace BizLogic
{
    public class PurchaseOrderDetailBLL
    {
        Team4_ADEntities edm = new Team4_ADEntities();
        public List<PurchaseOrderDetail> GetAllPODetails()
        {
            return this.edm.PurchaseOrderDetails.ToList();
        }


        public List<PurchaseOrderDetail> GetPendingPODetails(string pon)
        {

            var q = (from r in edm.PurchaseOrderDetails where r.PONumber == pon select r).ToList();

            return q;
        }

        public PurchaseOrderDetail GetPODetailsByPONum(string pon)
        {
            var q = (from r in edm.PurchaseOrderDetails where r.PONumber == pon select r);
            PurchaseOrderDetail pod = new PurchaseOrderDetail();
            pod = q.First<PurchaseOrderDetail>();

            return pod;
        }

        public PurchaseOrderDetail GetPODetailsByPOID(int poid)
        {
            var q = (from r in edm.PurchaseOrderDetails where r.PODetailID == poid select r);
            PurchaseOrderDetail d = new PurchaseOrderDetail();
            d = q.First<PurchaseOrderDetail>();

            return d;
        }

        public IQueryable GetPurchaseOrderDetailsList(string poid)
        {
            var q = (from r in edm.PurchaseOrderDetailViews where r.PONumber == poid select r);
            return q;
        }


        //change new type
        public int addNewPOD(string poNum, string icode, int orderqty)
        {
            PurchaseOrderDetail pod = new PurchaseOrderDetail();

            pod.PONumber = poNum;
            pod.Item_Code = icode;
            pod.Order_Qty = orderqty;

            edm.PurchaseOrderDetails.AddObject(pod);
            this.edm.SaveChanges();

            int podid = pod.PODetailID;
            return podid;

        }

        public void updatePODetail(string pon, int podnum, int deliveredQty)
        {
            PurchaseOrderDetail pod = GetPODetailsByPOID(podnum);

            pod.Deliver_Qty = deliveredQty;

            this.edm.SaveChanges();

        }
    }
}
