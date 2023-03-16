using ErrorOr;
using MediatR;
using TaskManagement.Application.Common.Interfaces.Persistence;
using TaskManagement.Application.Common.Services;
using TaskManagement.Application.Task.Common;
using TaskManagement.Domain.Common.Errors;

namespace TaskManagement.Application.Task.Commands.CreateTask
{
    public sealed class CreateTaskCommandHandler :
        IRequestHandler<CreateTaskCommand, ErrorOr<TaskResultDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITaskRepository _taskRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateTaskCommandHandler(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            ITaskRepository taskRepository,
            IDateTimeProvider dateTimeProvider)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _taskRepository = taskRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<ErrorOr<TaskResultDto>> Handle(
            CreateTaskCommand command, 
            CancellationToken cancellationToken)
        {
            await System.Threading.Tasks.Task.CompletedTask;

            if (_userRepository.GetUserById(command.UserId) is null)
            {
                return Errors.User.UserNotFound;
            }

            var newTask = new Domain.Entities.Task.Task
            {
                UserId = command.UserId,
                CreatedOnUtc = _dateTimeProvider.UtcNow,
                UpdatedOnUtc = _dateTimeProvider.UtcNow,
                IsActive = true,
                IsCompleted = false,
                Description = command.Description,
            };

            _taskRepository.Add(newTask);
            _unitOfWork.SaveChanges();

            return new TaskResultDto(newTask);
        }
    }
}
