using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [HttpGet]
        public ActionResult UnauthorizedOperation(String operation, String module, String msjeErrorExeption)
        {
            ViewBag.operacion = operation;
            ViewBag.modulo = module;
            ViewBag.msjeErrorExcepcion = msjeErrorExeption;
            return View();
        }
    }
}