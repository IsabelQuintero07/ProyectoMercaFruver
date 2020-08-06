using ModelService;
using System.Collections.Generic;

namespace LogicService
{
    public interface IAdminCategory
    {
        void AddCategory(Category c);

        Category GetCategory(int id);

        void UpdateCategory(Category category);

        void DeleteCategory(int id);

        List<Category> ListCategory();
    }
}
