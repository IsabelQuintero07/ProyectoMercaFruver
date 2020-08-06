using ModelService;
using System.Collections.Generic;

namespace LogicService
{
    public interface IAdminClient
    {
        void AddClient(Client client);

        Client GetClient(string documentNumber);

        void UpdateClient(Client client);

        void DeleteClient(string documentNumber);

        List<vw_Client> GetAllClients();
    }
}
