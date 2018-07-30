using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Johnny.ShoeStore.WebUI.Areas.Admin.Infrastructure
{
    public class BaseAccountController : BaseController
    {
        protected override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.PageTitle = "Account"; 
        }
    }
}