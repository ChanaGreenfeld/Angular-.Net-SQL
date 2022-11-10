using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using DTO;
using DAL;


namespace BLL
{
    public interface IBuingBLL
    {
        public List<BuyDTO> GetAll();
        public BuyDTO GetBuyById(int id);
        public List<BuyDTO> AddBuy(BuyDTO newBuy);
        public List<BuyDTO> UpDateBuy(int id, BuyDTO UpDateBuy);
        public List<BuyDTO> DeleteBuy(int id);
    }
}
