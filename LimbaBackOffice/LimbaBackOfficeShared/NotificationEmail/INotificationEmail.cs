using System;
using System.Collections.Generic;
using System.Text;

namespace LimbaBackOfficeShared.NotificationEmail
{
    public interface INotificationEmail
    {
        void EmailNotify();
        void CreateEmail();
        void SendEmail();
        string GetMessageBody();
    }
}
