using TaskManagement.Application.Common.Interfaces.Persistence;

namespace TaskManagement.Infrastructure.Persistence.Context.Common
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly TaskDbContext _dbContext;

        public UnitOfWork(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
