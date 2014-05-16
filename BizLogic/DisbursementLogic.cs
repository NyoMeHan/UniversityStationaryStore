using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

namespace BizLogic
{
    public class DisbursementLogic
    {

        Team4_ADEntities team = new Team4_ADEntities();

        public void disburse()
        {

            OrderedDictionary diction = new OrderedDictionary();
            var dust = (from myData in team.RetrievalMasters
                        where myData.Status_Check == "current"
                        select myData).First<RetrievalMaster>();


            int retrieveid = dust.RetrievalID;

            var d = (from m in team.RetrievalDetails
                     where m.RetrievalID == retrieveid
                     select m).ToList<RetrievalDetail>();

            foreach (var item in d)
            {
                diction.Add(item.Item_Code, Convert.ToInt32(item.Retrieved_Quantity));

            }

            // increament the alloted quantity by 1 
            //checking the following contraints
            // till the requested quantity is full filled and 
            // total retrived quantity is reached
            // basically using while loop
            // applying round robin algorithm

            object[] keys = new object[diction.Keys.Count];
            diction.Keys.CopyTo(keys, 0);

            for (int i = 0; i < diction.Keys.Count; i++)
            {
                String str = keys[i].ToString();
                int retrieve = Convert.ToInt32(diction[i]);

                var disbursmentmaster = (from g in team.Disbursements
                                         where g.Status == "current"
                                         select g).ToList<Disbursement>();

                foreach (var bike in disbursmentmaster)
                {
                    var x = (from m in team.DisbursementDetails
                             where m.Item_Code == str
                             &&
                             m.DisbursementID == bike.DisbursementID
                             select m).ToList<DisbursementDetail>();
                    int tt = 0;

                    if (x.Count > 0)
                    {
                        int qun = 0;
                        foreach (var cake in x)
                        {
                            qun = cake.Quantity + qun;
                        }
                        while ((tt < retrieve) && (tt < qun))
                        {
                            foreach (var countData in x)
                            {

                                if ((countData.Alloted < countData.Quantity) && (tt < retrieve))
                                {
                                    countData.Alloted = countData.Alloted + 1;
                                    tt = tt + 1;
                                }


                            }
                        }


                    }
                }

                //foreach (var v in jj)
                //{
                //    if (!(v.Outstanding_Type == "pending"))
                //    {
                //        cal.Status = "completed";
                //    }
                //}



                team.SaveChanges();

                calculatePending();
                UpdateStatus();
                // UpdateRetrivalStatus(retrieveid);

            }

        }


        //public int calculateAlloted(string item)
        //{
        //    var total = (from m in team.calculateAlloteds
        //                 where m.Item_Code == item
        //                 select m).First<calculateAlloted>();

        //    return Convert.ToInt32(total.Total_Alloted);
        //}


        public void calculatePending()
        {
            var caluculate = (from m in team.DisbursementDetails
                              select m).ToList<DisbursementDetail>();

            foreach (var z in caluculate)
            {
                z.Pending_Qty = Convert.ToInt32(z.Quantity - z.Alloted);

                if (z.Pending_Qty == 0)
                {
                    z.Outstanding_Type = "No Outstanding";
                }
            }
            team.SaveChanges();
        }

        public void UpdateStatus()
        {
            var status = (from m in team.Disbursements
                          select m).ToList<Disbursement>();

            foreach (var m in status)
            {
                var detailstatus = (from c in team.DisbursementDetails
                                    where c.DisbursementID == m.DisbursementID
                                    &&
                                    c.Outstanding_Type == "pending"
                                    select c).ToList<DisbursementDetail>();

                if (detailstatus.Count == 0)
                {
                    m.Dispatch_Status = "completed";
                }


            }
            team.SaveChanges();
        }

        public void processUpdation()
        {
            var c = (from m in team.RetrievalMasters
                     where m.Status_Check == "current"
                     select m).First<RetrievalMaster>();

            c.Status_Check = "processed";
            team.SaveChanges();
        }

        public IQueryable getDisburseView(string str)
        {
            var x = from m in team.vw_disbursement
                    where m.Department_Name == str
                    select m;

            return x;
        }

        public void changeStatusforDisbursement()
        {
            var m = from x in team.Disbursements
                    where x.Status == "current"
                    select x;


            foreach (var z in m)
            {
                z.Status = "processed";
            }


            team.SaveChanges();
        }

    }
}
