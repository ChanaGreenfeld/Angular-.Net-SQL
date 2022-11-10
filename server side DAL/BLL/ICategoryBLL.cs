using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;
using DTO;

namespace BLL
{
    public interface ICategoryBLL
    {
        public List<CategoryDTO> GetAll();
        public CategoryDTO GetCategoryById(int id);
        public List<CategoryDTO> AddCategory(CategoryDTO newCategory);
        public List<CategoryDTO> UpDateCategory(int id, CategoryDTO UpDateCategory);
        public List<CategoryDTO> DeleteCategory(int id);
    }
}
