using ProMatcher.Domain.Exceptions;

namespace ProMatcher.Domain.FixedValues
{
    public class PastExperiences : FixedValueBase<int>
    {
        public static PastExperiences Sales = new PastExperiences(0, "Sales", 5);
        public static PastExperiences Support = new PastExperiences(1, "Support", 3);
        public static PastExperiences SalesAndSupport = new PastExperiences(2, "Sales and Support", Sales.ScorePoints + Support.ScorePoints);

        public PastExperiences(int fixedValueType, string description, int scorePoints) : base(fixedValueType, description)
        {
            ScorePoints = scorePoints;
        }

        public static PastExperiences Create(bool sales, bool support)
        {
            if (sales && support)
                return SalesAndSupport;
            else if (sales)
                return Sales;
            else
                return Support;
        }
    }
}
