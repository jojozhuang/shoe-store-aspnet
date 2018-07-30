using Johnny.ShoeStore.Domain.Abstract;
using Johnny.ShoeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Johnny.ShoeStore.WebUI.Areas.Admin.Controllers
{
    public class WebsiteConfigController : Controller
    {
        private IWebsiteConfigRepository websiteConfigRepository;

        public WebsiteConfigController(IWebsiteConfigRepository websiteConfigRepo)
        {
            websiteConfigRepository = websiteConfigRepo;
        }

        #region MailSetting
        //MailSetting
        public ViewResult EditMailSetting()
        {
            MailSetting mailSetting = websiteConfigRepository.MailSettings.FirstOrDefault();
            if (mailSetting == null)
                mailSetting = new MailSetting();
            return View(mailSetting);
        }

        [HttpPost]
        public ActionResult EditMailSetting(MailSetting mailSetting)
        {
            if (ModelState.IsValid)
            {
                websiteConfigRepository.SaveMailSetting(mailSetting);
                TempData["message"] = string.Format("{0} has been saved", mailSetting.MailSettingId);
                return View(mailSetting);
            }
            else
            {
                //There is something wrong with the data values
                TempData["message"] = string.Format("Error occurs!", mailSetting.MailSettingId);
                return View(mailSetting);
            }
        }
                
        #endregion
	}
}