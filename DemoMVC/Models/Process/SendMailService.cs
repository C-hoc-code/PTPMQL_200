using MailKit.Net.Smtp;
using MailKit;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MailKit.Security;
using MimeKit;
namespace DemoMVC.Models.Process
{
    public class SendMailService : IEmailSender
    {
        private readonly MailSettings mailSettings;
        private readonly ILogger<SendMailService> logger;
        public SendMailService(IOptions<MailSettings> _mailSettings, ILogger<SendMailService> _logger) 
        {
            mailSettings = _mailSettings.Value;
            logger = _logger;
            logger.LogInformation("Tạo dịch vụ gửi Mail");
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.Sender = new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail);
            message.From.Add(new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = htmlMessage;
            message.Body = builder.ToMessageBody();
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(mailSettings.Mail, mailSettings.Password);
                await smtp.SendAsync(message);
            }
            catch (Exception ex)
            {
                // Gửi mail thất bại, nội dung email sẽ lưu vào thư mục mailsSave
                System.IO.Directory.CreateDirectory("mailsSave");
                var emailSaveFile = string.Format(@"mailsSave/{0}.eml", Guid.NewGuid());
                await message.WriteToAsync(emailSaveFile);

                logger.LogInformation("Gặp lỗi khi gửi mail, lưu tại - ", emailSaveFile);
                logger.LogError(ex.Message);
            }
            smtp.Disconnect(true);
            logger.LogInformation("Đã gửi mail tới: "+ email);
        }
        
    }
}
