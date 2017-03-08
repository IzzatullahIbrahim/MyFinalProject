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

        //public List<UserWithCategoryAndSubCategory> GetAppUsers()
        //{
        //    List<UserWithCategoryAndSubCategory> users = (from u in _repo.Query<ApplicationUser>()
        //                                                  select new UserWithCategoryAndSubCategory
        //                                                  {
        //                                                      FirstName = u.FirstName
        //                                                  }).ToList();

        //    foreach(var user in users)
        //    {
        //        List<Category> cats = (from uc in _repo.Query<UserCategory>()
        //         where uc.ApplicationUserId == user.Id
        //         select new Category
        //         {
        //             CategoryName = uc.Category.CategoryName
        //         }).ToList();

        //        user.Categories = cats;
        //    }

        //    return users;
        //}

        //public List<ApplicationUser> ListUser()
        //{
        //    List<ApplicationUser> user = (from u in _repo.Query<ApplicationUser>()
        //                                    select new ApplicationUser
        //                                    {
        //                                        Id = u.Id,
        //                                        FirstName = u.FirstName,
        //                                        LastName = u.LastName,

        //                                    }).ToList();
        //    return user;
        //} 

        public List<UserWithCategoryAndSubCategory> GetAppUsers()
        {
            List<UserWithCategoryAndSubCategory> appUser = (from au in _repo.Query<ApplicationUser>()
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
                                                            }).ToList();
            return appUser;
        }

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

        public Category ListCat(int id)
        {
            Category cats = (from c in _repo.Query<Category>()
                             where c.Id == id
                             select new Category
                             {
                                 Id = c.Id,
                                 CategoryName = c.CategoryName
                             }).FirstOrDefault();
            return cats;
        }

        //public List<UserWithCategoryAndSubCategory> Getto()
        //{
        //    var userCat = ListUser();
        //}

        public void EditUser(ApplicationUser user)
        {
            _repo.Update(user);
        }
    }
}
