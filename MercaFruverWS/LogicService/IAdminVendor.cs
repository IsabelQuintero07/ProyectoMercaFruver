using ModelService;
using System.Collections.Generic;

namespace LogicService
{
    public interface IAdminVendor
    {
        void AddVendor(Vendor vendor);

        Vendor GetVendor(string documentNumber);

        void UpdateVendor(Vendor vendor);

        void DeleteVendor(string documentNumber);

        List<vw_Vendor> GetAllVendors();
    }
}
