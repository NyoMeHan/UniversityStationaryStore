using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace BizLogic
{
    public class AdjustmentBLL
    {
        Team4_ADEntities edm = new Team4_ADEntities();
       
        public int addAdjustment(int adjustBy, DateTime adjustDate,  string authorizedBy)
        {
            Adjustment adjustment = new Adjustment();
            
            adjustment.AdjustBy = adjustBy;
            adjustment.Adjustment_Date = adjustDate;
            //adjustment.ApprovedBy = null;
            adjustment.Approve_Date = DateTime.Now;
            adjustment.Approve_Status = "Pending";
            adjustment.Authorized_By = authorizedBy;


          //  edm.Adjustments.AddObject(adjustment);
            edm.AddToAdjustments(adjustment);
            edm.AddObject("Adjustments", adjustment);
            edm.SaveChanges();

            int current_adjustId = adjustment.AdjustmentID;
                    
            return current_adjustId;
                    
        }


        public IQueryable getIDList()
        { 
            var list = (from r in edm.adjustmentId_list_View where r.Authorized_By == "Manager"  select r);
            return list;
        }
          
        
        
     public IList getAdjust_IDList(string personID)
               
         {
             var list = (from r in edm.adjustmentId_list_View where r.Authorized_By == personID &&  r.Approve_Status=="Pending" select r);
            return list.ToList();
        }

         public string updateAdjustmentInfo(int adjustId,int personId, DateTime date, string status)
        {
           
            Adjustment adjustment_info = edm.Adjustments.FirstOrDefault(m => m.AdjustmentID == adjustId);
            if (adjustment_info != null)
            {
                adjustment_info.ApprovedBy = personId;
                adjustment_info.Approve_Date = date;
                adjustment_info.Approve_Status = status;
            }
            this.edm.SaveChanges();
            
            return "Update Successful";
        }

        ///******* testing methods *****//
        
        /*
        public IQueryable getAdjustmentID()
        {
            var adjustment_list = (from Adjustment in edm.Adjustments where Adjustment.Authorized_By == "Manager" select Adjustment);
            return adjustment_list;
        }

        public List<Adjustment> getAdjust_Idlist()
        {
            var adjustment_list = (from Adjustment in edm.Adjustments where Adjustment.Authorized_By == "Manager" select Adjustment).ToList();
            return adjustment_list;
        }
        */
    }
}
