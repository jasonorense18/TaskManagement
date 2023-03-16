using ErrorOr;
using MediatR;
using TaskManagement.Application.Authentication.Common;
using TaskManagement.Application.Common.Interfaces.Authentication;
using TaskManagement.Application.Common.Interfaces.Persistence;
using TaskManagement.Domain.Common.Errors;

namespace TaskManagement.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler :
    IRequestHandler<LoginQuery, ErrorOr<AuthenticationResultDto>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(
            IUserRepository userRepository,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResultDto>> Handle(
            LoginQuery query,
            CancellationToken cancellationToken)
        {
            await System.Threading.Tasks.Task.CompletedTask;

            if (_userRepository.GetUserByEmail(query.Email) is not Domain.Entities.User.User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            if (user.Password != query.Password)
            {
                return new[] { Errors.Authentication.InvalidCredentials };
            }

            string token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResultDto(
                user,
                token);
        }
    }
}
