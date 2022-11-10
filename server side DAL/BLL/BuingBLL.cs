using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using DTO;
using DAL;
using AutoMapper;

namespace BLL
{
    public class BuingBLL : IBuingBLL
    {
        IBuyingDAL buy;
        IMapper imapper;
        public BuingBLL(IBuyingDAL buys)
        {
            this.buy = buys;
            var con = new MapperConfiguration(co => co.AddProfile<Navigation>());
            imapper = con.CreateMapper();
        }

        public List<BuyDTO> AddBuy(BuyDTO newBuy)
        {
            BuyingTbl buys = imapper.Map<BuyDTO, BuyingTbl>(newBuy);
            List<BuyingTbl> buyser = buy.AddBuy(buys);
            return imapper.Map<List<BuyingTbl>, List<BuyDTO>>(buyser);
        }

        public List<BuyDTO> GetAll()
        {
            List<BuyingTbl> buylist = buy.GetAll();
            return imapper.Map<List<BuyingTbl>, List<BuyDTO>>(buylist);
        }

        public List<BuyDTO> DeleteBuy(int id)
        {
            List<BuyingTbl> buys = buy.DeleteBuy(id);
            return imapper.Map<List<BuyingTbl>, List<BuyDTO>>(buys);
        }

        public BuyDTO GetBuyById(int id)
        {
            BuyingTbl buys = buy.GetBuyById(id);
            return imapper.Map<BuyingTbl, BuyDTO>(buys);
        }

        public List<BuyDTO> UpDateBuy(int id, BuyDTO UpDateBuy)
        {
            BuyingTbl d = imapper.Map<BuyDTO, BuyingTbl>(UpDateBuy);
            List<BuyingTbl> buys = buy.UpDateBuy(id, d);
            return imapper.Map<List<BuyingTbl>, List<BuyDTO>>(buys);
        }
    }
}
