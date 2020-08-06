using LogicService;
using ModelService;
using System.Collections.Generic;

namespace MercaFruverWS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service.svc o Service.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service : IService
    {
        AdminCategory controlCategory = new AdminCategory();
        AdminProduct controlProduct = new AdminProduct();
        AdminPurchase controlPurchase = new AdminPurchase();
        AdminSupplier controlSupplier = new AdminSupplier();
        AdminClient controlClient = new AdminClient();
        AdminConcept controlConcept = new AdminConcept();
        AdminSale controlSale = new AdminSale();
        AdminVendor controlVendor = new AdminVendor();
        AdminDocument controlDocument = new AdminDocument();

        /// <summary>
        /// Implement category
        /// </summary>
        /// <param name="Category"></param>
        public void AddCategory(Category category)
        {
            controlCategory.AddCategory(category);
        }

        public Category GetCategory(int id)
        {
            return controlCategory.GetCategory(id);
        }

        public void UpdateCategory(Category category)
        {
            controlCategory.UpdateCategory(category);
        }

        public void DeleteCategory(int id)
        {
            controlCategory.DeleteCategory(id);
        }

        public List<Category> ListCategory()
        {
           return controlCategory.ListCategory();
        }


        /// <summary>
        /// Implement Product
        /// </summary>
        /// <param name="Product"></param>
        public void AddProduct(Product product)
        {
            controlProduct.AddProduct(product);
        }

        public Product GetProduct(int code)
        {
           return controlProduct.GetProduct(code);
        }

        public void UpdateProduct(Product product)
        {
            controlProduct.UpdateProduct(product);
        }

        public void DeleteProduct(int code)
        {
            controlProduct.DeleteProduct(code);
        }

        public List<vw_Product> GetAllProducts()
        {
            return controlProduct.GetAllProducts();
        }

        public Product GetProductId(int id)
        {
            return controlProduct.GetProductId(id);
        }


        /// <summary>
        /// Implement Purchase
        /// </summary>
        /// <param name="Purchase"></param>

        public void AddPurchase(Purchase purchase)
        {
            controlPurchase.AddPurchase(purchase);
        }

        public Purchase GetPurchase(int id)
        {
            return controlPurchase.GetPurchase(id);
        }

        public void UpdatePurchase(Purchase purchase)
        {
            controlPurchase.UpdatePurchase(purchase);
        }

        public void DeletePurchase(int id)
        {
            controlPurchase.DeletePurchase(id);
        }

        public List<vw_Purchase> GetAllPurchases()
        {
            return controlPurchase.GetAllPurchases();
        }


        /// <summary>
        /// Implement Supplier
        /// </summary>
        /// <param name="Supplier"></param>

        public void AddSupplier(Supplier supplier)
        {
            controlSupplier.AddSupplier(supplier);
        }

        public Supplier GetSupplier(int nit)
        {
            return controlSupplier.GetSupplier(nit);
        }

        public void UpdateSupplier(Supplier supplier)
        {
            controlSupplier.UpdateSupplier(supplier);
        }

        public void DeleteSupplier(int nit)
        {
            controlSupplier.DeleteSupplier(nit);
        }

        public List<vw_Supplier> GetAllSuppliers()
        {
            return controlSupplier.GetAllSuppliers();
        }


        /// <summary>
        /// Implement Client
        /// </summary>
        /// <param name="Client"></param>
        /// 
        public void AddClient(Client client)
        {
            controlClient.AddClient(client);
        }

        public Client GetClient(string documentNumber)
        {
            return controlClient.GetClient(documentNumber);
        }

        public void UpdateClient(Client client)
        {
            controlClient.UpdateClient(client);
        }

        public void DeleteClient(string documentNumber)
        {
            controlClient.DeleteClient(documentNumber);
        }

        public List<vw_Client> GetAllClients()
        {
            return controlClient.GetAllClients();
        }


        /// <summary>
        /// Implement Concept_Sale
        /// </summary>
        /// <param name="Concept_Sale"></param>

        public void AddConcept(Concept_Sale concept)
        {
            controlConcept.AddConcept(concept);
        }

        public Concept_Sale GetConcept(int id)
        {
            return controlConcept.GetConcept(id);
        }

        public void UpdateConcept(Concept_Sale concept)
        {
            controlConcept.UpdateConcept(concept);
        }

        public void DeleteConcept(int id)
        {
            controlConcept.DeleteConcept(id);
        }

        public List<vw_Concept> GetAllConcepts()
        {
            return controlConcept.GetAllConcepts();
        }


        /// <summary>
        /// Implement Sale
        /// </summary>
        /// <param name="Sale"></param>

        public void AddSale(Sale sale)
        {
            controlSale.AddSale(sale);
        }

        public Sale GetSale(int id)
        {
            return controlSale.GetSale(id);
        }

        public void UpdateSale(Sale sale)
        {
            controlSale.UpdateSale(sale);
        }

        public void DeleteSale(int id)
        {
            controlSale.DeleteSale(id);
        }

        public List<vw_Sale> GetAllSales()
        {
            return controlSale.GetAllSales();
        }

        public Sale GetLastSale()
        {
            return controlSale.GetLastSale();
        }


        /// <summary>
        /// Implement Vendor
        /// </summary>
        /// <param name="Vendor"></param>

        public void AddVendor(Vendor vendor)
        {
            controlVendor.AddVendor(vendor);
        }

        public Vendor GetVendor(string documentNumber)
        {
            return controlVendor.GetVendor(documentNumber);
        }

        public void UpdateVendor(Vendor vendor)
        {
            controlVendor.UpdateVendor(vendor);
        }

        public void DeleteVendor(string documentNumber)
        {
            controlVendor.DeleteVendor(documentNumber);
        }

        public List<vw_Vendor> GetAllVendors()
        {
            return controlVendor.GetAllVendors();
        }


        /// <summary>
        /// Implement Document
        /// </summary>
        /// <param name="Document"></param>
        /// 

        public List<Document_Type> GetAllDocuments()
        {
            return controlDocument.GetAllDocuments();
        }

    }
}
