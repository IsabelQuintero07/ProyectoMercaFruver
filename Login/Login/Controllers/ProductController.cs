using Login.Filters;
using Login.Models.ViewModels;
using Login.ServiceReference;
using System.Net;
using System.Web.Mvc;

namespace MercaFruverClient.Controllers
{
    public class ProductController : Controller
    {
        ServiceClient client;

       
        public ProductController()
        {
            client = new ServiceClient();
        }

        // GET: Product
        //[AuthorizeUser(idOperation: 1)]
        public ActionResult Index()
        {
            var productList = client.GetAllProducts();
            return View(productList);
        }

        // GET: Product/Create
        [AuthorizeUser(idOperation: 19)]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(client.ListCategory(), "categoryId", "categoryName");
            return View();

        }

        // POST: Product/Create
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperation: 19)]
        public ActionResult Create([Bind(Include = "productId, productCategoryId, productCode, productName, productSellingPrice, productStock, productCost")] Product product)
        {
            if (ModelState.IsValid)
            {
                client.AddProduct(product);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(client.ListCategory(), "CategoryId", "CategoryName", product.productCategoryId);
            return View(product);
        }

        // GET: Product/Edit/5
        [AuthorizeUser(idOperation: 21)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = client.GetProduct(id.Value);

            ProductEditData model = new ProductEditData();
            model.productCategoryId = product.productCategoryId;
            model.productCode = (int)product.productCode;
            model.productName = product.productName;
            model.productSellingPrice = product.productSellingPrice;
            model.productStock = (int)product.productStock;
            model.productCost = (int)product.productCost;

            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(client.ListCategory(), "categoryId", "categoryName", model.productCategoryId);
            return View(model);
        }

        // POST: Product/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperation: 21)]
        public ActionResult Edit(ProductEditData model)
        {

            if (ModelState.IsValid)
            {
                Product product = new Product();
                product.productCategoryId = model.productCategoryId;
                product.productCode = model.productCode;
                product.productName = model.productName;
                product.productSellingPrice = model.productSellingPrice;
                product.productStock = model.productStock;
                product.productCost = model.productCost;

                if (model.productStockLimit == model.productStock)
                {
                    ViewBag.Limit = "product is at the limit";
                }   
                    
                client.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(client.ListCategory(), "categoryId", "categoryName", model.productCategoryId);
            return View(model);

        }

        // GET: Product/Delete/5
        [AuthorizeUser(idOperation: 22)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = client.GetProduct(id.Value);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperation: 22)]
        public ActionResult Delete(int id)
        {
            try
            {
                client.DeleteProduct(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}