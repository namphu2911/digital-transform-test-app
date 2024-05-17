using InternTestWebApp.Models;
using InternTestWebApp.Repository.cs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternTestWebApp.Controllers
{
    public class SalesOrdersController : Controller
    {
        private SalesOrdersRepository _salesOrdersRepository;
        public SalesOrdersController()
        {
            _salesOrdersRepository = new SalesOrdersRepository();
        }

        public ActionResult Index()
        {
            IEnumerable<SalesOrders> salesOrders = _salesOrdersRepository.GetAllSalesOrders();
            return View(salesOrders);
        }

       
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalesOrders salesOrders)
        {
            try
            {
                _salesOrdersRepository.AddSalesOrder(salesOrders);
                TempData["success"] = "SalesOrders created successfully";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }

        public ActionResult Edit(int id)
        {
            SalesOrders salesOrders = _salesOrdersRepository.GetSalesOrder(id);
            return View(salesOrders);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SalesOrders salesOrders)
        {
            try
            {
                _salesOrdersRepository.UpdateSalesOrder(salesOrders);
                TempData["success"] = "SalesOrders updated successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                if (_salesOrdersRepository.DeleteSalesOrder(id))
                {
                    ViewBag.AlertMsg = "Deleted successfully";
                }
                TempData["success"] = "SalesOrders deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
