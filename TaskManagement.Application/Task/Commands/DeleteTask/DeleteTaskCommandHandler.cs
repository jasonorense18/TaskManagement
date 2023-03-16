using ErrorOr;
using MediatR;
using TaskManagement.Application.Common.Interfaces.Persistence;
using TaskManagement.Domain.Common.Errors;

namespace TaskManagement.Application.Task.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler :
        IRequestHandler<DeleteTaskCommand, ErrorOr<Deleted>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTaskCommandHandler(
            IUnitOfWork unitOfWork, 
            IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<Deleted>> Handle(
            DeleteTaskCommand command, 
            CancellationToken cancellationToken)
        {
            await System.Threading.Tasks.Task.CompletedTask;

            var user = _userRepository.GetUserById(command.UserId);

            if (user is null)
            {
                return Errors.User.UserNotFound;
            }

            if (user.Tasks is null)
            {
                return Errors.Task.TaskNotFound;
            }

            var task = user.Tasks.FirstOrDefault(a => a.Id == command.TaskId);

            if (task is null)
            {
                return Errors.Task.TaskNotFound;
            }

            if (task.VersionId != command.VersionId)
            {
                return Errors.Task.TaskVersionConflictDelete;
            }


            user.Tasks.Remove(task);
            _unitOfWork.SaveChanges();

            return Result.Deleted;

        }
    }
}
