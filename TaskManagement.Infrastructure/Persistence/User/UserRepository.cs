using System.Net.Mail;
using TaskManagement.Application.Common.Interfaces.Persistence;
using TaskManagement.Infrastructure.Persistence.Context;

namespace TaskManagement.Infrastructure.Persistence.User
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskDbContext _dbContext;

        public UserRepository(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Domain.Entities.User.User user)
        {
            _dbContext.Users.Add(user);
        }

        public Domain.Entities.User.User? GetUserByEmail(string emailAddress)
        {
            return _dbContext.Users
                .FirstOrDefault(a => a.Email == emailAddress);
        }

        public Domain.Entities.User.User? GetUserById(Guid id)
        {
            return _dbContext.Users
                .FirstOrDefault(a => a.Id == id);
        }
    }
}
