namespace TaskManagement.Infrastructure.Persistence.Context.Common
{
    public sealed class TaskDbSettings
    {
        public const string SectionName = "TaskDbSettings";
        public const string DbConnectionString = "TaskDbConnectionString";
        public string UserTableName { get; set; } = null!;
        public string TaskTableName { get; set; } = null!;
    }
}