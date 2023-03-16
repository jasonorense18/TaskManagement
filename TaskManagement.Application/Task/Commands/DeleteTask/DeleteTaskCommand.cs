using ErrorOr;
using MediatR;

namespace TaskManagement.Application.Task.Commands.DeleteTask
{
    public record DeleteTaskCommand(
        Guid UserId,
        Guid? VersionId,
        Guid TaskId) : IRequest<ErrorOr<Deleted>>;
    
}
