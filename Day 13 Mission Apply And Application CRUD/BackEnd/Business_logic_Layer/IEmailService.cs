using System.Threading.Tasks;

namespace Business_logic_Layer
{
    public interface IEmailService
    {
        Task SendForgotPasswordEmailAsync(string email, string resetLink);
    }
}
