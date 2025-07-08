using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using Mini_E_Ticarət_API.Application.Shared.Settings;
using Mini_E_Ticarət_API.Application.Abstracts.Services;



namespace Mini_E_Ticarət_API.Infrastructure.Services;

public class EmailService : IEmailService
{
    private EmailSettings _emailSettings { get; }

    public EmailService(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    public async Task SendEmailAsync(IEnumerable<string> toEmails, string subject, string body)
    {
        using var smtp = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort)
        {
            Credentials = new NetworkCredential(_emailSettings.SenderEmail, _emailSettings.Password),
            EnableSsl = true
        };

        var message = new MailMessage
        {
            From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };

        foreach (var email in toEmails)
        {
            message.To.Add(email);
        }

        await smtp.SendMailAsync(message);
    }

}
