using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;
using DTO;
using AutoMapper;


namespace BLL
{
    public class CategoryBLL : ICategoryBLL
    {

        ICategoryDAL catdal;
        IMapper imapper;
        public CategoryBLL(ICategoryDAL catdals)
        {
            this.catdal = catdals;
            var con = new MapperConfiguration(co=>co.AddProfile<Navigation>());
            imapper = con.CreateMapper();
        }

        /*-------------------------------------------*/
        public List<CategoryDTO> AddCategory(CategoryDTO newCategory)
        {
            CategoryTbl cat = imapper.Map<CategoryDTO, CategoryTbl>(newCategory);
            List<CategoryTbl> purList = catdal.AddCategory(cat);
            return imapper.Map<List<CategoryTbl>, List<CategoryDTO>>(purList);
        }

        public List<CategoryDTO> DeleteCategory(int id)
        {
            List<CategoryTbl> purList = catdal.DeleteCategory(id);
            return imapper.Map<List<CategoryTbl>, List<CategoryDTO>>(purList);
        }

        public List<CategoryDTO> GetAll()
        {
            List<CategoryTbl> listcat= catdal.GetAll();
            return imapper.Map<List<CategoryTbl>,List<CategoryDTO>>(listcat);
        }

        public CategoryDTO GetCategoryById(int id)
        {
            CategoryTbl listcat = catdal.GetCategoryById(id);
            return imapper.Map<CategoryTbl, CategoryDTO>(listcat);
        }

        public List<CategoryDTO> UpDateCategory(int id, CategoryDTO UpDateCategory)
        {
            CategoryTbl d = imapper.Map<CategoryDTO, CategoryTbl >(UpDateCategory);            
            List<CategoryTbl> purList = catdal.UpDateCategory(id,d);
            return imapper.Map<List<CategoryTbl>, List<CategoryDTO>>(purList);            
        }
    }

}
