using ModelService;
using System.Collections.Generic;
using System.Linq;

namespace LogicService
{
    public class AdminDocument : IAdminDocument
    {
        MercaFruverSVEntities db = new MercaFruverSVEntities();

        public AdminDocument()
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
        }
        public List<Document_Type> GetAllDocuments()
        {
            return db.Document_Type.ToList();
        }
    }
}
