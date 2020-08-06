using ModelService;
using System.Collections.Generic;
using System.Linq;

namespace LogicService
{
    public class AdminSale : IAdminSale
    {
        MercaFruverSVEntities db = new MercaFruverSVEntities();

        public AdminSale()
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
        }

        public void AddSale(Sale sale)
        {
            db.sp_sale_insert(
               sale.saleClientId,
               sale.saleVendorId,
               sale.saleDiscount,
               sale.saleTotal
            );
            
            db.SaveChanges();
        }

        public Sale GetSale(int id)
        {
            Sale sale = db.sp_sale_getById(id).FirstOrDefault();
            return sale;
        }

        public void UpdateSale(Sale sale)
        {
            db.sp_sale_update(
                sale.saleId,
                sale.saleClientId,
                sale.saleVendorId,
                sale.saleDiscount,
                sale.saleTotal
            );
            db.SaveChanges();
        }

        public void DeleteSale(int id)
        {
            db.sp_sale_deleteSoft(id);
            db.SaveChanges();
        }

        public List<vw_Sale> GetAllSales()
        {
            var data = db.sp_sale_list();
            return data.ToList();
        }

        public Sale GetLastSale()
        {
           Sale sale = db.sp_sale_getlast().FirstOrDefault();
            return sale;
        }
    }
}
