using ProMatcher.Domain.Commands;
using ProMatcher.Domain.ValueObejcts;

namespace ProMatcher.Api.Models
{
    public class MatchProMapper
    {
        public static MatchProCommand MapFromRequest(MatchProRequest request)
        {
            return new MatchProCommand(
                request.Age,
                request.EducationLevel,
                Domain.FixedValues.PastExperiences.Create(request.PastExperiences.Sales, request.PastExperiences.Support),
                Domain.ValueObejcts.InternetTest.Create(request.InternetTest.DownloadSpeed, request.InternetTest.UploadSpeed),
                WritingScore.Create(request.WritingScore),
                request.ReferralCode);
        }

        public static MatchProResponse MapFromResult(MatchProResult result)
        {
            return new MatchProResponse
            {
                Score = result.Score,
                SelectedProject = result.SelectedProject.Description,
                EligibleProjects = result.EligibleProjects.Select(x => x.Description),
                IneligibleProjects= result.IneligibleProjects.Select(x => x.Description)
            };
        }
    }
}
