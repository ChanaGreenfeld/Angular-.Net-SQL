using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;

namespace DAL
{
    public interface ICategoryDAL
    {
        public List<CategoryTbl> GetAll();
        public CategoryTbl GetCategoryById(int id);
        public List<CategoryTbl> AddCategory(CategoryTbl newCategory);
        public List<CategoryTbl>  UpDateCategory(int id, CategoryTbl UpDateCategory);
        public List<CategoryTbl>  DeleteCategory(int id);
    }
}
