using MiniDMartApp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniDMartApp.Areas.Master.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockDataService _stockDataService;
        
        public StockController(IStockDataService stockDataService)
        {
            this._stockDataService = stockDataService;
        }
        // GET: Master/Stock
        [HttpGet,OutputCache(Duration = 0)]
        public ActionResult Index()
        {           
            return View();
        }
        [HttpPost]
        public ActionResult GetAllStock()
        {
            var getAllStock = _stockDataService.GetAllItemStock();       
            return Json(new { data = getAllStock }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult IncreaseStock(ItemQuantityModel model)
        {
            var addStock = _stockDataService.IncreaseStock(model.ItemCode, model.Quantity);
            return Json(new { Quantity = addStock },JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DecreaseStock(ItemQuantityModel model)
        {
            var decreaseStock = _stockDataService.DecreaseStock(model.ItemCode, model.Quantity);
            return Json(new { Quantity = decreaseStock }, JsonRequestBehavior.AllowGet);
        }

    }
    public class ItemQuantityModel
    {
        public int ItemCode { get; set; }
        public double Quantity { get; set; }
    }
} 