namespace ProMatcher.Domain.Exceptions
{
    public class FixedValueNotFoundException : Exception
    {
        public FixedValueNotFoundException() : base($"TypeNotMatch")
        { }

        public FixedValueNotFoundException(string fixedValueType, Exception exception) : base($"Type not found {fixedValueType}", exception)
        { }
    }
}
