namespace ProMatcher.Domain.Exceptions
{
    public class FixedValueNotFoundException : Exception
    {
        public FixedValueNotFoundException() : base("Value cannot be null")
        { }

        public FixedValueNotFoundException(string fixedValueType, Exception exception) : base($"Value '{fixedValueType}' not found in EducationLevel.", exception)
        { }
    }
}
