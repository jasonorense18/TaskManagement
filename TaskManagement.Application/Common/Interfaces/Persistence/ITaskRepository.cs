namespace TaskManagement.Application.Common.Interfaces.Persistence
{
    public interface ITaskRepository
    {
        Domain.Entities.Task.Task GetTaskById(Guid id);
        void Add(Domain.Entities.Task.Task task);
        void Update(Domain.Entities.Task.Task task);
        void Delete(Domain.Entities.Task.Task task);
    }
}
