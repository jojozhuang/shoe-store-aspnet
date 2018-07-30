using System;
using System.Collections.Generic;

namespace Johnny.ShoeStore.Domain.Entities
{
    public partial class MailSetting
    {
        public int MailSettingId { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string EmailAddress { get; set; }
        public string EmailPassword { get; set; }
    }
}
