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
        private ICategoriesService _catService;

        public SubCategoriesService(IGenericRepository repo, ICategoriesService catService)
        {
            _repo = repo;
            _catService = catService;
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

        public SubCategory GetSubCategory(int id)
        {
            SubCategory subCategory = (from sc in _repo.Query<SubCategory>()
                                       where sc.Id == id
                                       select sc).FirstOrDefault();
            return subCategory;
        }

        public SubCategoryWithUsers GetSubCategoryWithUsers(int id)
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

        public void AddSubCategory(SubCategory subCategory)
        {
            Category category = _catService.GetCategory(subCategory.Category.Id);
            subCategory.Category = category;

            _repo.Add(subCategory);
        }

        public void EditSubCategory(SubCategory subCategory)
        {
            Category category = _catService.GetCategory(subCategory.Category.Id);
            subCategory.Category = category;

            _repo.Update(subCategory);
        }

        public void DeleteSubCategory(int id)
        {
            SubCategory subCategory = GetSubCategory(id);
            _repo.Delete(subCategory);
        }
    }
}
