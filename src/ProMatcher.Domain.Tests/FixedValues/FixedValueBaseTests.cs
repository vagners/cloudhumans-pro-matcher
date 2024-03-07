using ProMatcher.Domain.FixedValues;

namespace ProMatcher.Domain.Tests.FixedValues
{
    public class FixedValueBaseTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            const int fixedValueType = 1;
            const string description = "Test Description";

            // Act
            var fixedValue = new TestFixedValue(fixedValueType, description);

            // Assert
            Assert.Equal(fixedValueType, fixedValue.FixedValueType);
            Assert.Equal(description, fixedValue.Description);
        }

        private class TestFixedValue : FixedValueBase<int>
        {
            public TestFixedValue(int fixedValueType, string description) : base(fixedValueType, description)
            {
            }
        }
    }
}
