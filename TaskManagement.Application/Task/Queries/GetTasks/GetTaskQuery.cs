using ErrorOr;
using MediatR;
using TaskManagement.Application.Task.Common;

namespace TaskManagement.Application.Task.Queries.GetTasks
{
    public record GetTaskQuery(Guid UserId) : 
        IRequest<ErrorOr<IEnumerable<TaskResultDto>>>;
}
