using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizLogic
{
    public class AdjustmentLogic
    {
        Team4_ADEntities cntxt = new Team4_ADEntities();
        public void delivery_adjust(int disb_id, string cat, string description, int quantity, string type)
        {
            var categ = (from m in cntxt.Categories
                         where m.Category_Name == cat
                         select m).First<Category>();
            var item = (from m in cntxt.Stock_Item
                        where m.CategoryID == categ.CategoryID
                        select m).First<Stock_Item>();
            var disb = (from m in cntxt.Disbursements
                        where m.DisbursementID == disb_id
                        select m).First<Disbursement>();
            var disb_det = (from m in cntxt.DisbursementDetails
                            where m.Item_Code == item.Item_Code
                            &&
                            m.DisbursementID == disb_id
                            select m).First<DisbursementDetail>();
            disb_det.Alloted = disb_det.Alloted - quantity;
            disb_det.Pending_Qty = disb_det.Pending_Qty + quantity;
            disb_det.Outstanding_Type = "pending";
            disb.Dispatch_Status = "pending";

            Acknowledgement ack = new Acknowledgement
            {
                Adjustment_Date = DateTime.Now,
                Item_Code = item.Item_Code,
                Quantity = quantity,
                Reason = type

            };
            cntxt.AddToAcknowledgements(ack);
            cntxt.SaveChanges();
        }



        public IQueryable getData(string str)
        {
            var x = from m in cntxt.Stock_Item
                    join z in cntxt.Categories
                    on m.CategoryID equals z.CategoryID
                    where z.Category_Name == str
                    select m.Description;

            return x;
        }

    }
}
