using ErrorOr;
using MediatR;
using TaskManagement.Application.Task.Common;

namespace TaskManagement.Application.Task.Commands.CreateTask
{
    public class CreateTaskCommand
       : IRequest<ErrorOr<TaskResultDto>>
    {
        public Guid UserId { get; set; }
        public string Description { get; set; }
        
    }
}
