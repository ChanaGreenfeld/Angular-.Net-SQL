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
    [Route("api/toys")]
    [ApiController]
    public class toysController : Controller
    {
        IToysBLL toybll;
        public toysController(IToysBLL toyblls)
        {
            this.toybll = toyblls;
        }

        /*------------------------*/
        [HttpGet("GetAlltoy")]
        public ActionResult GetAlltoy()
        {
            return Ok(toybll.GetAll());
        }

        [HttpGet("Gettoycat/{code}")]
        public ActionResult Gettoycat(int code)
        {
            return Ok(toybll.GetToysByCodeCategory(code));
        }

        [HttpGet("Gettoyid/{id}")]
        public ActionResult Gettoyid(int id)
        {
            return Ok(toybll.GetToysById(id));
        }

        [HttpDelete("Deletetoy/{id}")]
        public ActionResult Deletetoy(int id)
        {
            return Ok(toybll.DeleteToys(id));
        }

        [HttpPut("UpDateatoy/{id}")]
        public ActionResult UpDateatoy(int id, ToysDTO edit)
        {
            return Ok(toybll.UpDateToys(id, edit));
        }

        [HttpPost("Addnewtoy")]
        public ActionResult Addnewtoy(ToysDTO newcat)
        {
            return Ok(toybll.AddToys(newcat));
        }



    }
}
