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
    [Route("api/Category")]  
    [ApiController]
    public class CategoryController : Controller
    {
        ICategoryBLL icatbll;
        public CategoryController(ICategoryBLL catbll)
        {
            this.icatbll = catbll;
        }

        /*--------------------------*/

        [HttpGet("GetAll")]
        public ActionResult GetAllCategory()
        {
            return Ok(icatbll.GetAll());
        }

        [HttpGet("GetById/{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(icatbll.GetCategoryById(id));
        }

        [HttpPost("AddnewCategory")]
        public ActionResult AddnewCategory(CategoryDTO newcat)
        {
            return Ok(icatbll.AddCategory(newcat));
        }
       
        [HttpDelete("DeleteaCategory/{id}")]
        public ActionResult DeleteaCategory(int id)
        {
            return Ok(icatbll.DeleteCategory(id));
        }

        [HttpPut("UpDateaCategory/{id}")]
        public ActionResult UpDateaCategory(int id,CategoryDTO newcat)
        {
            return Ok(icatbll.UpDateCategory(id,newcat));
        }





    }
}
