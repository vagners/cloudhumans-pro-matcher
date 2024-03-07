using ProMatcher.Domain.Exceptions;
using ProMatcher.Domain.ValueObjects;

namespace ProMatcher.Domain.Tests.ValueObjects
{
    public class AgeTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        public void Constructor_ThrowsException_WhenValueIsNegative(int value)
        {
            // Arrange & Act & Assert
            Assert.Throws<BusinessException>(() => new Age(value));
        }

        [Fact]
        public void Constructor_ThrowsException_WhenValueIsUnderEighteen()
        {
            // Arrange & Act & Assert
            Assert.Throws<BusinessException>(() => new Age(17));
        }

        [Fact]
        public void Constructor_DoesNotThrowException_WhenValueIsEqualToEighteen()
        {
            // Arrange & Act
            Age age = new Age(18);

            // Assert
            Assert.Equal(18, age.Value);
        }

        [Fact]
        public void Constructor_DoesNotThrowException_WhenValueIsGreaterThanEighteen()
        {
            // Arrange & Act
            Age age = new Age(25);

            // Assert
            Assert.Equal(25, age.Value);
        }
    }
}
