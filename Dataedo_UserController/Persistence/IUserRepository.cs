using Dataedo_UserController.Models;

namespace Dataedo_UserController.Persistence
{
    public interface IUserRepository
    {
        public Task AddAsync(User entity);
        public Task<int> DeleteAsync(uint id);
    }
}
