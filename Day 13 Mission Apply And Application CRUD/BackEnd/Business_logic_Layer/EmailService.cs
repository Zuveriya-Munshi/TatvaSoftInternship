using System.Net.Mail;
using System.Threading.Tasks;

namespace Business_logic_Layer
{
    public class EmailService : IEmailService
    {
        public async Task SendForgotPasswordEmailAsync(string email, string resetLink)
        {
            using (var smtpClient = new SmtpClient())
            {
                var mailMessage = new MailMessage
                {
                    Subject = "Password Reset",
                    Body = $"Please reset your password using the following link: {resetLink}",
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(email);
                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}
