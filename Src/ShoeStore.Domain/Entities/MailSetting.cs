using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Johnny.ShoeStore.Domain.Entities
{
    [MetadataType(typeof(MailSettingMetaData))]
    public partial class MailSetting
    {
    }

    public class MailSettingMetaData
    {
        [HiddenInput(DisplayValue = false)]
        public int MailSettingId { get; set; }
        [Required(ErrorMessage = "Please enter a smtp server")]
        public string SmtpServer { get; set; }
        //public int SmtpPort { get; set; }
        //public string EmailAddress { get; set; }
        //public string EmailPassword { get; set; }
    }
}
