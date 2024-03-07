using ProMatcher.Domain.ValueObjects;

namespace ProMatcher.Domain.Tests.ValueObjects
{
    public class ReferralCodeTests
    {
        [Fact]
        public void Constructor_SetsValueAndValidCorrectly()
        {
            // Arrange
            string code = "token1234";
            bool valid = true;

            // Act
            ReferralCode referralCode = new ReferralCode(code, valid);

            // Assert
            Assert.Equal(code, referralCode.Value);
            Assert.Equal(valid, referralCode.Valid);
        }

        [Fact]
        public void Constructor_SetsScorePointsToOne_WhenCodeIsValid()
        {
            // Arrange
            string code = "token1234";
            bool valid = true;

            // Act
            ReferralCode referralCode = new ReferralCode(code, valid);

            // Assert
            Assert.Equal(1, referralCode.ScorePoints);
        }

        [Fact]
        public void Constructor_SetsScorePointsToZero_WhenCodeIsNotValid()
        {
            // Arrange
            string code = "REF456";
            bool valid = false;

            // Act
            ReferralCode referralCode = new ReferralCode(code, valid);

            // Assert
            Assert.Equal(0, referralCode.ScorePoints);
        }

        [Fact]
        public void ImplicitConversionFromString_SetsValueCorrectly()
        {
            // Arrange
            string code = "REF789";

            // Act
            ReferralCode referralCode = code;

            // Assert
            Assert.Equal(code, referralCode.Value);
        }

        [Fact]
        public void ImplicitConversionFromString_SetsValidToFalse()
        {
            // Arrange
            string code = "REF789";

            // Act
            ReferralCode referralCode = code;

            // Assert
            Assert.False(referralCode.Valid);
        }

        [Fact]
        public void Constructor_SetsValueToNull_AndValidToFalse_WhenCodeIsNull()
        {
            // Arrange
            string code = null;

            // Act
            ReferralCode referralCode = new ReferralCode(code, false);

            // Assert
            Assert.Null(referralCode.Value);
            Assert.False(referralCode.Valid);
            Assert.Equal(0, referralCode.ScorePoints);
        }
    }
}
