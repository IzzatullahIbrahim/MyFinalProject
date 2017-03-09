using System.Collections.Generic;
using MyFinalProject.Models;
using MyFinalProject.ViewModels;

namespace MyFinalProject.Interfaces
{
    public interface ICategoriesService
    {
        void AddCategory(CategoryWithUsers category);
        void EditCategory(CategoryWithUsers category);
        List<Category> GetCategories();
        CategoryWithUsers GetCategory(int id);
    }
}