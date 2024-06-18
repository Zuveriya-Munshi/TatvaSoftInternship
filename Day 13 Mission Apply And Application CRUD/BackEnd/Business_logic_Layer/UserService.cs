using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;
using System;
using System.Threading.Tasks;

namespace Business_logic_Layer
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public UserService(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task ForgotPasswordAsync(string email, string baseUrl)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var forgotPassword = new ForgotPassword
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id,
                RequestDateTime = DateTime.UtcNow
            };

            await _userRepository.AddForgotPasswordRequestAsync(forgotPassword);

            var resetLink = $"{baseUrl}/reset-password?token={forgotPassword.Id}";
            await _emailService.SendForgotPasswordEmailAsync(email, resetLink);
        }

        public async Task<bool> ResetPasswordAsync(string token, string newPassword)
        {
            var forgotPasswordRequest = await _userRepository.GetForgotPasswordRequestAsync(token);
            if (forgotPasswordRequest == null || (DateTime.UtcNow - forgotPasswordRequest.RequestDateTime).TotalHours > 24)
            {
                return false;
            }

            var user = await _userRepository.GetUserByEmailAsync(forgotPasswordRequest.EmailAddress);
            if (user == null)
            {
                return false;
            }

            user.Password = newPassword; // Hash the password in a real scenario
            await _userRepository.UpdateUserPasswordAsync(user);
            return true;
        }
    }
}
