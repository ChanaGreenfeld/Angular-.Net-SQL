using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;

namespace DAL
{
    public interface IToysDAL
    {
        public List<ToysTbl> GetAll();
        public List<ToysTbl> GetToysByCodeCategory(int codeCategory);       
        public ToysTbl GetToysById(int id);
        public List<ToysTbl> AddToys(ToysTbl newtoy);
        public List<ToysTbl> UpDateToys(int id, ToysTbl UpDatetoys);
        public List<ToysTbl> DeleteToys(int id);
    }
}
