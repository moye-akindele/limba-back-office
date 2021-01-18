using LimbaBackOfficeShared.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace LimbaBackOfficeShared.NotificationEmail
{
    public class NotifyReg : INotificationEmail
    {
        MimeMessage email = new MimeMessage();

        const string username = "kody.kilback@ethereal.email";
        const string password = "WZxBmm4Krtqg4qus5F";

        const string SenderAddress = "support@limba.com";
        NotifyRegModel _notifyRegModel;

        public NotifyReg(NotifyRegModel notifyRegModel)
        {
            _notifyRegModel = notifyRegModel;
        }

        public void EmailNotify()
        {
            CreateEmail();
            SendEmail();
        }

        public void CreateEmail()
        {
            email.From.Add(MailboxAddress.Parse(SenderAddress));
            email.To.Add(MailboxAddress.Parse(_notifyRegModel.recipientAddress));
            email.Subject = "Welcome To Limba";
            email.Body = new TextPart(TextFormat.Html) { Text = GetMessageBody() };
        }

        public void SendEmail()
        {
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(username, password);
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        public string GetMessageBody()
        {
            string messageBody = "";

            messageBody += "<h1>Example HTML Message Body</h1>";

            return messageBody;
        }
    }
}
