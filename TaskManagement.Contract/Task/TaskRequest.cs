namespace TaskManagement.Contract.Task
{
    public record TaskRequest(
        string Description,
        Guid? VersionId = null,
        bool? IsActive = null,
        bool? IsCompleted = null
        );
}
