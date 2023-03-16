using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Infrastructure.Persistence.Context
{
    public sealed class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions dbContextOptions)
           : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Auto Register all class that implementing IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskDbContext).Assembly);
        }

        public DbSet<Domain.Entities.User.User> Users { get; set; }
        public DbSet<Domain.Entities.Task.Task> Tasks { get; set; }
    }
}
