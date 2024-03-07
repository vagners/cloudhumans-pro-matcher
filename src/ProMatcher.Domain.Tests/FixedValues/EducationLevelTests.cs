using ProMatcher.Domain.Exceptions;
using ProMatcher.Domain.FixedValues;

namespace ProMatcher.Domain.Tests.FixedValues
{
    public class EducationLevelTests
    {
        [Fact]
        public void ImplicitConversionFromString_ReturnsCorrectEducationLevel()
        {
            // Arrange
            string educationNo = "no_education";
            string educationHighSchool = "high_school";
            string educationBachelor = "bachelors_degree_or_high";

            // Act
            EducationLevel noEducation = educationNo;
            EducationLevel highSchool = educationHighSchool;
            EducationLevel bachelorDegree = educationBachelor;

            // Assert
            Assert.Equal(EEducationLevel.no_education, noEducation.FixedValueType);
            Assert.Equal(EEducationLevel.high_school, highSchool.FixedValueType);
            Assert.Equal(EEducationLevel.bachelors_degree_or_high, bachelorDegree.FixedValueType);
        }

        [Fact]
        public void ImplicitConversionFromString_ThrowsException_WhenValueIsNull()
        {
            // Arrange
            string? educationLevel = null;

            // Act & Assert
            var exception = Assert.Throws<FixedValueNotFoundException>(() => { EducationLevel result = educationLevel; });
            Assert.Contains("Value cannot be null", exception.Message);
        }

        [Fact]
        public void ImplicitConversionFromString_ThrowsException_WhenValueIsInvalid()
        {
            // Arrange
            string invalidEducationLevel = "invalid_level";

            // Act & Assert
            var exception = Assert.Throws<FixedValueNotFoundException>(() => { EducationLevel result = invalidEducationLevel; });
            Assert.Contains($"Value '{invalidEducationLevel}' not found in EducationLevel.", exception.Message);
        }
    }
}
