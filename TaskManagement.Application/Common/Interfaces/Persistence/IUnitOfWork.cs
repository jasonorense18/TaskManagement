namespace TaskManagement.Application.Common.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
