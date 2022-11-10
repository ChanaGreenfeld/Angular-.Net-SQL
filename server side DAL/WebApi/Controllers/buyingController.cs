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
    [Route("api/buying")]
    [ApiController]
    public class buyingController : Controller
    {
        IBuingBLL buybll;
        public buyingController(IBuingBLL buyblls)
        {
            this.buybll = buyblls;
        }

        /*------------------------*/
        [HttpGet("GetAllbuy")]
        public ActionResult GetAllbuy()
        {
            return Ok(buybll.GetAll());
        }

        [HttpGet("Getbuybyid/{id}")]
        public ActionResult Getbuybyid(int id)
        {
            return Ok(buybll.GetBuyById(id));
        }

        [HttpDelete("Deletebuy/{id}")]
        public ActionResult Deletebuy(int id)
        {
            return Ok(buybll.DeleteBuy(id));
        }

        [HttpPut("UpDatebuy/{id}")]
        public ActionResult UpDatebuy(int id, BuyDTO edit)
        {
            return Ok(buybll.UpDateBuy(id, edit));
        }

        [HttpPost("Addnewbuy")]
        public ActionResult Addnewbuy(BuyDTO newuse)
        {
            return Ok(buybll.AddBuy(newuse));
        }




    }
}
