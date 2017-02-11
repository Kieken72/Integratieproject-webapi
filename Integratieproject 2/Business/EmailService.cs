using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Leisurebooker.Business
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await configSendGridasync(message);
        }

        // Use NuGet to install SendGrid (Basic C# client lib) 
        private async Task configSendGridasync(IdentityMessage message)
        {
            string apiKey = ConfigurationManager.AppSettings["SENDGRID_API"];
            dynamic sg = new SendGridAPIClient(apiKey);

            Email from = new Email("hello@leisurebooker.me");
            Email to = new Email(message.Destination);
            Content content = new Content("text/html", message.Body);
            Mail mail = new Mail(from, message.Subject, to, content);

            dynamic response = await sg.client.mail.send.post(requestBody: mail.Get());
        }
    }
}
