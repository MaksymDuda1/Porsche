using System.Net.Mail;
using MailKit;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using IMailService = Porsche.Application.Abstractions.IMailService;



namespace Porsche.Application.Services;

public class MailService : IMailService
{
    public async Task SendEmailToManager(string identityCode, string userEmail)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("YourPorscheManager@outlook.com"));
        email.To.Add(MailboxAddress.Parse("YourPorscheManager@outlook.com"));
        email.Subject = "New Order";
        email.Body = new TextPart(TextFormat.Html)
        {
            Text = $"User {userEmail} is interested" +
                   $" in {identityCode} car"
        };

        using (var smtp = new SmtpClient())
        {
           await smtp.ConnectAsync("smtp.outlook.com", 587, SecureSocketOptions.StartTls);
           await smtp.AuthenticateAsync("YourPorscheManager@outlook.com", "Deodorantstick1");
           await smtp.SendAsync(email);
           await smtp.DisconnectAsync(true);
        }
    }
    public async Task SendEmailToUser(string userEmail, string username)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("YourPorscheManager@outlook.com"));
        email.To.Add(MailboxAddress.Parse(userEmail));
        email.Subject = "New order";
        email.Body = new TextPart(TextFormat.Html)
        {
            Text = $"Hello, {username} we received information about your interest to our car " +
                   $" our manager will  manager and will contact you shortly "
        };

        using (var smtp = new SmtpClient())
        {
            await smtp.ConnectAsync("smtp.outlook.com", 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync("YourPorscheManager@outlook.com", "Deodorantstick1");
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
    
}