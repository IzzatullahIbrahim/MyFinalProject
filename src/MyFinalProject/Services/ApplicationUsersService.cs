using Microsoft.EntityFrameworkCore;
using MyFinalProject.Interfaces;
using MyFinalProject.Models;
using MyFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinalProject.Services
{
    public class ApplicationUsersService : IApplicationUsersService
    {
        private IGenericRepository _repo;

        public ApplicationUsersService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public List<ApplicationUser> GetAppUsers()
        {
            List<ApplicationUser> appUsers = (from au in _repo.Query<ApplicationUser>()
                                              select new ApplicationUser
                                              {
                                                  Id = au.Id,
                                                  FirstName = au.FirstName,
                                                  LastName = au.LastName
                                              }).ToList();
            return appUsers;
        }

        //public List<UserWithCategoryAndSubCategory> GetAppUsers()
        //{
        //    List<UserWithCategoryAndSubCategory> appUsers = (from au in _repo.Query<ApplicationUser>()
        //                                                    select new UserWithCategoryAndSubCategory
        //                                                    {
        //                                                        Id = au.Id,
        //                                                        FirstName = au.FirstName,
        //                                                        LastName = au.LastName,
        //                                                        Categories = (from uc in _repo.Query<UserCategory>()
        //                                                                      where uc.ApplicationUserId == au.Id
        //                                                                      select uc.Category).ToList(),
        //                                                        SubCategories = (from us in _repo.Query<UserSubCategory>()
        //                                                                         where us.ApplicationUserId == au.Id
        //                                                                         select us.SubCategory).ToList()
        //                                                    }).ToList();
        //    return appUsers;
        //}

        public UserWithCategoryAndSubCategory GetAppUser(string id)
        {
            UserWithCategoryAndSubCategory appUser = (from au in _repo.Query<ApplicationUser>()
                                                      where au.Id == id
                                                      select new UserWithCategoryAndSubCategory
                                                      {
                                                          Id = au.Id,
                                                          FirstName = au.FirstName,
                                                          LastName = au.LastName,
                                                          Categories = (from uc in _repo.Query<UserCategory>()
                                                                        where uc.ApplicationUserId == au.Id
                                                                        select uc.Category).ToList(),
                                                          SubCategories = (from us in _repo.Query<UserSubCategory>()
                                                                           where us.ApplicationUserId == au.Id
                                                                           select us.SubCategory).ToList()
                                                      }).FirstOrDefault();
            return appUser;
        }
    }
}
