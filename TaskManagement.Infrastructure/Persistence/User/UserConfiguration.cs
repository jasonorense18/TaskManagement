using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using TaskManagement.Infrastructure.Persistence.Context.Common;

namespace TaskManagement.Infrastructure.Persistence.User
{
    internal sealed class UserConfiguration :
        IEntityTypeConfiguration<Domain.Entities.User.User>
    {
        private readonly TaskDbSettings _taskSettings;
        public UserConfiguration(IOptions<TaskDbSettings> options)
        {
            _taskSettings = options.Value;
        }

        public void Configure(EntityTypeBuilder<Domain.Entities.User.User> builder)
        {
            builder.ToTable(_taskSettings.UserTableName);
            builder.HasKey(t => t.Id);

            builder
                .HasMany(a => a.Tasks)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            builder.UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
