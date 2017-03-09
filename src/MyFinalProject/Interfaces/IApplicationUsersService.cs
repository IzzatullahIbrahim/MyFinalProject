using System.Collections.Generic;
using MyFinalProject.Models;

namespace MyFinalProject.Interfaces
{
    public interface IApplicationUsersService
    {
        List<ApplicationUser> GetAppUsers();
    }
}