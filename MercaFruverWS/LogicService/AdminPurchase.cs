using ModelService;
using System.Collections.Generic;
using System.Linq;

namespace LogicService
{
    public class AdminPurchase : IAdminPurchase
    {
        MercaFruverSVEntities db = new MercaFruverSVEntities();

        public AdminPurchase()
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
        }

        public void AddPurchase(Purchase purchase)
        {
            db.sp_purchase_insert(
                purchase.purchaseSupplierId, 
                purchase.purchaseProductId,
                purchase.purchaseQuantity,
                purchase.purchaseUnitCost);
            db.SaveChanges();
        }

        public void DeletePurchase(int id)
        {
            db.sp_purchase_deleteSoft(id);
            db.SaveChanges();
        }

        public Purchase GetPurchase(int id)
        {
            Purchase purchase = db.sp_purchase_getById(id).FirstOrDefault();
            return purchase;
        }

        public List<vw_Purchase> GetAllPurchases()
        {
            var data = db.sp_purchase_list();
            return data.ToList();
        }

        public void UpdatePurchase(Purchase purchase)
        {
            db.sp_purchase_update(
                purchase.purchaseId, 
                purchase.purchaseSupplierId,
                purchase.purchaseProductId,
                purchase.purchaseQuantity,
                purchase.purchaseUnitCost );
            db.SaveChanges();
        }
    }
}
