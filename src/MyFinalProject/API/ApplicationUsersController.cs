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
    public class ApplicationUsersController : Controller
    {
        private IApplicationUsersService _auService;

        public ApplicationUsersController(IApplicationUsersService auService)
        {
            _auService = auService;
        }

        [HttpGet]
        public List<UserWithCategoryAndSubCategory> Get()
        {
            return _auService.GetAppUsers();
        }

        [HttpGet("{id}")]
        public UserWithCategoryAndSubCategory Get(string id)
        {
            return _auService.GetAppUser(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ApplicationUser user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            else if (user.Id == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }
    }
}
