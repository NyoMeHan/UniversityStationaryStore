using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;

namespace BizLogic
{
    public class StockItemBLL
    {
        Team4_ADEntities edm = new Team4_ADEntities();

        public List<Stock_Item> GetAllItems()
        {
            return this.edm.Stock_Item.ToList();
        }

        public Stock_Item GetItembyItemCode(string ic)
        {
            var q = (from r in edm.Stock_Item where r.Item_Code == ic select r);
            Stock_Item s = new Stock_Item();
            s = q.First<Stock_Item>();

            return s;
        }

        public Stock_Item GetItembyDesc(string desc)
        {
            var q = (from r in edm.Stock_Item where r.Description == desc select r);
            Stock_Item s = new Stock_Item();
            s = q.First<Stock_Item>();

            return s;
        }

        public string GetItemCode(Stock_Item i)
        {
            var q = (from r in edm.Stock_Item where r.Description == i.Description select r.Item_Code);
            string ans = q.ToString();
            return ans;
        }

        public string GetItemDescByCode(string code)
        {
            var q = (from r in edm.Stock_Item where r.Item_Code.Equals(code) select r.Description);
            string ans = q.ToString();
            return ans;
        }

        public List<string> GetItemDesc()
        {
            var itemdesc = (from r in edm.Stock_Item select r.Description);
            return itemdesc.ToList<string>();
        }

        public List<string> GetItemDescByCat(int cid)
        {
            var itemdesc = (from r in edm.Stock_Item where r.CategoryID == cid select r.Description);
            return itemdesc.ToList<string>();
        }

        public IQueryable GetItemBelowReorderQty()
        {
            var q = (from r in edm.ReorderStockViews where r.Quantity <= r.Reorder_Level select r);
            return q;
        }

        public void updateStockQtyAfterDelivery(string ic, int deliveredQty)
        {
            Stock_Item item = GetItembyItemCode(ic);

            item.Quantity = item.Quantity + deliveredQty;

            this.edm.SaveChanges();

        }

        #region

   


  

 
        public string AddNewStockItem(string item_code, int categoryId, string desc, int reorder_level, int reorder_qty, string unit, int qty)
        {
            Stock_Item item = new Stock_Item();
            item.Item_Code = item_code;
            item.CategoryID = categoryId;
            item.Description = desc;
            item.Reorder_Level = reorder_level;
            item.Reorder_Qty = reorder_qty;
            item.Unit_of_Measure = unit;
            item.Quantity = qty;
            //item.Quantity = qty;

            edm.AddToStock_Item(item);
            edm.SaveChanges();

            return "Adding new Item is successful.";
        }
        public string DeleteStockItem(string item_code)
        {

            //var info = edm.Stock_Item.FirstOrDefault(m => m.Item_Code == item_code);
            var delete_item = from s in edm.Stock_Item where s.Item_Code.Contains(item_code) select s;
            if (delete_item != null)
            {
                this.edm.DeleteObject(delete_item);

            }
            this.edm.SaveChanges();
            return "Delete Stock Item is successful";

        }

        public string UpdateStockItem(string item_code, int cat_id, string description, int reorder_level, int reorder_qty, string unit, int qty)
        {
            Stock_Item stock_info = edm.Stock_Item.FirstOrDefault(m => m.Item_Code == item_code);
            if (stock_info != null)
            {
                stock_info.Item_Code = item_code;
                stock_info.CategoryID = cat_id;
                stock_info.Description = description;
                stock_info.Reorder_Level = reorder_level;
                stock_info.Reorder_Qty = reorder_qty;
                stock_info.Unit_of_Measure = unit;
                stock_info.Quantity = qty;

            }
            this.edm.SaveChanges();
            return "Update Stock Item is successful.";
        }

        public double GetItemPrice(string item_code)
        {
            Stock_Item stock_info = edm.Stock_Item.FirstOrDefault(m => m.Item_Code == item_code);

            double price = Convert.ToDouble(stock_info.Price);

            return price;
        }

        public string GetItemDescription(string item_code)
        {
            Stock_Item item = edm.Stock_Item.FirstOrDefault(m => m.Item_Code == item_code);
            string desc = item.Description;
            return desc;
        }
        #endregion

        #region
        //Created by ZarniMMM
        public List<Stock_Item> GetStockItemByCategorID(int CatID)
        {
            var itemlist = (from m in edm.Stock_Item where m.CategoryID == CatID select m);
            return itemlist.ToList();
        }
        //ended by ZarniMMM

        //Created by SeinnNA

        public List<Stock_Item> GetStockItem()
        {
            return this.edm.Stock_Item.ToList();
        }


        public string updateStockQty(string item_code, int adjust_Qty)
        {
            Stock_Item stockInfo = edm.Stock_Item.FirstOrDefault(m => m.Item_Code == item_code);
            if (stockInfo != null)
            {
                int stock_Qty = stockInfo.Quantity;
                stockInfo.Quantity = stock_Qty - adjust_Qty;

            }
            this.edm.SaveChanges();
            return "Stock Qty is successfully updated.";
        }


        public IQueryable GetCategoryList_ByItem(int categoryId)
        {
            var categoryId_list = (from Stock_Item in edm.Stock_Item where Stock_Item.CategoryID == categoryId select Stock_Item);

            return categoryId_list;
        }


#endregion
    }
}
