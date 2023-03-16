using TaskManagement.Application.Common.Interfaces.Persistence;
using TaskManagement.Infrastructure.Persistence.Context;

namespace TaskManagement.Infrastructure.Persistence.Task
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _dbContext;

        public TaskRepository(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Domain.Entities.Task.Task task)
        {
            _dbContext.Tasks.Add(task);
        }

        public void Delete(Domain.Entities.Task.Task task)
        {
            _dbContext.Tasks.Remove(task);
        }

        public Domain.Entities.Task.Task GetTaskById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Entities.Task.Task task)
        {
            // no implemtation.
        }
    }
}
