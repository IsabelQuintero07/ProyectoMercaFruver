using ModelService;
using System.Collections.Generic;

namespace LogicService
{
    public interface IAdminSupplier
    {
        void AddSupplier(Supplier supplier);

        Supplier GetSupplier(int nit);

        void UpdateSupplier(Supplier supplier);

        void DeleteSupplier(int nit);

        List<vw_Supplier> GetAllSuppliers();
    }
}
