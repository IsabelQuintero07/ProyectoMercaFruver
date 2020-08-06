using ModelService;
using System.Collections.Generic;
using System.Linq;

namespace LogicService
{
    public class AdminCategory : IAdminCategory
    {
        MercaFruverSVEntities db = new MercaFruverSVEntities();

        public AdminCategory()
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
        }
        public void AddCategory(Category category)
        {
            //db.Category.Add(c);
            db.sp_category_insert(
                category.categoryName, 
                category.categoryDescription);
            db.SaveChanges();
        }

        public Category GetCategory(int id)
        {
            Category category = db.sp_category_getById(id).FirstOrDefault();
            return category;
        }

        public void UpdateCategory(Category category)
        {
            db.sp_category_update(
                category.categoryId, 
                category.categoryName, 
                category.categoryDescription);
            db.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            db.sp_category_delete(id);
            db.SaveChanges();
        }

        public List<Category> ListCategory()
        {
            var data = db.sp_category_list();
            return data.ToList();
            //return db.Category.ToList();

        }
    }
}
