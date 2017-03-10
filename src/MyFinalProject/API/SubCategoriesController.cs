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
    public class SubCategoriesController : Controller
    {
        private ISubCategoriesService _subCatService;

        public SubCategoriesController(ISubCategoriesService subCatService)
        {
            _subCatService = subCatService;
        }

        [HttpGet]
        public List<SubCategory> Get()
        {
            return _subCatService.GetSubCategories();
        }

        [HttpGet("{id}")]
        public SubCategoryWithUsers Get(int id)
        {
            return _subCatService.GetSubCategoryWithUsers(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] SubCategory subCategory)
        {
            if (subCategory == null)
            {
                return BadRequest();
            }
            else if(subCategory.Id == 0)
            {
                _subCatService.AddSubCategory(subCategory);
                return Ok();
            }
            else
            {
                _subCatService.EditSubCategory(subCategory);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _subCatService.DeleteSubCategory(id);
            return Ok();
        }

    }
}
