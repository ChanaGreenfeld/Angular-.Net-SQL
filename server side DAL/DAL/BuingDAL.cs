using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DAL;
using DAL.Models;

namespace DAL
{
    public class BuingDAL : IBuyingDAL
    {
        Toys_dbContext buy;
        public BuingDAL(Toys_dbContext buyn)
        {
            this.buy = buyn;
        }
        public List<BuyingTbl> AddBuy(BuyingTbl newBuy)
        {
            buy.BuyingTbls.Add(newBuy);
            buy.SaveChanges();
            return buy.BuyingTbls.ToList();
        }

        public List<BuyingTbl> DeleteBuy(int id)
        {
            buy.BuyingTbls.Remove(buy.BuyingTbls.Find(id));
            buy.SaveChanges();
            return buy.BuyingTbls.ToList();
        }

        public List<BuyingTbl> GetAll()
        {
            return buy.BuyingTbls.ToList();
        }

        public BuyingTbl GetBuyById(int id)
        {
            return buy.BuyingTbls.Find(id);
        }

        public List<BuyingTbl> UpDateBuy(int id, BuyingTbl UpDateBuy)
        {
            BuyingTbl bu = buy.BuyingTbls.Find(id);
            bu.Sumbuy = UpDateBuy.Sumbuy;
            bu.Datebuy = UpDateBuy.Datebuy;
            bu.Codeuser = UpDateBuy.Codeuser;
            buy.SaveChanges();
            return buy.BuyingTbls.ToList();
        }
    }
}
