using MiniDMartApp.Application.Interfaces;
using MiniDMartApp.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MiniDMartApp.Areas.Master.Controllers
{
    public class ShopController : Controller
    {
        private readonly IItemDataService _itemDataService;
        public ShopController(IItemDataService itemDataService)
        {
            _itemDataService = itemDataService;
        }
        // GET: Master/Shop
        [HttpGet, OutputCache(Duration = 0)]
        public ActionResult Index()
        {
            return View(new ItemDataModel());
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Add(ItemDataModel model)
        {
            _itemDataService.Add(model);
            return View("Index");
        }
        [HttpGet]
        public ActionResult GetData()
        {
            List<SelectListItem> listRateDrop = null;
            var rateList = new List<string>()
          {
              "Less than 100","Between 101 And 1000","Greater than 1001"
          };

            listRateDrop = new List<SelectListItem>()
                {
                    new SelectListItem() { Text = "All", Value = "0" },
                    new SelectListItem() { Text = rateList[0], Value = "100" },
                    new SelectListItem() { Text = rateList[1], Value = "101" },
                    new SelectListItem() { Text = rateList[2], Value = "1001" }

                };

            ViewBag.Rate = listRateDrop;
            return View();
        }

        [HttpPost]
        public ActionResult GetAllData(string rate)
        {
            var list = _itemDataService.GetItemByRate(rate);
            var griData = (from dt in list
                           select new
                           {
                               ItemCode = dt.ItemCode,
                               ItemName = dt.ItemName,
                               Description = dt.Description,
                               Rate = dt.Rate
                           }).ToList();
            return Json(new { data = griData }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult GetByRate(string rate)
        {
            return Json(new { data = _itemDataService.GetItemByRate(rate) }, JsonRequestBehavior.AllowGet);
            // return RedirectToAction("GetAllData", rateNew);
        }
    }
}