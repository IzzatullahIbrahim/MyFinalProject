using System.Collections.Generic;
using MyFinalProject.Models;
using MyFinalProject.ViewModels;

namespace MyFinalProject.Interfaces
{
    public interface ICategoriesService
    {
        void AddCategory(Category category);
        void DeleteCategory(int id);
        void EditCategory(Category category);
        List<Category> GetCategories();
        Category GetCategory(int id);
        CategoryWithUsers GetCategoryWithUsers(int id);
    }
}