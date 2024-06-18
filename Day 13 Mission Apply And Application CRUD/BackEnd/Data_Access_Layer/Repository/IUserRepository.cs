using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Repository.Entities;

namespace Data_Access_Layer.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task AddForgotPasswordRequestAsync(ForgotPassword forgotPassword);
        Task<ForgotPassword> GetForgotPasswordRequestAsync(string id);
        Task UpdateUserPasswordAsync(User user);
    }
}
