using ProMatcher.Domain.Exceptions;

namespace ProMatcher.Domain.ValueObejcts
{
    public class Age
    {
        public Age(int value)
        {
            if (value < 0)
                throw new BusinessException("Age must be an integer equal or greater than 0");

            if (value < 18)
                throw new BusinessException("Pro is under age, she is ineligible to be paired with any project");

            Value = value;
        }

        public int Value { get; set; }

        public static implicit operator Age(int value) => new Age(value);
    }
}
