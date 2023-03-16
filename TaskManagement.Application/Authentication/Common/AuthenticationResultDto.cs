namespace TaskManagement.Application.Authentication.Common
{
    public record AuthenticationResultDto(
        Domain.Entities.User.User User, 
        string Token
        );
}
