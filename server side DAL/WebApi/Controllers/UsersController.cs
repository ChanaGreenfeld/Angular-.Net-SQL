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
    [Route("api/Users")]
    [ApiController]
    public class UsersController : Controller
    {

        IUsersBLL usebll;
        public UsersController(IUsersBLL useblls)
        {
            this.usebll = useblls;
        }

     
        /*------------------------*/
        [HttpGet("GetAlluser")]
        public ActionResult GetAlluser()
        {
            return Ok(usebll.GetAll());
        }

        [HttpGet("Gettuser/{id}")]
        public ActionResult Gettuser(int id)
        {
            return Ok(usebll.GetUserById(id));
        }
        [HttpGet("Gettuserpass/{password}")]
        public ActionResult Gettuserpass(string password)
        {
            return Ok(usebll.GetUserByPassword(password));
        }

        [HttpDelete("Deleteuser/{id}")]
        public ActionResult Deleteuser(int id)
        {
            return Ok(usebll.DeleteUser(id));
        }

        [HttpPut("UpDateuser/{id}")]
        public ActionResult UpDateuser(int id, UsersDTO edit)
        {
            return Ok(usebll.UpDateUser(id, edit));
        }

        [HttpPost("Addnewuser")]
        public ActionResult Addnewuser(UsersDTO newuse)
        {
            return Ok(usebll.AddUser(newuse));
        }




    }
}
