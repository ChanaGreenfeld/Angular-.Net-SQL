using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;

namespace DAL
{
    public interface IBuingDetailsDAL
    {
        public List<BuydetailsTbl> GetAll();
        public BuydetailsTbl GetBuydetailsById(int id);
        public List<BuydetailsTbl> AddBuydetails(BuydetailsTbl newBuydetails);
        public List<BuydetailsTbl> UpDateBuydetails(int id, BuydetailsTbl UpDateBuydetails);
        public List<BuydetailsTbl> DeleteBuydetails(int id);
    }
}
