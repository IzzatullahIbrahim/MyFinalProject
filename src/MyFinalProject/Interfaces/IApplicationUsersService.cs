using System.Collections.Generic;
using MyFinalProject.Models;
using MyFinalProject.ViewModels;

namespace MyFinalProject.Interfaces
{
    public interface IApplicationUsersService
    {
        void EditUser(ApplicationUser user);
        UserWithCategoryAndSubCategory GetAppUser(string id);
        List<UserWithCategoryAndSubCategory> GetAppUsers();
    }
}