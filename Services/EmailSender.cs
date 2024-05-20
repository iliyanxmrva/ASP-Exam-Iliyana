using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Identity.UI.Services;
using asp_exam_iliyana.Models.SettingsModels;

namespace asp_exam_iliyana.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IOptions<SMTPSettings> _smtpSettings;

        public EmailSender(IOptions<SMTPSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using (var smtpClient = new SmtpClient(_smtpSettings.Value.Host, _smtpSettings.Value.Port))
            {
                smtpClient.Credentials = new NetworkCredential(_smtpSettings.Value.User, _smtpSettings.Value.Password);

                await smtpClient.SendMailAsync(_smtpSettings.Value.User, email, subject, htmlMessage);
            }
        }
    }
}
