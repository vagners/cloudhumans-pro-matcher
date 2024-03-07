using ProMatcher.Domain.Entities;
using ProMatcher.Domain.Repositories;
using ProMatcher.Domain.ValueObejcts;

namespace ProMatcher.Infra.Repositories
{

    public class ProjectRepository : IProjectRepository
    {
        private Project[] _repositoryOfProjects => new Project[]
        {
                new Project("calculate_dark_matter_nasa", 10),
                new Project("determine_schrodinger_cat_is_alive", 5),
                new Project("support_users_from_xyz", 3),
                new Project("collect_information_for_xpto", 2)
        };

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return _repositoryOfProjects;
        }
    }
}
