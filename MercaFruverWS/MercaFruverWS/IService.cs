using ModelService;
using System.Collections.Generic;
using System.ServiceModel;

namespace MercaFruverWS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService
    {
        /// <summary>
        /// Implement category
        /// </summary>
        /// <param name="Category"></param>

        [OperationContract]
        void AddCategory(Category category);

        [OperationContract]
        Category GetCategory(int id);

        [OperationContract]
        void UpdateCategory(Category category);

        [OperationContract]
        void DeleteCategory(int id);

        [OperationContract]
        List<Category> ListCategory();


        /// <summary>
        /// Implement category
        /// </summary>
        /// <param name="Product"></param>

        [OperationContract]
        void AddProduct(Product product);

        [OperationContract]
        Product GetProduct(int code);

        [OperationContract]
        void UpdateProduct(Product product);
     
        [OperationContract]
        void DeleteProduct(int code);

        [OperationContract]
        List<vw_Product> GetAllProducts();

        [OperationContract]
        Product GetProductId(int id);


        /// <summary>
        /// Implement Purchase
        /// </summary>
        /// <param name="Purchase"></param>
        /// 

        [OperationContract]
        void AddPurchase(Purchase purchase);

        [OperationContract]
        Purchase GetPurchase(int id);

        [OperationContract]
        void UpdatePurchase(Purchase purchase);

        [OperationContract]
        void DeletePurchase(int id);

        [OperationContract]
        List<vw_Purchase> GetAllPurchases();


        /// <summary>
        /// Implement Supplier
        /// </summary>
        /// <param name="Supplier"></param>
        /// 

        [OperationContract]
        void AddSupplier(Supplier supplier);

        [OperationContract]
        Supplier GetSupplier(int nit);

        [OperationContract]
        void UpdateSupplier(Supplier supplier);

        [OperationContract]
        void DeleteSupplier(int nit);

        [OperationContract]
        List<vw_Supplier> GetAllSuppliers();


        /// <summary>
        /// Implement Client
        /// </summary>
        /// <param name="Client"></param>
        /// 

        [OperationContract]
        void AddClient(Client client);

        [OperationContract]
        Client GetClient(string documentNumber);

        [OperationContract]
        void UpdateClient(Client client);

        [OperationContract]
        void DeleteClient(string documentNumber);

        [OperationContract]
        List<vw_Client> GetAllClients();


        /// <summary>
        /// Implement Concept_Sale
        /// </summary>
        /// <param name="Concept_Sale"></param>

        [OperationContract]
        void AddConcept(Concept_Sale concept);

        [OperationContract]
        Concept_Sale GetConcept(int id);

        [OperationContract]
        void UpdateConcept(Concept_Sale concept);

        [OperationContract]
        void DeleteConcept(int id);

        [OperationContract]
        List<vw_Concept> GetAllConcepts();


        /// <summary>
        /// Implement Sale
        /// </summary>
        /// <param name="Sale"></param>

        [OperationContract]
        void AddSale(Sale sale);

        [OperationContract]
        Sale GetSale(int id);

        [OperationContract]
        void UpdateSale(Sale sale);

        [OperationContract]
        void DeleteSale(int id);

        [OperationContract]
        List<vw_Sale> GetAllSales();

        [OperationContract]
        Sale GetLastSale();


        /// <summary>
        /// Implement Vendor
        /// </summary>
        /// <param name="Vendor"></param>

        [OperationContract]
        void AddVendor(Vendor vendor);

        [OperationContract]
        Vendor GetVendor(string documentNumber);

        [OperationContract]
        void UpdateVendor(Vendor vendor);

        [OperationContract]
        void DeleteVendor(string documentNumber);

        [OperationContract]
        List<vw_Vendor> GetAllVendors();


        /// <summary>
        /// Implement Document
        /// </summary>
        /// <param name="Document"></param>
        /// 

        [OperationContract]
        List<Document_Type> GetAllDocuments();
    }
}
