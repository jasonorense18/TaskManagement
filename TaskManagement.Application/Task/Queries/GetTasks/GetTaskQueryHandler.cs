using ErrorOr;
using MediatR;
using TaskManagement.Application.Common.Interfaces.Persistence;
using TaskManagement.Application.Task.Common;
using TaskManagement.Domain.Common.Errors;

namespace TaskManagement.Application.Task.Queries.GetTasks
{
    public sealed class GetTaskQueryHandler :
        IRequestHandler<GetTaskQuery, ErrorOr<IEnumerable<TaskResultDto>>>
    {
        private readonly IUserRepository _userRepository;

        public GetTaskQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<IEnumerable<TaskResultDto>>> Handle(
            GetTaskQuery query, 
            CancellationToken cancellationToken)
        {
            await System.Threading.Tasks.Task.CompletedTask;

            var user = _userRepository.GetUserById(query.UserId);

            if (user is null)
            {
                return Errors.User.UserNotFound;
            }

            if (user.Tasks == null)
            {
                return new List<TaskResultDto>();
            }

            return user.Tasks.Select(task => new TaskResultDto(task)).ToList();

        }
    }
}
