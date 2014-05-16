using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace BizLogic
{
    public class ItemRetrieve
    {

        Team4_ADEntities cntxt = new Team4_ADEntities();

        public void getRequests()
        {
            bool flag = false;
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    int id, ret_quant, pend_quant, avail_quant, quant;

                    RetrievalMaster rm = new RetrievalMaster
                    {
                        Retrieval_Date = DateTime.Now,
                        Status_Check = "current"

                    };
                    cntxt.RetrievalMasters.AddObject(rm);
                    cntxt.SaveChanges();
                    id = rm.RetrievalID;

                    var x = (from m in cntxt.ItemRequesteds select m).AsEnumerable<ItemRequested>();


                    foreach (var ir in x)
                    {
                        var y = cntxt.Stock_Item.FirstOrDefault(m => m.Item_Code == ir.Item_Code);
                        quant = Convert.ToInt32(ir.Requested_Quantity);
                        avail_quant = y.Quantity;

                        if (quant > avail_quant)
                        {
                            ret_quant = avail_quant;
                            pend_quant = quant - avail_quant;
                        }
                        else
                        {
                            ret_quant = quant;
                            pend_quant = 0;
                        }
                        RetrievalDetail rd = new RetrievalDetail
                        {
                            RetrievalID = id,
                            Item_Code = ir.Item_Code,
                            Quantity = quant,
                            Pending_Quantity = pend_quant,
                            Retrieved_Quantity = ret_quant
                        };
                        UpdateStock(ir.Item_Code, ret_quant);


                        cntxt.RetrievalDetails.AddObject(rd);
                        cntxt.SaveChanges();

                    }

                    trans.Complete();
                    flag = true;


                }
                catch (TransactionException e)
                {
                    e.Message.ToString();
                }
            }
            if (flag)
            {
                cntxt.AcceptAllChanges();
            }
            else
            {
                cntxt.Dispose();
            }
        }

        public void UpdateStock(string code, int quant)
        {
            Stock_Item st = new Stock_Item();
            var stock = (from m in cntxt.Stock_Item
                         where m.Item_Code == code
                         select m).First<Stock_Item>();
            stock.Quantity = stock.Quantity - quant;
            StockHistory sh = new StockHistory()
            {
                Item_Code = stock.Item_Code,
                Description = stock.Description,
                Quantity = -quant,
                UpdateDate = DateTime.Now,
                UpdateBy = 1000   //session
            };
            cntxt.StockHistories.AddObject(sh);
            cntxt.SaveChanges();
        }

        public void Disburse()
        {

            bool flag = false;

            using (TransactionScope trans = new TransactionScope())
            {

                int id;
                List<int> disb_id = new List<int>();
                try
                {
                    var x = (from m in cntxt.DeptRequisitions where m.Status_Check == "current" select m).AsEnumerable<DeptRequisition>();

                    foreach (var d in x)
                    {
                        disb_id.Add(d.Dept_ReqID);
                        var p = (from m in cntxt.Departments
                                 where m.Department_Code == d.Department_Code
                                 select m).First<Department>();



                        Disbursement db = new Disbursement
                        {
                            Disburse_Date = DateTime.Now,
                            Status = "current",
                            Department_ReqID = d.Dept_ReqID,
                            Department = p.Department_Name,
                            Dispatch_Status = "pending"
                        };

                        cntxt.Disbursements.AddObject(db);
                        cntxt.SaveChanges();
                        id = db.DisbursementID;
                        var s = from m in cntxt.DepartmentViews
                                where m.Department_Code == p.Department_Code
                                select m;
                        foreach (var item in s)
                        {
                            DisbursementDetail dbd = new DisbursementDetail
                            {
                                DisbursementID = id,
                                Quantity = Convert.ToInt32(item.Requested_Quantity),
                                Item_Code = item.Item_Code,
                                Outstanding_Type = "pending",
                                Alloted = 0
                            };

                            cntxt.DisbursementDetails.AddObject(dbd);
                            cntxt.SaveChanges();
                        }
                    }



                    trans.Complete();
                    flag = true;
                }

                catch (TransactionException e)
                {
                    e.Message.ToString();
                }
            }
            if (flag)
            {
                cntxt.AcceptAllChanges();
            }
            else
            {
                cntxt.Dispose();
            }
        }

        public IQueryable Dept_ItemsRetrieved(string name)
        {

            var x = from m in cntxt.vw_departmentRequests
                    where m.Department_Name == name
                    select m;
            return x;
        }

        public void ProcessStatus()
        {

            var x = (from m in cntxt.DeptRequisitions
                     where m.Status_Check == "current"
                     select m).ToList<DeptRequisition>();

            foreach (var z in x)
            {
                z.Status_Check = "processed";

            }
            cntxt.SaveChanges();
       
        }

        public IQueryable viewRequests()
        {
            var x = from m in cntxt.vw_requested
                    select m;

            return x;
        }

        public IQueryable viewRetrieve()
        {
            var x = from m in cntxt.vw_retrieveitems
                    select m;

            return x;
        }


    }
}
