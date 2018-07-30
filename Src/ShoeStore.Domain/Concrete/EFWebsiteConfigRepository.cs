using Johnny.ShoeStore.Domain.Abstract;
using Johnny.ShoeStore.Domain.Entities;
using System.Collections.Generic;

namespace Johnny.ShoeStore.Domain.Concrete
{
    public class EFWebsiteConfigRepository : IWebsiteConfigRepository
    {
        private EFDbContext context = new EFDbContext();

        #region MailSettings
        public IEnumerable<MailSetting> MailSettings
        {
            get { return context.MailSettings; }
        }

        public void SaveMailSetting(MailSetting mailSetting)
        {
            if (mailSetting.MailSettingId == 0)
            {
                context.MailSettings.Add(mailSetting);
            }
            else
            {
                MailSetting dbEntry = context.MailSettings.Find(mailSetting.MailSettingId);
                if (dbEntry != null)
                {
                    dbEntry.SmtpServer = mailSetting.SmtpServer;
                    dbEntry.SmtpPort = mailSetting.SmtpPort;
                    dbEntry.EmailAddress = mailSetting.EmailAddress;
                    dbEntry.EmailPassword = mailSetting.EmailPassword;
                }
            }
            context.SaveChanges();
        }
        #endregion
       
    }
}