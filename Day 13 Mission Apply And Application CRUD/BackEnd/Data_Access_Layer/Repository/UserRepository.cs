using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.User.SingleOrDefaultAsync(u => u.EmailAddress == email);
        }

        public async Task AddForgotPasswordRequestAsync(ForgotPassword forgotPassword)
        {
            await _context.ForgotPasswords.AddAsync(forgotPassword);
            await _context.SaveChangesAsync();
        }

        public async Task<ForgotPassword> GetForgotPasswordRequestAsync(string id)
        {
            return await _context.ForgotPasswords.SingleOrDefaultAsync(f => f.Id == id);
        }

        public async Task UpdateUserPasswordAsync(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
