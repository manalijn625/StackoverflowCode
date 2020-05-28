using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace StackOverFlow.Models
{
    public class EmailInfo
    {
        public void SendEmail(string receiver, string subject, string message)
        {
            try
            {
                var senderEmail = new MailAddress("abc@radixweb.com", "Manali");
                var receiverEmail = new MailAddress(receiver, "Receiver");
                var sub = subject;
                var body = message;
                var password = "Radixweb8";
                var smtp = new SmtpClient
                {
                    Host = "192.168.100.101",
                    Port = 25,
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
                
            };
               
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(mess);
                }

            }
            catch (Exception ex)
            { }
        }
    }
}