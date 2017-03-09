using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFinalProject.Interfaces;
using MyFinalProject.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFinalProject.API
{
    [Route("api/[controller]")]
    public class ApplicationUsersController : Controller
    {
        private IApplicationUsersService _auService;

        public ApplicationUsersController (IApplicationUsersService auService)
        {
            _auService = auService;
        }

        [HttpGet]
        public List<ApplicationUser> Get()
        {
            return _auService.GetAppUsers();
        }
    }
}
