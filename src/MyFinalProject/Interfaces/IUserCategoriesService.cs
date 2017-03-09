using System.Collections.Generic;
using MyFinalProject.Models;
using MyFinalProject.ViewModels;

namespace MyFinalProject.Interfaces
{
    public interface IUserCategoriesService
    {
        void EditUserCategories(UserWithCategories applicationUser);
        UserWithCategories GetUserCategories(string id);
    }
}