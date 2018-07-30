using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Johnny.ShoeStore.WebUI.Areas.Admin.Infrastructure
{
    public abstract class AdminBaseViewPage<T> : WebViewPage<T>
    {
        protected override void InitializePage()
        {
            SetViewBagDefaultProperties();
            base.InitializePage();
        }

        private void SetViewBagDefaultProperties()
        {
            //ViewBag.AdminHome = "Admin Home222";
            //ViewBag.Management = "Management";
        }
    }
}