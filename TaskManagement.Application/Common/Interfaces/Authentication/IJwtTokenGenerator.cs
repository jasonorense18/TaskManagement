using TaskManagement.Domain.Entities.User;

namespace TaskManagement.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);

    }
}
