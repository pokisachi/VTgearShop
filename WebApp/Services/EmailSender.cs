using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;

namespace WebApp.Services;
public class EmailSender : IEmailSender{
    MailSettings settings;
    public EmailSender(IOptions<MailSettings> options){
         settings = options.Value;
         } 
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        using SmtpClient client = new SmtpClient{
            Host = settings.Host,
            EnableSsl = true,
            Port = settings.Port,
            Credentials = new NetworkCredential(
                settings.Email,
                settings.Password
                
            )
        };
        MailMessage message = new MailMessage{
            Subject = subject,
            Body = htmlMessage,
            From = new MailAddress(settings.Email),
            IsBodyHtml = true
            
        };
        message.To.Add(new MailAddress(email));
        await client.SendMailAsync(message);
    }
}