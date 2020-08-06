using Login.Filters;
using Login.ServiceReference;
using System.Net;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class ConceptController : Controller
    {
        ServiceClient client;
        public ConceptController()
        {
            client = new ServiceClient();
        }
        // GET: Concept
        public ActionResult Index()
        {
            var conceptList = client.GetAllConcepts();
            return View(conceptList);
        }

        // GET: Concept/Create
        [AuthorizeUser(idOperation: 15)]
        public ActionResult Create()
        {
            ViewBag.SaleId = new SelectList(client.GetAllSales(), "saleId", "saleId");
            ViewBag.ProductId = new SelectList(client.GetAllProducts(), "productId", "Name");
            return View();
        }

        // POST: Concept/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperation: 15)]
        public ActionResult Create(Concept_Sale concept)
        {
            if (ModelState.IsValid)
            {
                client.AddConcept(concept);
                return RedirectToAction("Index");
            }
            ViewBag.SaleId = new SelectList(client.GetAllSales(), "saleId", "saleId", concept.conceptSaleId);
            ViewBag.ProductId = new SelectList(client.GetAllProducts(), "productId", "Name", concept.conceptProductId);
            return View(concept);
        }

        // GET: Concept/Edit/5
        [AuthorizeUser(idOperation: 16)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Concept_Sale concept = client.GetConcept(id.Value);

            if (concept == null)
            {
                return HttpNotFound();
            }

            ViewBag.SaleId = new SelectList(client.GetAllSales(), "saleId", "saleId", concept.conceptSaleId);
            ViewBag.ProductId = new SelectList(client.GetAllProducts(), "productId", "Name", concept.conceptProductId);
            return View(concept);
        }

        // POST: Concept/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperation: 16)]
        public ActionResult Edit(Concept_Sale concept)
        {
            if (ModelState.IsValid)
            {
                client.UpdateConcept(concept);
                return RedirectToAction("Index");
            }

            ViewBag.SaleId = new SelectList(client.GetAllSales(), "saleId", "saleId", concept.conceptSaleId);
            ViewBag.ProductId = new SelectList(client.GetAllProducts(), "productId", "Name", concept.conceptProductId);
            return View(concept);
        }

        // GET: Concept/Delete/5
        [AuthorizeUser(idOperation: 17)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Concept_Sale concept = client.GetConcept(id.Value);

            if (concept == null)
            {
                return HttpNotFound();
            }
            return View(concept);
        }

        // POST: Concept/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperation: 17)]
        public ActionResult Delete(int id)
        {
            try
            {
                client.DeleteConcept(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
