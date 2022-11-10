using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using System.Linq;
using DAL; 

namespace DAL
{ 
    public class CategoryDAL : ICategoryDAL
    {
        Toys_dbContext cat;
        public CategoryDAL(Toys_dbContext cats)
        {
            this.cat = cats;
        }

        public List<CategoryTbl> AddCategory(CategoryTbl newCategory)
        {
               cat.CategoryTbls.Add(newCategory);
               cat.SaveChanges(); 
               return cat.CategoryTbls.ToList();
        }

        public List<CategoryTbl> DeleteCategory(int id)
        {
            cat.CategoryTbls.Remove(cat.CategoryTbls.Find(id));
            cat.SaveChanges();
            return cat.CategoryTbls.ToList();
        }

        public List<CategoryTbl> GetAll()
        {
            return cat.CategoryTbls.ToList();
        }

        public CategoryTbl GetCategoryById(int id)
        {
            return cat.CategoryTbls.Find(id);
        }

        public List<CategoryTbl> UpDateCategory(int id, CategoryTbl UpDateCategory)
        {
            CategoryTbl ca = cat.CategoryTbls.Find(id);
            ca.NameCategory = UpDateCategory.NameCategory;
            cat.SaveChanges();
            return cat.CategoryTbls.ToList();
        }
    }
}

