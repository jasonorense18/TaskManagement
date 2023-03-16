using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using TaskManagement.Infrastructure.Persistence.Context.Common;

namespace TaskManagement.Infrastructure.Persistence.Task
{
    internal sealed class TaskConfiguration
        : IEntityTypeConfiguration<Domain.Entities.Task.Task>
    {
        private readonly TaskDbSettings _taskSettings;
        public TaskConfiguration(IOptions<TaskDbSettings> options)
        {
            _taskSettings = options.Value;
        }
        public void Configure(EntityTypeBuilder<Domain.Entities.Task.Task> builder)
        {
            builder.ToTable(_taskSettings.TaskTableName);
            builder.HasKey(t => t.Id);

            builder
                .HasOne(a => a.User)
                .WithMany(a => a.Tasks)
                .HasForeignKey(a => a.UserId);

            builder.Property(t => t.VersionId)
                .IsConcurrencyToken();

            builder.UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
