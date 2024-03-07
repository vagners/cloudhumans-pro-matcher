using ProMatcher.Domain.Entities;
using ProMatcher.Domain.ValueObjects;

namespace ProMatcher.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjects();
    }
}
