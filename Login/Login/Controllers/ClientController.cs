using Login.Filters;
using Login.ServiceReference;
using System.Net;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class ClientController : Controller
    {
        ServiceClient client;

        public ClientController()
        {
            client = new ServiceClient();
        }
        // GET: Client
        public ActionResult Index()
        {
            var clientList = client.GetAllClients();
            return View(clientList);
        }

        // GET: Client/Create
        [AuthorizeUser(idOperation: 1)]
        public ActionResult Create()
        {
            ViewBag.DocumentId = new SelectList(client.GetAllDocuments(), "documentTypeId", "documentTypeName");
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperation: 1)]
        public ActionResult Create(Client cliente)
        {
            if (ModelState.IsValid)
            {
                client.AddClient(cliente);
                return RedirectToAction("Index");
            }

            ViewBag.DocumentId = new SelectList(client.GetAllDocuments(), "documentTypeId", "documentTypeName", cliente.clientDocumentTypeId);
            return View(cliente);
        }

        // GET: Client/Edit/5
        [AuthorizeUser(idOperation: 2)]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Client cliente = client.GetClient(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocumentId = new SelectList(client.GetAllDocuments(), "documentTypeId", "documentTypeName", cliente.clientDocumentTypeId);
            return View(cliente);
        }

        // POST: Client/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperation: 2)]
        public ActionResult Edit(Client cliente)
        {
          
             if (ModelState.IsValid)
             {
                 client.UpdateClient(cliente);
                 return RedirectToAction("Index");
             }
            ViewBag.DocumentId = new SelectList(client.GetAllDocuments(), "documentTypeId", "documentTypeName", cliente.clientDocumentTypeId);
            return View(cliente);
            
        }

        // GET: Client/Delete/5
        [AuthorizeUser(idOperation: 3)]
        public ActionResult Delete(string id)

        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Client cliente = client.GetClient(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperation: 3)]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                client.DeleteClient(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
