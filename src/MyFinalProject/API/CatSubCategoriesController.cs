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
    public class CatSubCategoriesController : Controller
    {
        private ICatSubCategoriesService _catSubCatService;

        public CatSubCategoriesController(ICatSubCategoriesService catSubCatService)
        {
            _catSubCatService = catSubCatService;
        }

        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _catSubCatService.GetCatSubCat(id);
        }
    }
}
