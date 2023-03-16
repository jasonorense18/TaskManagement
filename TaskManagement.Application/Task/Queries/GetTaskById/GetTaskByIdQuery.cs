using ErrorOr;
using MediatR;
using TaskManagement.Application.Task.Common;

namespace TaskManagement.Application.Task.Queries.GetTaskById
{
    public record GetTaskByIdQuery(
        Guid UserId,
        Guid TaskId): IRequest<ErrorOr<TaskResultDto>>;
}
