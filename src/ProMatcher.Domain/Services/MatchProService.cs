using ProMatcher.Domain.Commands;
using ProMatcher.Domain.Entities;
using ProMatcher.Domain.Repositories;
using ProMatcher.Domain.ValueObjects;

namespace ProMatcher.Domain.Services
{
    public class MatchProService
    {
        private readonly IReferralCodeRepository _referralCodeRepository;
        private readonly IProjectRepository _projectRepository;

        public MatchProService(IReferralCodeRepository referralCodeRepository, IProjectRepository projectRepository)
        {
            _referralCodeRepository = referralCodeRepository;
            _projectRepository = projectRepository;
        }

        public async Task<MatchProResult> MatchProToProject(MatchProCommand matchProCommand)
        {
            //Includes information if it is valid from the repository.
            matchProCommand.ReferralCode = await GetValidReferralCode(matchProCommand.ReferralCode);
            var score = CalculateTotalScore(matchProCommand);

            //TODO: Possible improvement: Do not fetch the "ineligible_projects" as this results in a "full scan" of the database, verify the necessity of displaying this information.
            var projects = await _projectRepository.GetAllProjects();

            var eligibleProjects = projects.Where(x => score > x.MinimalScoreRequired);
            var selectedProject = GetSelectProjectFromEligibleProjects(eligibleProjects);
            var ineligibleProjects = projects.Except(eligibleProjects);


            return new MatchProResult
            {
                Score = score,
                EligibleProjects = eligibleProjects,
                IneligibleProjects = ineligibleProjects,
                SelectedProject = selectedProject
            };
        }

        private async Task<ReferralCode> GetValidReferralCode(ReferralCode referralCode)
        {
            if (referralCode != null)
            {
                return await _referralCodeRepository.GetReferralCode(referralCode.Value);
            }
            return null;
        }

        private int CalculateTotalScore(MatchProCommand matchProCommand)
        {
            int score = 0;
            score += matchProCommand.EducationLevel?.ScorePoints ?? 0;
            score += matchProCommand.WritingScore?.ScorePoints ?? 0;
            score += matchProCommand.ReferralCode?.ScorePoints ?? 0;
            score += matchProCommand.PastExperiences?.ScorePoints ?? 0;
            score += matchProCommand.InternetTest?.ScorePoints ?? 0;
            return score;
        }

        private Project GetSelectProjectFromEligibleProjects(IEnumerable<Project> eligibleProjects)
        {
            return eligibleProjects.OrderByDescending(p => p.MinimalScoreRequired).FirstOrDefault();
        }
    }
}
