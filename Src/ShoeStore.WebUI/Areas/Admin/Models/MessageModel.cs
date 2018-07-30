using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Johnny.ShoeStore.WebUI.Areas.Admin.Models
{
    public enum EnumSevereLevel
    {
        Infomation, Warning, Error, Success
    }

    public class MessageModel
    {
        public EnumSevereLevel Level { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string BoxStyle { get; set; }
    }
}