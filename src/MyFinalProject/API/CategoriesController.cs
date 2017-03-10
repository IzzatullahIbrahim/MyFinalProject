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
    public class CategoriesController : Controller
    {
        private ICategoriesService _catService;

        public CategoriesController(ICategoriesService catService)
        {
            _catService = catService;
        }

        [HttpGet]
        public List<Category> Get()
        {
            return _catService.GetCategories();
        }

        [HttpGet("{id}")]
        public CategoryWithUsers Get(int id)
        {
            return _catService.GetCategoryWithUsers(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            else if ( category.Id == 0)
            {
                _catService.AddCategory(category);
                return Ok();
            }
            else
            {
                _catService.EditCategory(category);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _catService.DeleteCategory(id);
            return Ok();
        }
    }
}
