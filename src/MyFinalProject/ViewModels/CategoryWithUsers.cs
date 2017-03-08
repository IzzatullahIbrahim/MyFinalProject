using MyFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinalProject.ViewModels
{
    public class CategoryWithUsers
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public List<SubCategory> SubCategories { get; set; }

        public List<ApplicationUser> ApplicationUsers { get; set; }
    }
}
