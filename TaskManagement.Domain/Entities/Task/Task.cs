namespace TaskManagement.Domain.Entities.Task
{
    public class Task
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public Guid VersionId { get; set; } = Guid.NewGuid();

        public virtual User.User User { get; set; }
    }
}
