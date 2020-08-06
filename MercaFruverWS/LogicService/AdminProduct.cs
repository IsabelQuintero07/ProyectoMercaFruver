using ModelService;
using System.Collections.Generic;
using System.Linq;

namespace LogicService
{
    public class AdminProduct : IAdminProduct
    {
        MercaFruverSVEntities db = new MercaFruverSVEntities();

        public AdminProduct()
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
        }
        public void AddProduct(Product product)
        {
            db.sp_product_insert(product.productCategoryId, product.productCode, product.productName,
                product.productSellingPrice, product.productStock, product.productCost);
            db.SaveChanges();
        }

        public Product GetProduct(int code)
        {
            Product product = db.sp_product_getByCode(code).FirstOrDefault();
            return product;
        }

        public void UpdateProduct(Product product)
        {
            db.sp_product_update(
                product.productCategoryId, 
                product.productCode, 
                product.productName, 
                product.productSellingPrice, 
                product.productStock, 
                product.productCost);
            db.SaveChanges();
        }

        public void DeleteProduct(int code)
        {
            db.sp_product_deleteSoft(code);
            db.SaveChanges();
        }

         public List<vw_Product> GetAllProducts()
         {
            var data = db.sp_product_getList();
            return data.ToList();
         }

        public Product GetProductId(int id)
        {
            Product product = db.sp_product_getById(id).FirstOrDefault();
            return product;
        }
    }
}
