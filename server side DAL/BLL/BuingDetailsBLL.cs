using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;
using DTO;
using AutoMapper;

namespace BLL
{
    public class BuingDetailsBLL : IBuingDetailsBLL
    {
        IBuingDetailsDAL buydet;
        IMapper imapper;
        public BuingDetailsBLL(IBuingDetailsDAL buydets)
        {
            this.buydet = buydets;
            var con = new MapperConfiguration(co => co.AddProfile<Navigation>());
            imapper = con.CreateMapper();
        }

        public List<BuingDetailsDTO> AddBuydetails(BuingDetailsDTO newBuydetails)
        {
            BuydetailsTbl bd = imapper.Map<BuingDetailsDTO, BuydetailsTbl>(newBuydetails);
            List<BuydetailsTbl> bds = buydet.AddBuydetails(bd);
            return imapper.Map<List<BuydetailsTbl>, List<BuingDetailsDTO>>(bds); ;
        }

        public List<BuingDetailsDTO> DeleteBuydetails(int id)
        {
            List<BuydetailsTbl> bd = buydet.DeleteBuydetails(id);
            return imapper.Map<List<BuydetailsTbl>, List<BuingDetailsDTO>>(bd);
        }

        public List<BuingDetailsDTO> GetAll()
        {
            List<BuydetailsTbl> bd = buydet.GetAll();
            return imapper.Map<List<BuydetailsTbl>, List<BuingDetailsDTO>>(bd);
        }

        public BuingDetailsDTO GetBuydetailsById(int id)
        {
            BuydetailsTbl bd = buydet.GetBuydetailsById(id);
            return imapper.Map<BuydetailsTbl, BuingDetailsDTO>(bd);
        }

        public List<BuingDetailsDTO> UpDateBuydetails(int id, BuingDetailsDTO UpDateBuydetails)
        {
            BuydetailsTbl d = imapper.Map<BuingDetailsDTO, BuydetailsTbl>(UpDateBuydetails);
            List<BuydetailsTbl> use = buydet.UpDateBuydetails(id, d);
            return imapper.Map<List<BuydetailsTbl>, List<BuingDetailsDTO>>(use);
        }
    }
}
