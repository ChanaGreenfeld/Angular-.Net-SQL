using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;
using System.Linq;

namespace DAL
{

    public class BuingDetailsDAL:IBuingDetailsDAL
    {
        Toys_dbContext bde;
        public BuingDetailsDAL(Toys_dbContext bdet)
        {
            this.bde=bdet;
        }
        public List<BuydetailsTbl> AddBuydetails(BuydetailsTbl newBuydetails)
        {
            bde.BuydetailsTbls.Add(newBuydetails);
            bde.SaveChanges();
            return bde.BuydetailsTbls.ToList();
        }

        public List<BuydetailsTbl> DeleteBuydetails(int id)
        {
            bde.BuydetailsTbls.Remove(bde.BuydetailsTbls.Find(id));
            bde.SaveChanges();
            return bde.BuydetailsTbls.ToList();
        }

        public List<BuydetailsTbl> GetAll()
        {
            return bde.BuydetailsTbls.ToList();
        }

        public BuydetailsTbl GetBuydetailsById(int id)
        {
            return bde.BuydetailsTbls.Find(id);
        }

        public List<BuydetailsTbl> UpDateBuydetails(int id, BuydetailsTbl UpDateBuydetails)
        {
            BuydetailsTbl bd = bde.BuydetailsTbls.Find(id);
            bd.Countbuy = UpDateBuydetails.Countbuy;
            bd.Codetoy = UpDateBuydetails.Codetoy;
            bd.Codebuy = UpDateBuydetails.Codebuy;
            bde.SaveChanges();
            return bde.BuydetailsTbls.ToList();
        }
    }
}
