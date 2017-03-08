using MyFinalProject.Interfaces;
using MyFinalProject.Models;
using MyFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinalProject.Services
{
    public class CategoriesService : ICategoriesService
    {
        private IGenericRepository _repo;

        public CategoriesService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = (from c in _repo.Query<Category>()
                                         select new Category
                                         {
                                             Id = c.Id,
                                             CategoryName = c.CategoryName
                                         }).ToList();
            return categories;
        }

        public CategoryWithUsers GetCategory(int id)
        {
            CategoryWithUsers category = (from c in _repo.Query<Category>()
                                          where c.Id == id
                                          select new CategoryWithUsers
                                          {
                                              Id = c.Id,
                                              CategoryName = c.CategoryName,
                                              //SubCategories = c.SubCategories,
                                              ApplicationUsers = (from au in _repo.Query<UserCategory>()
                                                                  where au.CategoryId == c.Id
                                                                  select au.ApplicationUser).ToList()          
                                          }).FirstOrDefault();
            return category;
        }
    }
}
