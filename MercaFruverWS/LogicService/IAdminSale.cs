using ModelService;
using System.Collections.Generic;

namespace LogicService
{
    public interface IAdminSale
    {
        void AddSale(Sale sale);

        Sale GetSale(int id);

        void UpdateSale(Sale sale);

        void DeleteSale(int id);

        List<vw_Sale> GetAllSales();

        Sale GetLastSale();
    }
}
