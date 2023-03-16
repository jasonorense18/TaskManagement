using Mapster;
using TaskManagement.Application.Authentication.Commands.Register;
using TaskManagement.Application.Authentication.Common;
using TaskManagement.Application.Authentication.Queries.Login;
using TaskManagement.Contract.Authentication;

namespace TaskManagement.Api.Common.Mapping
{
    public sealed class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<
                AuthenticationResultDto,
                AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}
