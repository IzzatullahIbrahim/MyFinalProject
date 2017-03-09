using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFinalProject.Interfaces;
using MyFinalProject.Models;
using MyFinalProject.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFinalProject.API
{
    [Route("api/[controller]")]
    public class UserCategoriesController : Controller
    {
        private IUserCategoriesService _ucService;

        public UserCategoriesController(IUserCategoriesService ucService)
        {
            _ucService = ucService;
        }

        [HttpGet("{id}")]
        public UserWithCategories Get(string id)
        {
            return _ucService.GetUserCategories(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserWithCategories applicationUser)
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
                _ucService.EditUserCategories(applicationUser);
                return Ok();
            }
        }
    }
}
