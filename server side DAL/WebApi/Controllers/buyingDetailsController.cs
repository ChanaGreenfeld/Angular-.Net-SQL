using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL;
using BLL;
using DTO;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/buyingDetails")]
    [ApiController]
    public class buyingDetailsController : Controller
    {
        IBuingDetailsBLL buydetbll;
        public buyingDetailsController(IBuingDetailsBLL buydetblls)
        {
            this.buydetbll = buydetblls;
        }

  
        /*----------------------------*/
        [HttpGet("GetAllbuydet")]
        public ActionResult GetAllbuydet()
        {
            return Ok(buydetbll.GetAll());
        }

        [HttpGet("Getbuybydetid/{id}")]
        public ActionResult Getbuybydetid(int id)
        {
            return Ok(buydetbll.GetBuydetailsById(id));
        }

        [HttpDelete("Deletebdbuy/{id}")]
        public ActionResult Deletebdbuy(int id)
        {
            return Ok(buydetbll.DeleteBuydetails(id));
        }

        [HttpPut("UpDatebuydet/{id}")]
        public ActionResult UpDatebuydet(int id, BuingDetailsDTO edit)
        {
            return Ok(buydetbll.UpDateBuydetails(id, edit));
        }

        [HttpPost("Addnewbuydet")]
        public ActionResult Addnewbuydet(BuingDetailsDTO newuse)
        {
            return Ok(buydetbll.AddBuydetails(newuse));
        }


    }
}
