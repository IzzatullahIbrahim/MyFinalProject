using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFinalProject.Interfaces;
using MyFinalProject.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFinalProject.API
{
    [Route("api/[controller]")]
    public class UserSubCategoriesController : Controller
    {
        private IUserSubCategoriesService _uscService;

        public UserSubCategoriesController(IUserSubCategoriesService uscService)
        {
            _uscService = uscService;
        }

        [HttpGet("{id}")]
        public UserWithSubCategories Get(string id)
        {
            return _uscService.GetUserSubCategories(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserWithSubCategories applicationUser)
        {
            if (applicationUser == null)
            {
                return BadRequest();
            }
            else if (applicationUser.Id == null)
            {
                return BadRequest();
            }
            else
            {
                _uscService.EditUserSubCategories(applicationUser);
                return Ok();
            }
        }
    }
}
