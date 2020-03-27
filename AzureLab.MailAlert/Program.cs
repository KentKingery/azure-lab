using System;
using System.Threading.Tasks;

using SendGrid;
using SendGrid.Helpers.Mail;

namespace AzureLab.MailAlert
{
    class Program
    {
        static void Main()
        {
            Execute().Wait();
        }

        static async Task Execute()
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("notifier@acmecode.io", "AcmeCode Notifier");
            var subject = "FTP File Alert - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm") ;
            var to = new EmailAddress("kent.kingery@gmail.com", "Kent Kingery");
            var plainTextContent = "A file has been received by the system. The file name is " + Environment.GetEnvironmentVariable("FTP_FILENAME") + ".";
            var htmlContent = "A file has been received by the system. The file name is <strong>" + Environment.GetEnvironmentVariable("FTP_FILENAME") + "<strong>.";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            System.Console.WriteLine(response.StatusCode);
        }
    }
}
