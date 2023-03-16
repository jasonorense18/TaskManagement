using ErrorOr;
using MediatR;
using TaskManagement.Application.Common.Interfaces.Persistence;
using TaskManagement.Application.Task.Common;
using TaskManagement.Domain.Common.Errors;

namespace TaskManagement.Application.Task.Queries.GetTaskById
{
    public sealed class GetTaskByIdQueryHandler :
        IRequestHandler<GetTaskByIdQuery, ErrorOr<TaskResultDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetTaskByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<TaskResultDto>> Handle(
            GetTaskByIdQuery query, 
            CancellationToken cancellationToken)
        {
            await System.Threading.Tasks.Task.CompletedTask;

            var user = _userRepository.GetUserById(query.UserId);

            if (user is null)
            {
                return Errors.User.UserNotFound;
            }

            if (user.Tasks is null)
            {
                return Errors.Task.TaskNotFound;
            }

            var task = user.Tasks.FirstOrDefault(a => a.Id == query.TaskId);

            if (task is null)
            {
                return Errors.Task.TaskNotFound;
            }

            return new TaskResultDto(task);
        }
    }
}
