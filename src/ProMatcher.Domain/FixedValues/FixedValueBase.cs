using ProMatcher.Domain.ValueObejcts;

namespace ProMatcher.Domain.FixedValues
{
    public abstract class FixedValueBase<T> : ScorePointsBase
    {
        public FixedValueBase(T fixedValueType, string description)
        {
            FixedValueType = fixedValueType;
            Description = description;
        }

        public T FixedValueType { get; }
        public string Description { get; }

        
    }
}
