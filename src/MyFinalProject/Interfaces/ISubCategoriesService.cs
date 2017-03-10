using System.Collections.Generic;
using MyFinalProject.Models;
using MyFinalProject.ViewModels;

namespace MyFinalProject.Interfaces
{
    public interface ISubCategoriesService
    {
        void AddSubCategory(SubCategory subCategory);
        void DeleteSubCategory(int id);
        void EditSubCategory(SubCategory subCategory);
        List<SubCategory> GetSubCategories();
        SubCategory GetSubCategory(int id);
        SubCategoryWithUsers GetSubCategoryWithUsers(int id);
    }
}