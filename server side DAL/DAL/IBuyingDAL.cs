using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;

namespace DAL
{
    public interface IBuyingDAL
    {
        public List<BuyingTbl> GetAll();
        public BuyingTbl GetBuyById(int id);
        public List<BuyingTbl> AddBuy(BuyingTbl newBuy);
        public List<BuyingTbl> UpDateBuy(int id, BuyingTbl UpDateBuy);
        public List<BuyingTbl> DeleteBuy(int id);
    }
}
