using TaskManagement.Domain.Entities.User;

namespace TaskManagement.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        void Add(User user);
        User? GetUserByEmail(string emailAddress);
        User? GetUserById(Guid id);
    }
}
