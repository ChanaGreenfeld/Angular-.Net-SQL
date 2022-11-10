using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;
using DTO;

namespace BLL
{
    public interface IToysBLL
    {
        public List<ToysDTO> GetAll();
        public List<ToysDTO> GetToysByCodeCategory(int codeCategory);
        public ToysDTO GetToysById(int id);
        public List<ToysDTO> AddToys(ToysDTO newtoy);
        public List<ToysDTO> UpDateToys(int id, ToysDTO UpDatetoys);
        public List<ToysDTO> DeleteToys(int id);
    }
}
