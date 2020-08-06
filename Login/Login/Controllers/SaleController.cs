using Login.Filters;
using Login.ServiceReference;
using System.Net;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class SaleController : Controller
    {
        ServiceClient client;
        public SaleController()
        {
            client = new ServiceClient();
        }
        // GET: Sale
    
        public ActionResult Index()
        {
            var saleList = client.GetAllSales();
            return View(saleList);
        }

        // GET: Sale/Create
        [AuthorizeUser(idOperation: 10)]
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(client.GetAllClients(), "clientId", "Name");
            ViewBag.VendorId = new SelectList(client.GetAllVendors(), "vendorId", "Name");
            return View();
        }

        // POST: Sale/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public ActionResult Create(Sale sale)
        {
            if (ModelState.IsValid)
            {
                client.AddSale(sale);
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(client.GetAllClients(), "clientId", "Name", sale.saleClientId);
            ViewBag.VendorId = new SelectList(client.GetAllVendors(), "vendorId", "Name", sale.saleVendorId);
            return View(sale);
        }

        // GET: Sale/Edit/5
    
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Sale sale = client.GetSale(id.Value);

            if (sale == null)
            {
                return HttpNotFound();
            }

            ViewBag.ClientId = new SelectList(client.GetAllClients(), "clientId", "Name", sale.saleClientId);
            ViewBag.VendorId = new SelectList(client.GetAllVendors(), "vendorId", "Name", sale.saleVendorId);
            return View(sale);
        }

        // POST: Sale/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Edit(Sale sale)
        {
            if (ModelState.IsValid)
            {
                client.UpdateSale(sale);
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(client.GetAllClients(), "clientId", "Name", sale.saleClientId);
            ViewBag.VendorId = new SelectList(client.GetAllVendors(), "vendorId", "Name", sale.saleVendorId);
            return View(sale);
        }

        // GET: Sale/Delete/5

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Sale sale = client.GetSale(id.Value);

            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // POST: Sale/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
  
        public ActionResult Delete(int id)
        {
            try
            {
                client.DeleteSale(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
