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
    public class NotifyPasswordReset : INotificationEmail
    {
        MimeMessage email = new MimeMessage();

        const string username = "kody.kilback@ethereal.email";
        const string password = "WZxBmm4Krtqg4qus5F";

        const string SenderAddress = "support@limba.com";
        string RecipientAddress = string.Empty;

        ResetPasswordModel _resetPasswordModel;

        public NotifyPasswordReset(ResetPasswordModel resetPasswordModel)
        {
            _resetPasswordModel = resetPasswordModel;
        }

        public void EmailNotify()
        {
            CreateEmail();
            SendEmail();
        }


        public void CreateEmail()
        {
            email.From.Add(MailboxAddress.Parse(SenderAddress));
            email.To.Add(MailboxAddress.Parse(_resetPasswordModel.recipientAddress));
            email.Subject = "Successful Password Reset";
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

            messageBody += "<h1>Your password has been reset.</h1>";
            messageBody += "<p>You will be required to change your password when next you login.</p><br />";
            messageBody += "<p>Your new password is shown below: </p>";
            messageBody += $"<p> {{messagePassword}} </p>";

            return messageBody;
        }

        
    }
}
