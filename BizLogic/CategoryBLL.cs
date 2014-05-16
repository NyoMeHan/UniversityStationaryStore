using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizLogic
{
   public class CategoryBLL
    {
       //created by SeinnNA
        Team4_ADEntities edm = new Team4_ADEntities();

        public List<Category> GetCategory()
        {

            return this.edm.Categories.ToList();
        }

        public int GetCategoryId(string name)
        {
            Category category_info = edm.Categories.FirstOrDefault(m => m.Category_Name == name);
            if (category_info != null)
            {
                int i = category_info.CategoryID;
            }
            //return category_info.CategoryID;
            return category_info.CategoryID;

        }

        public int AddNewCategory(string cat_name)
        {
            Category category_info = edm.Categories.FirstOrDefault(m => m.Category_Name == cat_name);
            Category category = new Category();
            //int cat_ID;
            if (category_info != null)
            {
                category.CategoryID = category_info.CategoryID;

            }
            else if (category_info == null)
            {
                //Category category = new Category();
                category.Category_Name = cat_name;
                edm.AddToCategories(category);
                edm.SaveChanges();
                //cat_ID = category.CategoryID;
            }


            //cat_ID = category_info.CategoryID;
            return category.CategoryID;

        }


        #region

        public List<Category> GetAllCat()
        {
            return this.edm.Categories.ToList();
        }

        public List<string> GetCatNames()
        {
            var catname = (from r in edm.Categories select r.Category_Name);
            return catname.ToList<string>();
        }

        public string GetCatNameById(int id)
        {
            var q = (from r in edm.Categories where r.CategoryID == id select r);
            Category c = new Category();
            c = q.First<Category>();

            string name = c.Category_Name;
            return name;
        }

        public int GetCatIdByName(string name)
        {
            var q = (from r in edm.Categories where r.Category_Name == name select r);
            Category c = new Category();
            c = q.First<Category>();

            int cid = c.CategoryID;
            return cid;
        }



        #endregion

    }
}
