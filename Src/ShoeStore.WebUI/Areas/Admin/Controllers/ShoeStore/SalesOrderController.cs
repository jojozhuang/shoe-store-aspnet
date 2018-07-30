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
    public class SalesOrderController : BaseController
    {
        private IShoeStoreRepository shoeStoreRepository;

        public SalesOrderController(IShoeStoreRepository shoeStoreRepo)
        {
            shoeStoreRepository = shoeStoreRepo;
            base.SetPageHeader("Sales Order");
        }

        public ViewResult List()
        {
            return View(shoeStoreRepository.View_SalesOrders);
        }

        public ViewResult Create()
        {
            ViewBag.SalesOrderStatuss = shoeStoreRepository.SalesOrderStatuss;
            ViewBag.Customers = GetAppUsersInRole(AdminConstants.ROLE_CUSTOMER);
            return View("Edit", new SalesOrder());
        }

        public ViewResult Edit(int salesOrderId)
        {
            ViewBag.SalesOrderStatuss = shoeStoreRepository.SalesOrderStatuss;
            ViewBag.Customers = GetAppUsersInRole(AdminConstants.ROLE_CUSTOMER);
            SalesOrder SalesOrder = shoeStoreRepository.SalesOrders.FirstOrDefault(p => p.SalesOrderId == salesOrderId);
            return View(SalesOrder);
        }

        [HttpPost]
        public ActionResult Edit(SalesOrder salesOrder)
        {
            if (ModelState.IsValid)
            {
                if (salesOrder.SalesOrderId == 0)
                {
                    salesOrder.CreatedTime = System.DateTime.Now;
                    salesOrder.CreatedById = DataConvert.GetInt32(Session["AdminId"]);
                    salesOrder.CreatedByName = DataConvert.GetString(Session["AdminName"]);
                }
                salesOrder.UpdatedTime = System.DateTime.Now;
                salesOrder.UpdatedById = DataConvert.GetInt32(Session["AdminId"]);
                salesOrder.UpdatedByName = DataConvert.GetString(Session["AdminName"]);
                shoeStoreRepository.SaveSalesOrder(salesOrder);
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} has been created!", salesOrder.SalesOrderId));
                return RedirectToAction("List");
            }
            else
            {
                //There is something wrong with the data values
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "There is something wrong with the data values, please check!");
                ViewBag.SalesOrderStatuss = shoeStoreRepository.SalesOrderStatuss;
                ViewBag.Customers = GetAppUsersInRole(AdminConstants.ROLE_CUSTOMER);
                return View(salesOrder);
            }
        }

        [HttpGet]
        public ActionResult Delete(int salesOrderId)
        {
            SalesOrder deletedSalesOrder = shoeStoreRepository.DeleteSalesOrder(salesOrderId);
            if (deletedSalesOrder != null)
            {
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} was deleted!", deletedSalesOrder.SalesOrderId));
            }
            return RedirectToAction("List");
        }
        
	}
}