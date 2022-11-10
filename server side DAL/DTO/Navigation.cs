using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;

namespace DTO
{
    public class Navigation: AutoMapper.Profile
    {
        public Navigation()
        {
            CreateMap<CategoryTbl, CategoryDTO>();
            CreateMap<CategoryDTO, CategoryTbl>();
            CreateMap<ToysTbl, ToysDTO>();
            CreateMap<ToysDTO, ToysTbl>();
            CreateMap<UsersTbl, UsersDTO>();
            CreateMap<UsersDTO, UsersTbl>();
            CreateMap<BuyingTbl, BuyDTO>();
            CreateMap<BuyDTO, BuyingTbl>();
            CreateMap<BuydetailsTbl, BuingDetailsDTO>();
            CreateMap<BuingDetailsDTO, BuydetailsTbl>();
        }
    }
}
