using System.Net;
using System.Net.Mail;

namespace CutieShop.API.Models.Utils
{
    public static class MailUtils
    {
        public static void Send(string userId, string email, string subject, string body)
        {
            var mail = new MailMessage();
            var client = new SmtpClient("mail.smtp2go.com", 2525) //Port 8025, 587 and 25 can also be used.
            {
                Credentials = new NetworkCredential("Vivu Travel", "vnhcmute"),
                EnableSsl = true
            };
            mail.From = new MailAddress("vivu_travel@smtpservice.net");
            mail.To.Add(email);
            mail.Subject = subject;
            var htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            var plainView = AlternateView.CreateAlternateViewFromString(subject, null, "text/plain");
            mail.AlternateViews.Add(htmlView);
            mail.AlternateViews.Add(plainView);
            client.Send(mail);
        }
    }
}
