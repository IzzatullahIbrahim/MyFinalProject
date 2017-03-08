using MyFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinalProject.ViewModels
{
    public class UserWithCategoryAndSubCategory
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Category> Categories { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
