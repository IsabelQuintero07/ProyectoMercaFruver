using Login.Filters;
using Login.ServiceReference;
using System.Net;
using System.Web.Mvc;

namespace MercaFruverClient.Controllers
{
    public class CategoryController : Controller
    {
        ServiceClient client;

        public CategoryController()
        {
            client = new ServiceClient();
        }
        // GET: Category

        [HttpGet]
        [AuthorizeUser(idOperation: 24)]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperation: 24)]
        public ActionResult Create(Category category)
        {
            client.AddCategory(category);
            return View("Index", client.ListCategory());
        }

        [HttpGet]
        [AuthorizeUser(idOperation: 25)]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = client.GetCategory(id.Value);

            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperation: 25)]
        public ActionResult Update(Category category)
        {
            try
            {
                client.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        [HttpGet]
        [AuthorizeUser(idOperation: 26)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = client.GetCategory(id.Value);

            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(idOperation: 26)]
        public ActionResult Delete(int id)
        {
            try
            {
                client.DeleteCategory(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Index()
        {
            var categorylist = client.ListCategory();
            return View(categorylist);
        }

    }
}