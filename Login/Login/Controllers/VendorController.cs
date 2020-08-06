using Login.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class VendorController : Controller
    {
        ServiceClient client;

        public VendorController()
        {
            client = new ServiceClient();
        }
        // GET: Vendor
        public ActionResult Index()
        {
            var vendorList = client.GetAllVendors();
            return View(vendorList);
        }

        // GET: Vendor/Create
        public ActionResult Create()
        {
            ViewBag.DocumentId = new SelectList(client.GetAllDocuments(), "documentTypeId", "documentTypeName");
            return View();
        }

        // POST: Vendor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                client.AddVendor(vendor);
                return RedirectToAction("Index");
            }

            ViewBag.DocumentId = new SelectList(client.GetAllDocuments(), "documentTypeId", "documentTypeName", vendor.vendorDocumentTypeId);
            return View(vendor);
        }

        // GET: Vendor/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Vendor vendor = client.GetVendor(id);

            if (vendor == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocumentId = new SelectList(client.GetAllDocuments(), "documentTypeId", "documentTypeName", vendor.vendorDocumentTypeId);
            return View(vendor);
        }

        // POST: Vendor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vendor vendor)
        {

            if (ModelState.IsValid)
            {
                client.UpdateVendor(vendor);
                return RedirectToAction("Index");
            }
            ViewBag.DocumentId = new SelectList(client.GetAllDocuments(), "documentTypeId", "documentTypeName", vendor.vendorDocumentTypeId);
            return View(vendor);

        }

        // GET: Vendor/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Vendor vendor = client.GetVendor(id);

            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                client.DeleteVendor(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}