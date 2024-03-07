using ProMatcher.Domain.ValueObjects;

namespace ProMatcher.Domain.Tests.ValueObjects
{
    public class InternetTestTests
    {
        [Theory]
        [InlineData(60, 60, 2)] // Both download and upload speeds are above 50
        [InlineData(60, 20, 1)] // Download speed above 50, upload speed below 50
        [InlineData(20, 60, 1)] // Upload speed above 50, download speed below 50
        [InlineData(20, 20, 0)] // Both download and upload speeds are below 50
        [InlineData(5, 5, 0)]   // Both download and upload speeds are exactly 5
        [InlineData(4, 4, -2)]  // Both download and upload speeds are below 5
        public void Create_CalculatesCorrectScore(int downloadSpeed, int uploadSpeed, int expectedScore)
        {
            // Arrange & Act
            InternetTest internetTest = InternetTest.Create(downloadSpeed, uploadSpeed);

            // Assert
            Assert.Equal(expectedScore, internetTest.ScorePoints);
        }
    }
}
