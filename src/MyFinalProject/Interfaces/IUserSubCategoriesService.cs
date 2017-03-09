using MyFinalProject.ViewModels;

namespace MyFinalProject.Interfaces
{
    public interface IUserSubCategoriesService
    {
        void EditUserSubCategories(UserWithSubCategories applicationUser);
        UserWithSubCategories GetUserSubCategories(string id);
    }
}