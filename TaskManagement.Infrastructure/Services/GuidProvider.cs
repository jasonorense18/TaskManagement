using TaskManagement.Application.Common.Services;

namespace TaskManagement.Infrastructure.Services
{
    public class GuidProvider : IGuidProvider
    {
        public Guid NewGuid()
        {
            return Guid.NewGuid();
        }
    }
}
