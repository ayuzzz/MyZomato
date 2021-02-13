using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using CommonModels;
using RabbitMQ.Client;
using System.Diagnostics;

namespace Examples.SmtpExamples.Async
{
    public class EmailUtility
    {
        public static void SendMail(Email email)
        {
            try
            {
                SmtpClient client = new SmtpClient(email.Host, email.Port);
                client.Credentials = new NetworkCredential(email.Username, email.Password);
                MailAddress from = new MailAddress(email.FromAddress, email.DisplayName);
                MailAddress to = new MailAddress(email.ToAddress);
                MailMessage message = new MailMessage(from, to);
                message.Body = email.MessageBody;
                message.Subject = email.Subject;
                message.IsBodyHtml = true;
                client.EnableSsl = true;
                client.Send(message);
                message.Dispose();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}