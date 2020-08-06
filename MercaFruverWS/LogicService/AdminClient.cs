using ModelService;
using System.Collections.Generic;
using System.Linq;

namespace LogicService
{
    public class AdminClient : IAdminClient
    {
        MercaFruverSVEntities db = new MercaFruverSVEntities();

        public AdminClient()
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
        }

        public void AddClient(Client client)
        {
            db.sp_client_insert(
                client.clientDocumentTypeId,
                client.clientDocumentNumber,
                client.clientName,
                client.clientAddress,
                client.clientEmail,
                client.clientPhoneNumber);
            db.SaveChanges();
        }

        public void DeleteClient(string documentNumber)
        {
            db.sp_client_deleteSoft(documentNumber);
            db.SaveChanges();
        }

        public List<vw_Client> GetAllClients()
        {
            var data = db.sp_client_list();
            return data.ToList();
        }

        public Client GetClient(string documentNumber)
        {
            Client client = db.sp_client_getByDocument(documentNumber).FirstOrDefault();
            return client;
        }

        public void UpdateClient(Client client)
        {
            db.sp_client_update(
                client.clientDocumentNumber,
                client.clientName,
                client.clientAddress,
                client.clientEmail,
                client.clientPhoneNumber);
            db.SaveChanges();
        }
    }
}
