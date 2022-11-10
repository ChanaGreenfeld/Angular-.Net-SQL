using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;
using DTO;

namespace BLL
{
    public interface IBuingDetailsBLL
    {
        public List<BuingDetailsDTO> GetAll();
        public BuingDetailsDTO GetBuydetailsById(int id);
        public List<BuingDetailsDTO> AddBuydetails(BuingDetailsDTO newBuydetails);
        public List<BuingDetailsDTO> UpDateBuydetails(int id, BuingDetailsDTO UpDateBuydetails);
        public List<BuingDetailsDTO> DeleteBuydetails(int id);
    }
}
