﻿using MyFinalProject.Data;
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
        private ApplicationDbContext _db;

        public CategoriesService(IGenericRepository repo, ApplicationDbContext db)
        {
            _repo = repo;
            _db = db;
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
                                              ApplicationUsers = (from au in _repo.Query<UserCategory>()
                                                                  where au.CategoryId == c.Id
                                                                  select au.ApplicationUser).ToList()          
                                          }).FirstOrDefault();
            return category;
        }

        public void AddCategory(CategoryWithUsers category)
        {
            _repo.Add(new Category { CategoryName = category.CategoryName });
        }

        public void EditCategory(CategoryWithUsers category)
        {
            foreach(ApplicationUser applicationUser in category.ApplicationUsers)
            {
                _db.UserCategories.Add(new UserCategory { CategoryId = category.Id, ApplicationUserId = applicationUser.Id });
            }
            _db.SaveChanges();
        }
    }
}
