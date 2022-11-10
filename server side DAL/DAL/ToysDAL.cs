using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;
using System.Linq;

namespace DAL
{
    public class ToysDAL : IToysDAL
    {
        Toys_dbContext toy;

        public ToysDAL(Toys_dbContext toys)
        {
            this.toy = toys;
        }

        public List<ToysTbl> AddToys(ToysTbl newtoy)
        {
            toy.ToysTbls.Add(newtoy);
            toy.SaveChanges();
            return toy.ToysTbls.ToList();
        }

        public List<ToysTbl> DeleteToys(int id)
        {
            toy.ToysTbls.Remove(toy.ToysTbls.Find(id));
            toy.SaveChanges();
            return toy.ToysTbls.ToList();
        }

        public List<ToysTbl> GetAll()
        {
            return toy.ToysTbls.ToList();
        }

        public List<ToysTbl> GetToysByCodeCategory(int codeCategory)
        {
            return toy.ToysTbls.ToList().FindAll(p => p.Codecategory == codeCategory);
        }

        public ToysTbl GetToysById(int id)
        {
            return toy.ToysTbls.Find(id);
        }

        public List<ToysTbl> UpDateToys(int id, ToysTbl UpDatetoys)
        {
            ToysTbl to = toy.ToysTbls.Find(id);
            to.Nametoy = UpDatetoys.Nametoy;
            to.Picture = UpDatetoys.Picture;
            to.Describetoy = UpDatetoys.Describetoy;
            to.Codecategory = UpDatetoys.Codecategory;
            to.Price = UpDatetoys.Price;
            toy.SaveChanges();
            return toy.ToysTbls.ToList();
        }
    }
}
