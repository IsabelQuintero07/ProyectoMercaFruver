using ModelService;
using System.Collections.Generic;
using System.Linq;

namespace LogicService
{
    public class AdminSupplier : IAdminSupplier
    {
        MercaFruverSVEntities db = new MercaFruverSVEntities();

        public AdminSupplier()
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
        }

        public void AddSupplier(Supplier supplier)
        {
            db.sp_supplier_insert(
                supplier.supplierNit,
                supplier.supplierName, 
                supplier.supplierAddress,
                supplier.supplierPhoneNumber,
                supplier.supplierCity,
                supplier.supplierWebpage);
            db.SaveChanges();
        }

        public void DeleteSupplier(int nit)
        {
            db.sp_supplier_deleteSoft(nit);
            db.SaveChanges();
        }

        public List<vw_Supplier> GetAllSuppliers()
        {
            var data = db.sp_supplier_list();
            return data.ToList();
        }

        public Supplier GetSupplier(int nit)
        {
            Supplier supplier = db.sp_supplier_getById(nit).FirstOrDefault();
            return supplier;
        }

        public void UpdateSupplier(Supplier supplier)
        {
                   db.sp_supplier_update(
                       supplier.supplierNit,
                       supplier.supplierName,
                       supplier.supplierAddress,
                       supplier.supplierPhoneNumber,
                       supplier.supplierCity,
                       supplier.supplierWebpage);
            db.SaveChanges();
        }
    }
}
