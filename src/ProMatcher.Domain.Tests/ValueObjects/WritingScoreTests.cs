using ProMatcher.Domain.Exceptions;
using ProMatcher.Domain.ValueObjects;

namespace ProMatcher.Domain.Tests.ValueObjects
{
    public class WritingScoreTests
    {
        [Theory]
        [InlineData(-0.1)] // Score abaixo do limite inferior
        [InlineData(1.1)]  // Score acima do limite superior
        public void Constructor_ThrowsException_WhenScoreIsOutOfRange(float score)
        {
            // Arrange & Act & Assert
            Assert.Throws<BusinessException>(() => WritingScore.Create(score));
        }

        [Theory]
        [InlineData(0, -1)]  // Score zero
        [InlineData(0.2f, -1)]  // Score abaixo de 0.3
        [InlineData(0.3f, 1)]  // Score igual a 0.3
        [InlineData(0.5f, 1)]  // Score entre 0.3 e 0.7
        [InlineData(0.7f, 1)]  // Score igual a 0.7
        [InlineData(0.8f, 2)]  // Score acima de 0.7
        [InlineData(1, 2)]  // Score máximo permitido
        public void Constructor_SetsCorrectScorePoints(float score, int expectedScorePoints)
        {
            // Arrange & Act
            WritingScore writingScore = WritingScore.Create(score);

            // Assert
            Assert.Equal(expectedScorePoints, writingScore.ScorePoints);
        }

        [Fact]
        public void Create_ReturnsWritingScoreInstance()
        {
            // Arrange
            float score = 0.5f;

            // Act
            WritingScore writingScore = WritingScore.Create(score);

            // Assert
            Assert.NotNull(writingScore);
            Assert.IsType<WritingScore>(writingScore);
        }
    }
}
