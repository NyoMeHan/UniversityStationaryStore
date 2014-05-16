using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace BizLogic
{
    public class PendingLogic
    {
        
        Team4_ADEntities team = new Team4_ADEntities();
        public void pendingQuantityDisburse()
        {

            bool success = false;
     

            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    
                    var data = (from m in team.Disbursements
                                  where m.Dispatch_Status == "pending"
                                  select m).ToList<Disbursement>();

                    foreach (var z in data)
                    {
                        Pending pd = new Pending()
                        {
                            DisbursementID = z.DisbursementID,
                            Dept_Code = z.Department,
                            Status = "UnFullFilled",
                            Date = DateTime.Now,
                            Pending_Status = "current"
                        };

                        team.Pendings.AddObject(pd);
                        team.SaveChanges();

                        int pendingId = pd.PendingID;
                        int disburseID = pd.DisbursementID;
                        string deptcode = pd.Dept_Code;


                        //var y = (from o in team.Pending_Items
                        //         where o.Department == deptcode
                        //        select o).AsEnumerable<Pending_Items>();

                        var y = (from o in team.DisbursementDetails
                                 where o.DisbursementID == disburseID
                                 &&
                                 o.Outstanding_Type == "pending"
                                 select o).ToList<DisbursementDetail>();

                        foreach (var bike in y)
                        {
                            Pending_Detail pending = new Pending_Detail()
                            {
                                PendingID = pendingId,
                                Item_Code = bike.Item_Code,
                                Quantity = bike.Pending_Qty,
                                Status = "UnFullFilled"

                            };

                            team.Pending_Detail.AddObject(pending);

                            team.SaveChanges();

                        }

                    }

                    team.SaveChanges();
                    transaction.Complete();
                    success = true;
                }
                catch (TransactionAbortedException e)
                {
                    e.Message.ToString();
                }

            }
            if (success)
            {
                team.AcceptAllChanges();
            }
            else
            {
                team.Dispose();
            }
        }


        public IQueryable RetrievePending(string name)
        {
            var x = (from m in team.vw_pendingbyDepartment
                     where m.Department_Name == name
                     select m);

            return x;
        }

        public IQueryable retrieveItemBased()
        {
            var x = from m in team.vw_pendingitem
                    select m;
            return x;
        }
        public void ProcessPending()
        {
            var repository = (from m in team.Pendings
                            where m.Pending_Status == "current"
                            select m).ToList<Pending>();


            foreach (var pendingGather in repository)
            {
                if (pendingGather.Status == "UnFullFilled")
                {
                    var z = (from jay in team.Pending_Detail
                             where jay.PendingID == pendingGather.PendingID
                             select jay).ToList<Pending_Detail>();


                    foreach (var m in z)
                    {
                        var stock = (from s in team.Stock_Item
                                     where s.Item_Code == m.Item_Code
                                     select s).First<Stock_Item>();

                        int tempQuantity = 0;

                        if ((stock.Quantity - m.Quantity) < 0)
                        {
                            tempQuantity = stock.Quantity;
                        }

                        else
                        {
                            tempQuantity = m.Quantity;
                        }

                        StockHistory sh = new StockHistory
                        {
                            Item_Code = stock.Item_Code,
                            Description = stock.Description,
                            Quantity = tempQuantity * (-1),
                            UpdateDate = DateTime.Now,
                            UpdateBy = 1000 //session value
                        };

                        team.StockHistories.AddObject(sh);
                        stock.Quantity = stock.Quantity - m.Quantity;

                        if (stock.Quantity <= 0)
                        {

                            m.Quantity = (-1) * (stock.Quantity);
                            stock.Quantity = 0;
                            m.Status = "UnFullFilled";
                        }

                        else
                        {
                            m.Quantity = 0;
                            m.Status = "FullFilled";
                        }

                    }

                }
            }

            team.SaveChanges();
            UpdateStatus();
        }

        public void UpdateStatus()
        {
            
            var ii = (from bb in team.Pendings
                      select bb).ToList<Pending>();

            foreach (var g in ii)
            {
                var ss = (from a in team.Pending_Detail
                          where a.PendingID == g.PendingID
                          &&
                          a.Status == "UnFullFilled"
                          select a).ToList<Pending_Detail>();

                if (ss.Count == 0)
                {
                    g.Status = "FullFilled";
                    team.SaveChanges();
                }
                //g.Pending_Status = "processed";
            }
        }


        public void changeStatus()
        {
            var x = from m in team.Pendings
                    where m.Pending_Status == "current"
                    select m;

            foreach (var m in x)
            {
                m.Pending_Status = "processed";
            }


            team.SaveChanges();
        }

    }
}
