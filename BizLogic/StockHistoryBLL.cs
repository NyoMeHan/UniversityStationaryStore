using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace BizLogic
{
    public class StockHistoryBLL
    {

        Team4_ADEntities edm = new Team4_ADEntities();

        public List<StockHistory> GetAllItems()
        {
            return this.edm.StockHistories.ToList();
        }

        public StockHistory GetItembyItemCode(string ic)
        {
            var q = (from r in edm.StockHistories where r.Item_Code == ic select r);
            StockHistory s = new StockHistory();
            s = q.First<StockHistory>();

            return s;
        }

        public void AddStockHistory(string ic, string desc, int deliveredQty, DateTime updateDate, int empid)
        {
            StockHistory his = new StockHistory();

            his.Item_Code = ic;
            his.Description = desc;
            his.Quantity = deliveredQty;
            his.UpdateDate = updateDate;
            his.UpdateBy = empid;

            edm.StockHistories.AddObject(his);
            this.edm.SaveChanges();

        }


        public string AddStockHistoryForAdjustment(string item_code, string desc, int adjustedQty, DateTime updateDate, int empid)
        {
            StockHistory history = new StockHistory();
            history.Item_Code = item_code;
            history.Description = desc;
            history.Quantity = adjustedQty;
            history.UpdateDate = updateDate;
            history.UpdateBy = empid;

            edm.StockHistories.AddObject(history);
            this.edm.SaveChanges();
            return "Adding StockHistory is Successful";
        }


        public ArrayList getDescription(string str)
        {
            ArrayList f = new ArrayList();
            var x = (from m in edm.Categories
                    where m.Category_Name == str
                    select m).First<Category>();

            var ff = from c in edm.Stock_Item
                    where c.Description == x.Category_Name
                    select c.Description;

            foreach (var fff in ff.ToList())
            {
                f.Add(fff);
            }

            return f;
        }

        public ArrayList getCategory()
        {
            ArrayList al = new ArrayList();

            var x = (from m in edm.Categories
                     select m).ToList();

            foreach (var z in x)
            {
                al.Add(z);
            }


            return al;
        }

    }
}
