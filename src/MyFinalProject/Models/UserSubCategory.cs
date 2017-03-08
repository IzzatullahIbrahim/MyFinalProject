using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinalProject.Models
{
    public class UserSubCategory
    {
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }

        public SubCategory SubCategory { get; set; }
        public int SubCategoryId { get; set; }
    }
}
