using MyFinalProject.Interfaces;
using MyFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinalProject.Services
{
    public class ApplicationUsersService : IApplicationUsersService
    {
        private IGenericRepository _repo;

        public ApplicationUsersService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public List<ApplicationUser> GetAppUsers()
        {
            List<ApplicationUser> appUsers = (from au in _repo.Query<ApplicationUser>()
                                              select new ApplicationUser
                                              {
                                                  Id = au.Id,
                                                  FirstName = au.FirstName,
                                                  LastName = au.LastName
                                              }).ToList();
            return appUsers;
        }
    }
}
