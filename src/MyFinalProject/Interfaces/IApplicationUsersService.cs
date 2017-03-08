using System.Collections.Generic;
using MyFinalProject.Models;
using MyFinalProject.ViewModels;

namespace MyFinalProject.Interfaces
{
    public interface IApplicationUsersService
    {
        UserWithCategoryAndSubCategory GetAppUser(string id);
        List<ApplicationUser> GetAppUsers();
    }
}