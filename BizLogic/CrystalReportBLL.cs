//********* ZAYAR LIN TUN   A0108089Y ***********

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;


namespace BizLogic
{
    public class CrystalReportBLL
    {
        Team4_ADEntities context = new Team4_ADEntities();

        public IList DeptName()
        {
            context = new Team4_ADEntities();
            var name = from d in context.Departments join er in context.EmpRequisitions on d.Department_Code equals er.Department_Code select new { d.Department_Code, d.Department_Name };
            return name.Distinct().ToList();
        }

        public IList ItemName()
        {
            context = new Team4_ADEntities();
            var name = from st in context.Stock_Item join erd in context.EmpRequisitionDetails on st.Item_Code equals erd.Item_Code select new { st.Item_Code, st.Description };
            return name.Distinct().ToList();
        }

        public IList CategoryName()
        {
            context = new Team4_ADEntities();
            var name = from c in context.Categories join st in context.Stock_Item on c.CategoryID equals st.CategoryID join pod in context.PurchaseOrderDetails on st.Item_Code equals pod.Item_Code select new { c.CategoryID, c.Category_Name };
            return name.Distinct().ToList();
        }
        //******************************************************************************************************************************
        //public List<Stock_Item> ItemList(int id)
        //{
        //    context = new Team4_ADEntities();
        //    var item = context.getStockItemInfo(id).ToList();
        //    return item;
        //}
        //*****************************************************New*********************************************************************
        public List<sp_CurrMonthInfo_Result> DeptItemLst(string itemcode, int cMonth, int fMonth)
        {
            context = new Team4_ADEntities();
            var curList = context.sp_CurrMonthInfo(itemcode, cMonth, fMonth).ToList();
            return curList;
        }


        public IList DeptItemLstByThreeMonths(string itemcode, int cMonth, int fMonth, int sMonth, int fmYear, int smYear)
        {
            context = new Team4_ADEntities();
            var list = context.sp_DeptItemListByThreeMonth(itemcode, cMonth, fMonth, sMonth, fmYear, smYear).ToList();
            return list;
        }

        

        //**************************************************************New***********************************************************

        public List<sp_CurrMonthPurchase_Result> CurrMonthPurchase(int pMonth, int cMonth)
        {
            context = new Team4_ADEntities();
            var currList = context.sp_CurrMonthPurchase(pMonth, cMonth).ToList();
            return currList;
        }

        public IList PurchaseCatByThreeMonth(int cMonth, int fMonth, int sMonth, int fmYear,  int smYear)
        {
            context = new Team4_ADEntities();
            var list = context.sp_PurchaseCatByThree(cMonth, fMonth, sMonth, fmYear, smYear).ToList();
            return list;
        }

        //*********************************************************************************************************************************
        public List<sp_DeptReqReport_Result> DeptRequestReport(string code, int pMonth, int cMonth)
        {
            context = new Team4_ADEntities();
            var list = context.sp_DeptReqReport(code, pMonth, cMonth).ToList();
            return list;
        }
        //******************************************************************New*************************************************************

        public IList DeptRequestReportMultiple(string code, int pMonth, int cMonth, string status)
        {
            context = new Team4_ADEntities();
            if (status == "ALL")
            {
                var list = context.sp_DeptReqReport(code, pMonth, cMonth).ToList();
                return list;
            }
            else
            {
                var slist = context.sp_DeptReqReportByStatus(code, pMonth, cMonth, status).ToList();
                return slist;
            }
        }

        public IList DeptRequestRepostThree(string code, int fMonth, int sMonth, int cMonth, int fmYear, int smYear, string status)
        {
            context = new Team4_ADEntities();
            if (status == "ALL")
            {
                var list = context.sp_DeptReqReportByThree(code, fMonth, sMonth, cMonth, fmYear, smYear).ToList();
                return list;
            }
            else
            {
                var slist = context.sp_DeptReqReportByStatusThree(code, fMonth, sMonth, cMonth, fmYear, smYear, status).ToList();
                return slist;
            }
        }


        //*****************************************************New**************************************************************

        public List<Category> Category_Name()
        {
            context = new Team4_ADEntities();
            var query = from c in context.Categories select c;
            return query.ToList();
        }

        

        public IList GetItembyCatId(int id)
        {
            context = new Team4_ADEntities();
            var query = from st in context.Stock_Item join c in context.Categories on st.CategoryID equals id select new { st.Item_Code, st.Description };
            return query.Distinct().ToList();
        }

        public IList GetStockHistory(string itemCode, int month)
        {
            context = new Team4_ADEntities();
            var query = from h in context.sp_StockAdjustmentHistory(itemCode, month) select h;
            return query.ToList();
        }

        //********************************************************************************************************************
        // Validation

        public bool ChkMonth(int cMonth, int pMonth)
        {
            if (pMonth > cMonth)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int GetYear(int cMonth, int pMonth)
        {
            if (pMonth > cMonth)
            {
                return (DateTime.Now.Year) - 1;
            }
            else
            {
                return DateTime.Now.Year;
            }
        }


    }
}
