using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;
using DTO;
using AutoMapper;

namespace BLL
{
    public class ToysBLL : IToysBLL
    {
        IToysDAL toydal;
        IMapper imapper;
        public ToysBLL(IToysDAL toydals)
        {
            this.toydal = toydals;
            var toy = new MapperConfiguration(to => to.AddProfile<Navigation>());
            imapper = toy.CreateMapper();
        }
        


        public List<ToysDTO> AddToys(ToysDTO newtoy)
        {
            ToysTbl toy = imapper.Map<ToysDTO, ToysTbl>(newtoy);
            List<ToysTbl> toys = toydal.AddToys(toy);
            return imapper.Map<List<ToysTbl>,List<ToysDTO>>(toys);
        }

        public List<ToysDTO> DeleteToys(int id)
        {
            List<ToysTbl> toy = toydal.DeleteToys(id);
            return imapper.Map<List<ToysTbl>, List<ToysDTO>>(toy);
        }

        public List<ToysDTO> GetAll()
        {
            List<ToysTbl> toy = toydal.GetAll();
            return imapper.Map<List<ToysTbl>, List<ToysDTO>>(toy);
          
        }

        public List<ToysDTO> GetToysByCodeCategory(int codeCategory)
        {
            List<ToysTbl> toy = toydal.GetToysByCodeCategory(codeCategory);
            return imapper.Map<List<ToysTbl>, List<ToysDTO>>(toy);
        }

        public ToysDTO GetToysById(int id)
        {
            ToysTbl toy = toydal.GetToysById(id);
            return imapper.Map<ToysTbl, ToysDTO>(toy);
        }

        public List<ToysDTO> UpDateToys(int id, ToysDTO UpDatetoys)
        {
            ToysTbl toy =imapper.Map<ToysDTO, ToysTbl>(UpDatetoys);
            List<ToysTbl> toys = toydal.UpDateToys(id, toy);
            return imapper.Map<List<ToysTbl>, List<ToysDTO>>(toys);    
        }
    }
}
