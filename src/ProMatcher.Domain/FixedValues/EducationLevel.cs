using ProMatcher.Domain.Exceptions;

namespace ProMatcher.Domain.FixedValues
{
    public enum EEducationLevel
    {
        no_education = 1,
        high_school = 2,
        bachelors_degree_or_high = 3
    }

    public class EducationLevel : FixedValueBase<EEducationLevel>
    {
        public static EducationLevel NoEducation = new EducationLevel(EEducationLevel.no_education, "no_education", 0);
        public static EducationLevel HighSchool = new EducationLevel(EEducationLevel.high_school, "high_school", 1);
        public static EducationLevel BachelorsDegreeOrHigh = new EducationLevel(EEducationLevel.bachelors_degree_or_high, "bachelors_degree_or_high", 2);


        public static readonly EducationLevel[] All = new[]
        {
            NoEducation,
            HighSchool,
            BachelorsDegreeOrHigh
        };

        public EducationLevel(EEducationLevel fixedValueType, string description, int scorePoints) : base(fixedValueType, description)
        {
            ScorePoints = scorePoints;
        }

        public static implicit operator EducationLevel(string? fixedValueType)
        {
            if (fixedValueType == null)
                throw new FixedValueNotFoundException();

            try
            {
                return All.Single(x => x.FixedValueType.ToString() == fixedValueType);
            }
            catch (Exception ex)
            {
                throw new FixedValueNotFoundException(fixedValueType, ex);
            }
        }
    }
}
