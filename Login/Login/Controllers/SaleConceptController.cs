using Login.Models.ViewModels;
using Login.ServiceReference;
using System;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class SaleConceptController : Controller
    {
        ServiceClient client;
        public SaleConceptController()
        {
            client = new ServiceClient();
        }

        // GET: SaleConcept
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.ProductId = new SelectList(client.GetAllProducts(), "productId", "Name");
            ViewBag.ClientId = new SelectList(client.GetAllClients(), "clientId", "Name");
            ViewBag.VendorId = new SelectList(client.GetAllVendors(), "vendorId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Add(SaleViewModel model)
        {
            Sale objSale = new Sale();
            Concept_Sale objConcept = new Concept_Sale();
            try
            {
                
                objSale.saleClientId = model.saleClientId;
                objSale.saleVendorId = model.saleVendorId;
                //objSale.saleDiscount = model.saleDiscount;
                client.AddSale(objSale);

                Sale idSale = client.GetLastSale();
                decimal total = 0;
                
                foreach (var item in model.Concepts)
                {
                    
                    objConcept.conceptProductId = item.conceptProductId;
                    objConcept.conceptQuantity = item.conceptQuantity;
                    objConcept.conceptUnitPrice = item.conceptUnitPrice;
                    decimal subtotal = item.conceptQuantity * item.conceptUnitPrice;
                    total += subtotal;
                    objConcept.conceptSaleId = idSale.saleId;
                    client.AddConcept(objConcept);

                    Product product = client.GetProductId(item.conceptProductId);
                    if (item.conceptQuantity  <= product.productStock)
                    {
                        product.productStock -= item.conceptQuantity;
                        client.UpdateProduct(product);
                    }
                   
                }
                //idSale.saleDiscount = 0;
                idSale.saleTotal = total;

                client.UpdateSale(idSale);

                ViewBag.Message = "successfuly Recorded ";
                return RedirectToAction("Index", "Sale");

            }
            catch (Exception)
            {

            }

            ViewBag.ProductId = new SelectList(client.GetAllProducts(), "productId", "Name");
            ViewBag.ClientId = new SelectList(client.GetAllClients(), "clientId", "Name", objSale.saleClientId);
            ViewBag.VendorId = new SelectList(client.GetAllVendors(), "vendorId", "Name", objSale.saleVendorId);
            return View(model);
        }
    }
}