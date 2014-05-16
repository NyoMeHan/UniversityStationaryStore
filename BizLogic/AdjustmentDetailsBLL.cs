using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizLogic
{
    public class AdjustmentDetailsBLL
    {
        Team4_ADEntities edm = new Team4_ADEntities();

        public int addAdjustmentDetails(int adjustId, string itemCode, int qty, string reason, string status)
        {
            AdjustmentDetail adjust_details = new AdjustmentDetail();

            adjust_details.AdjustmentID = adjustId;
            adjust_details.Item_Code = itemCode;
            adjust_details.Quantity = qty;
            adjust_details.Reason = reason;
            adjust_details.Status = status;

            edm.AdjustmentDetails.AddObject(adjust_details);
            this.edm.SaveChanges();

            int adjustment_detailsId = adjust_details.Adjustment_DetailID;
            return adjustment_detailsId;
        }

        public IQueryable getAdjustListByPerson(int id)
        {

            var list = (from r in edm.adjustment_Id_DetailsView where r.AdjustmentID == id select r);
            return list;
        }
    }
}
