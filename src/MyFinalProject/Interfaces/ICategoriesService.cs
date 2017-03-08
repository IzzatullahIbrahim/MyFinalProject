using System.Collections.Generic;
using MyFinalProject.Models;
using MyFinalProject.ViewModels;

namespace MyFinalProject.Interfaces
{
    public interface ICategoriesService
    {
        List<Category> GetCategories();
        CategoryWithUsers GetCategory(int id);
    }
}