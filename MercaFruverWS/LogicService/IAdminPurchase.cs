using ModelService;
using System.Collections.Generic;

namespace LogicService
{
    public interface IAdminPurchase
    {
        void AddPurchase(Purchase purchase);

        Purchase GetPurchase(int id);

        void UpdatePurchase(Purchase purchase);

        void DeletePurchase(int id);

        List<vw_Purchase> GetAllPurchases();
    }
}
