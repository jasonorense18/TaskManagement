using ErrorOr;
using MediatR;
using TaskManagement.Application.Common.Interfaces.Persistence;
using TaskManagement.Application.Common.Services;
using TaskManagement.Application.Task.Common;
using TaskManagement.Domain.Common.Errors;

namespace TaskManagement.Application.Task.Commands.UpdateTask
{
    public sealed class UpdateTaskCommandHandler :
        IRequestHandler<UpdateTaskCommand, ErrorOr<TaskResultDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly ITaskRepository _taskRepository;
        private readonly IGuidProvider _guidProvider;

        public UpdateTaskCommandHandler(
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            ITaskRepository taskRepository,
            IGuidProvider guidProvider)
        {
            _dateTimeProvider = dateTimeProvider;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _taskRepository = taskRepository;
            _guidProvider = guidProvider;
        }

        public async Task<ErrorOr<TaskResultDto>> Handle(
            UpdateTaskCommand command, 
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
                return Errors.Task.TaskVersionConflictUpdate;
            }

            task.IsActive = command.IsActive;
            task.Description = command.Description;
            task.IsCompleted = command.IsCompleted;
            task.UpdatedOnUtc = _dateTimeProvider.UtcNow;
            task.VersionId = _guidProvider.NewGuid();

            _taskRepository.Update(task);
            _unitOfWork.SaveChanges();

            return new TaskResultDto(task);
        }
    }
}
