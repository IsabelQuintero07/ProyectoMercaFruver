using Login.Filters;
using Login.ServiceReference;
using System.Net;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class PurchaseController : Controller
    {
        ServiceClient client;
        public PurchaseController()
        {
            client = new ServiceClient();
        }
        // GET: Purchase
        public ActionResult Index()
        {
            var purchaseList = client.GetAllPurchases();
            return View(purchaseList);
        }

        // GET: Purchase/Create
        [AuthorizeUser(idOperation: 28)]
        public ActionResult Create()
        {
            ViewBag.SupplierId = new SelectList(client.GetAllSuppliers(), "supplierId", "Name");
            ViewBag.ProductId = new SelectList(client.GetAllProducts(), "productId", "Name");

            return View();
        }

        // POST: Purchase/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperation: 28)]
        public ActionResult Create([Bind(Include ="purchaseId, purchaseSupplierId, purchaseProductId," +
            "purchaseQuantity, purchaseUnitCost, purchaseDate")]Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                int id = purchase.purchaseProductId;
                Product product = client.GetProductId(id);

                product.productStock += purchase.purchaseQuantity;
                client.UpdateProduct(product);

                client.AddPurchase(purchase);
                return RedirectToAction("Index");
            }

            ViewBag.SupplierId = new SelectList(client.GetAllSuppliers(), "supplierId", "Name", purchase.purchaseSupplierId);
            ViewBag.ProductId = new SelectList(client.GetAllProducts(), "productId", "Name", purchase.purchaseProductId);
            return View(purchase);
        }

        // GET: Purchase/Edit/5
        [AuthorizeUser(idOperation: 29)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Purchase purchase = client.GetPurchase(id.Value);

            if (purchase == null)
            {
                return HttpNotFound();
            }

            ViewBag.SupplierId = new SelectList(client.GetAllSuppliers(), "supplierId", "Name", purchase.purchaseSupplierId);
            ViewBag.ProductId = new SelectList(client.GetAllProducts(), "productId", "Name", purchase.purchaseProductId);
            return View(purchase);
        }

        // POST: Purchase/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperation: 29)]
        public ActionResult Edit(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                client.UpdatePurchase(purchase);
                return RedirectToAction("Index");
            }

            ViewBag.SupplierId = new SelectList(client.GetAllSuppliers(), "supplierId", "Name", purchase.purchaseSupplierId);
            ViewBag.ProductId = new SelectList(client.GetAllProducts(), "productId", "Name", purchase.purchaseProductId);
            return View(purchase);
        }

        // GET: Purchase/Delete/5
        [AuthorizeUser(idOperation: 30)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Purchase purchase = client.GetPurchase(id.Value);

            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // POST: Purchase/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperation: 30)]
        public ActionResult Delete(int id)
        {
            try
            {
                client.DeletePurchase(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
