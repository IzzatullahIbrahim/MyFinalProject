using Microsoft.EntityFrameworkCore;
using MyFinalProject.Data;
using MyFinalProject.Interfaces;
using MyFinalProject.Models;
using MyFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinalProject.Services
{
    public class UserCategoriesService : IUserCategoriesService
    {
        private IGenericRepository _repo;
        private ApplicationDbContext _db;

        public UserCategoriesService(IGenericRepository repo, ApplicationDbContext db)
        {
            _repo = repo;
            _db = db;
        }

        public UserWithCategories GetUserCategories(string id)
        {
            UserWithCategories appUser = (from au in _repo.Query<ApplicationUser>()
                                                      where au.Id == id
                                                      select new UserWithCategories
                                                      {
                                                          Id = au.Id,
                                                          FirstName = au.FirstName,
                                                          LastName = au.LastName,
                                                          Categories = (from uc in _repo.Query<UserCategory>()
                                                                        where uc.ApplicationUserId == au.Id
                                                                        select uc.Category).ToList(),
                                                      }).FirstOrDefault();
            return appUser;
        }

        public void EditUserCategories(UserWithCategories applicationUser)
        {
            foreach (Category category in applicationUser.Categories)
            {
                _db.UserCategories.Add(new UserCategory { ApplicationUserId = applicationUser.Id, CategoryId = category.Id });
            }
            _db.SaveChanges();
        }
    }
}
