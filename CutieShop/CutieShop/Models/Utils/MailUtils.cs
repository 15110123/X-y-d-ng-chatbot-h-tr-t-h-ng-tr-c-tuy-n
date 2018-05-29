using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CutieShop.Models.Utils
{
    public static class MailUtils
    {
        public static async Task Send(string email, string subject, string body)
        {
            var mail = new MailMessage();
            var client = new SmtpClient("mail.smtp2go.com", 2525) //Port 8025, 587 and 25 can also be used.
            {
                Credentials = new NetworkCredential("hcmute", "spkt2015"),
                EnableSsl = true
            };
            mail.From = new MailAddress("cutieshop@smtpservice.net");
            mail.To.Add(email);
            mail.Subject = subject;
            var htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            //var plainView = AlternateView.CreateAlternateViewFromString(body, null, "text/plain");
            mail.AlternateViews.Add(htmlView);
            //mail.AlternateViews.Add(plainView);
            await client.SendMailAsync(mail);
        }
    }
}
