using System.Threading.Tasks;

namespace Business_logic_Layer
{
    public interface IUserService
    {
        Task ForgotPasswordAsync(string email, string baseUrl);
        Task<bool> ResetPasswordAsync(string token, string newPassword);
    }
}
