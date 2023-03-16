using ErrorOr;
using MediatR;
using TaskManagement.Application.Task.Common;

namespace TaskManagement.Application.Task.Commands.UpdateTask
{
    public class UpdateTaskCommand :
        IRequest<ErrorOr<TaskResultDto>>
    {
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsCompleted { get; set; }
        public Guid VersionId { get; set; }
    }
}
