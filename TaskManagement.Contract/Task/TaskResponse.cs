namespace TaskManagement.Contract.Task
{
    public record TaskResponse(
        Guid Id,
        string Description,
        DateTime CreatedOnUtc,
        DateTime UpdatedOnUtc,
        bool IsActive,
        bool IsCompleted,
        Guid VersionId
    );
}
