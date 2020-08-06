using ModelService;
using System.Collections.Generic;
using System.Linq;

namespace LogicService
{
    public class AdminVendor : IAdminVendor
    {
        MercaFruverSVEntities db = new MercaFruverSVEntities();

        public AdminVendor()
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
        }

        public void AddVendor(Vendor vendor)
        {
            db.sp_vendor_insert(
                vendor.vendorDocumentTypeId,
                vendor.vendorDocumentTypeNumber,
                vendor.vendorName,
                vendor.vendorAddress,
                vendor.vendorEmail,
                vendor.vendorPhoneNumber
            );
            db.SaveChanges();
        }

        public Vendor GetVendor(string documentNumber)
        {
            Vendor vendor = db.sp_vendor_getById(documentNumber).FirstOrDefault();
            return vendor;
        }

        public void UpdateVendor(Vendor vendor)
        {
            db.sp_vendor_update(
                vendor.vendorDocumentTypeNumber,
                vendor.vendorName,
                vendor.vendorAddress,
                vendor.vendorEmail,
                vendor.vendorPhoneNumber
            );
            db.SaveChanges();
        }

        public void DeleteVendor(string documentNumber)
        {
            db.sp_vendor_deleteSoft(documentNumber);
            db.SaveChanges();
        }

        public List<vw_Vendor> GetAllVendors()
        {
            var data = db.sp_vendor_list();
            return data.ToList();
        }
    }
}
