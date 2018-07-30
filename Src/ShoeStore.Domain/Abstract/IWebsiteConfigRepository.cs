using System.Collections.Generic;
using Johnny.ShoeStore.Domain.Entities;

namespace Johnny.ShoeStore.Domain.Abstract
{
    public interface IWebsiteConfigRepository
    {
        IEnumerable<MailSetting> MailSettings { get; }
        void SaveMailSetting(MailSetting mailSetting);       
    }
}