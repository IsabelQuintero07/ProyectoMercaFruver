using ModelService;
using System.Collections.Generic;

namespace LogicService
{
    public interface IAdminProduct
    {
        void AddProduct(Product product);

        Product GetProduct(int code);
 
        void UpdateProduct(Product product);

        void DeleteProduct(int code);
       
        List<vw_Product> GetAllProducts();

        Product GetProductId(int id);
    }
}
