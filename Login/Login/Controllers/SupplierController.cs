using Login.ServiceReference;
using System.Net;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class SupplierController : Controller
    {
        ServiceClient client;

        public SupplierController()
        {
            client = new ServiceClient();
        }
        // GET: Supplier
        public ActionResult Index()
        {
            var supplierList = client.GetAllSuppliers();
            return View(supplierList);
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            try
            {
                client.AddSupplier(supplier);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }

        // GET: Supplier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Supplier supplier = client.GetSupplier(id.Value);

            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                client.UpdateSupplier(supplier);
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        // GET: Supplier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Supplier supplier = client.GetSupplier(id.Value);

            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Supplier/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                client.DeleteSupplier(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
