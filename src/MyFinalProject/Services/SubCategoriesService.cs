using MyFinalProject.Interfaces;
using MyFinalProject.Models;
using MyFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinalProject.Services
{
    public class SubCategoriesService : ISubCategoriesService
    {
        private IGenericRepository _repo;

        public SubCategoriesService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public List<SubCategory> GetSubCategories()
        {
            List<SubCategory> subCategories = (from sc in _repo.Query<SubCategory>()
                                               select new SubCategory
                                               {
                                                   Id = sc.Id,
                                                   SubCategoryName = sc.SubCategoryName
                                               }).ToList();
            return subCategories;
        }

        public SubCategoryWithUsers GetSubCategory(int id)
        {
            SubCategoryWithUsers subCategory = (from sc in _repo.Query<SubCategory>()
                                                where sc.Id == id
                                                select new SubCategoryWithUsers
                                                {
                                                    Id = sc.Id,
                                                    SubCategoryName = sc.SubCategoryName,
                                                    ApplicationUsers = (from au in _repo.Query<UserSubCategory>()
                                                                        where au.SubCategoryId == sc.Id
                                                                        select au.ApplicationUser).ToList()
                                                }).FirstOrDefault();
            return subCategory;
        }
    }
}
