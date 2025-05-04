using Cafe.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Cafe.DAL.Repositories
{
    public class UserRepository
    {
        private readonly CafeDbContext _context;

        public UserRepository(CafeDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}