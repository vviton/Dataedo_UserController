using Dataedo_UserController.Models;
using System.Diagnostics;

namespace Dataedo_UserController.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(uint id)
        {
            User? user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return 0;
            }
            else
            {
                _context.Users.Remove(user);
                var usersDeleted = await _context.SaveChangesAsync();
                Debug.WriteLine($"The user with Login = {user.Login} has been deleted");
                return usersDeleted;
            }
        }
    }
}
