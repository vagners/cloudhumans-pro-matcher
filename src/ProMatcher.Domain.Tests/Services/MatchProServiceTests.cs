using Moq;
using ProMatcher.Domain.Commands;
using ProMatcher.Domain.Entities;
using ProMatcher.Domain.FixedValues;
using ProMatcher.Domain.Repositories;
using ProMatcher.Domain.Services;
using ProMatcher.Domain.ValueObjects;

namespace ProMatcher.Domain.Tests.Services
{
    public class MatchProServiceTests
    {
        public Project[] _projects => new Project[]
        {
            new Project("calculate_dark_matter_nasa", 10),
            new Project("determine_schrodinger_cat_is_alive", 5),
            new Project("support_users_from_xyz", 3),
            new Project("collect_information_for_xpto", 2)
        };

        [Fact]
        public async Task MatchProToProject_ReturnsCorrectMatchProResult()
        {
            // Arrange
            var referralCodeRepositoryMock = new Mock<IReferralCodeRepository>();
            var projectRepositoryMock = new Mock<IProjectRepository>();

            var matchProCommand = new MatchProCommand(
                35,
                EducationLevel.HighSchool.Description,
                PastExperiences.Create(false, true),
                InternetTest.Create(50.4f, 40.2f),
                WritingScore.Create(0.6f),
                "token1234");

            var referralCode = new ReferralCode("token1234", true);
            referralCodeRepositoryMock.Setup(x => x.GetReferralCode(It.IsAny<string>())).ReturnsAsync(referralCode);

            projectRepositoryMock.Setup(x => x.GetAllProjects()).ReturnsAsync(_projects);

            var matchProService = new MatchProService(referralCodeRepositoryMock.Object, projectRepositoryMock.Object);

            // Act
            MatchProResult result = await matchProService.MatchProToProject(matchProCommand);

            // Assert
            Assert.Equal(7, result.Score);
            Assert.Equal(3, result.EligibleProjects.Count());
            Assert.Equal(5, result.SelectedProject.MinimalScoreRequired);
            Assert.NotNull(result.SelectedProject.Description);
            Assert.Equal(1, result.IneligibleProjects.Count());
        }

        [Fact]
        public async Task MatchProToProject_ReturnsCorrectMatchProResult_WithNullReferralCode()
        {
            // Arrange
            var referralCodeRepositoryMock = new Mock<IReferralCodeRepository>();
            var projectRepositoryMock = new Mock<IProjectRepository>();

            var matchProCommand = new MatchProCommand(
                35,
                EducationLevel.HighSchool.Description,
                PastExperiences.Create(false, true),
                InternetTest.Create(50.4f, 40.2f),
                WritingScore.Create(0.6f),
                null); // Null ReferralCode

            // Mocking GetReferralCode to return null
            referralCodeRepositoryMock.Setup(x => x.GetReferralCode(It.IsAny<string>())).ReturnsAsync((ReferralCode)null);

            projectRepositoryMock.Setup(x => x.GetAllProjects()).ReturnsAsync(_projects);

            var matchProService = new MatchProService(referralCodeRepositoryMock.Object, projectRepositoryMock.Object);

            // Act
            MatchProResult result = await matchProService.MatchProToProject(matchProCommand);

            // Assert
            Assert.Equal(6, result.Score);
            Assert.Equal(3, result.EligibleProjects.Count());
            Assert.Equal(5, result.SelectedProject.MinimalScoreRequired);
            Assert.Equal("determine_schrodinger_cat_is_alive", result.SelectedProject.Description);
            Assert.Equal(1, result.IneligibleProjects.Count());
        }
    }
}
