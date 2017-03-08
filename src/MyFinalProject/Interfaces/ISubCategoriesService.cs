using System.Collections.Generic;
using MyFinalProject.Models;
using MyFinalProject.ViewModels;

namespace MyFinalProject.Interfaces
{
    public interface ISubCategoriesService
    {
        List<SubCategory> GetSubCategories();
        SubCategoryWithUsers GetSubCategory(int id);
    }
}