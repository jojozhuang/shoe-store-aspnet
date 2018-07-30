using Johnny.ShoeStore.Domain.Abstract;
using Johnny.ShoeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Johnny.Library.Helper;
using Johnny.ShoeStore.WebUI.Areas.Admin.Infrastructure;
using Johnny.ShoeStore.WebUI.Areas.Admin.Models;

namespace Johnny.ShoeStore.WebUI.Areas.Admin.Controllers
{
    public class SalesOrderStatusController : BaseController
    {
        private IShoeStoreRepository shoeStoreRepository;

        public SalesOrderStatusController(IShoeStoreRepository shoeStoreRepo)
        {
            shoeStoreRepository = shoeStoreRepo;
            base.SetPageHeader("Sales Order Status");
        }

        public ViewResult List()
        {
            return View(shoeStoreRepository.SalesOrderStatuss);
        }

        public ViewResult Create()
        {
            return View("Edit", new SalesOrderStatus());
        }

        public ViewResult Edit(int salesOrderStatusId)
        {
            SalesOrderStatus SalesOrderStatus = shoeStoreRepository.SalesOrderStatuss.FirstOrDefault(p => p.SalesOrderStatusId == salesOrderStatusId);
            return View(SalesOrderStatus);
        }

        [HttpPost]
        public ActionResult Edit(SalesOrderStatus salesOrderStatus)
        {
            if (ModelState.IsValid)
            {
                shoeStoreRepository.SaveSalesOrderStatus(salesOrderStatus);
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} has been created!", salesOrderStatus.SalesOrderStatusName));
                return RedirectToAction("List");
            }
            else
            {
                //There is something wrong with the data values
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "There is something wrong with the data values, please check!");
                return View(salesOrderStatus);
            }
        }

        [HttpGet]
        public ActionResult Delete(int salesOrderStatusId)
        {
            SalesOrderStatus deletedSalesOrderStatus = shoeStoreRepository.DeleteSalesOrderStatus(salesOrderStatusId);
            if (deletedSalesOrderStatus != null)
            {
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} was deleted!", deletedSalesOrderStatus.SalesOrderStatusName));
            }
            return RedirectToAction("List");
        }
	}
}