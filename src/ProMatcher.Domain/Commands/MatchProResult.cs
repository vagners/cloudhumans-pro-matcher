using ProMatcher.Domain.Entities;

namespace ProMatcher.Domain.Commands
{
    public class MatchProResult
    {
        public int Score { get; set; }
        public Project SelectedProject { get; set; }
        public IEnumerable<Project> EligibleProjects { get; set; }
        public IEnumerable<Project> IneligibleProjects { get; set; }
    }
}
