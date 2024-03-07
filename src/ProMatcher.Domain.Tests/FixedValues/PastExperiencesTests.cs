using ProMatcher.Domain.FixedValues;

namespace ProMatcher.Domain.Tests.FixedValues
{
    public class PastExperiencesTests
    {
        [Fact]
        public void Create_ReturnsCorrectPastExperience_WhenSalesAndSupportAreTrue()
        {
            // Arrange & Act
            var pastExperience = PastExperiences.Create(true, true);

            // Assert
            Assert.Equal(2, pastExperience.FixedValueType); // Sales and Support combined
            Assert.Equal("Sales and Support", pastExperience.Description);
            Assert.Equal(8, pastExperience.ScorePoints); // Combined score points of Sales and Support
        }

        [Fact]
        public void Create_ReturnsSalesPastExperience_WhenSalesIsTrueAndSupportIsFalse()
        {
            // Arrange & Act
            var pastExperience = PastExperiences.Create(true, false);

            // Assert
            Assert.Equal(0, pastExperience.FixedValueType); // Sales
            Assert.Equal("Sales", pastExperience.Description);
            Assert.Equal(5, pastExperience.ScorePoints); // Sales score points
        }

        [Fact]
        public void Create_ReturnsSupportPastExperience_WhenSalesIsFalseAndSupportIsTrue()
        {
            // Arrange & Act
            var pastExperience = PastExperiences.Create(false, true);

            // Assert
            Assert.Equal(1, pastExperience.FixedValueType); // Support
            Assert.Equal("Support", pastExperience.Description);
            Assert.Equal(3, pastExperience.ScorePoints); // Support score points
        }

        [Fact]
        public void Create_ReturnsSupportPastExperience_WhenBothSalesAndSupportAreFalse()
        {
            // Arrange & Act
            var pastExperience = PastExperiences.Create(false, false);

            // Assert
            Assert.Equal(1, pastExperience.FixedValueType); // Support (default)
            Assert.Equal("Support", pastExperience.Description);
            Assert.Equal(3, pastExperience.ScorePoints); // Support score points (default)
        }
    }
}
