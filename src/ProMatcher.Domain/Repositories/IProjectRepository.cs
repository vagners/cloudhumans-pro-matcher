using ProMatcher.Domain.Entities;
using ProMatcher.Domain.ValueObejcts;

namespace ProMatcher.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjects();
    }
}
