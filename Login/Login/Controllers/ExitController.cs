using System.Web.Mvc;

namespace Login.Controllers
{
    public class ExitController : Controller
    {
        // GET: Exit
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Acces");
        }
    }
}