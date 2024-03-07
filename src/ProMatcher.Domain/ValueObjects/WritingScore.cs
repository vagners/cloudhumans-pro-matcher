using ProMatcher.Domain.Exceptions;

namespace ProMatcher.Domain.ValueObjects
{
    public class WritingScore : ScorePointsBase
    {
        private WritingScore(float score)
        {
            if (score < 0 || score > 1)
                throw new BusinessException("Writing Score must be between 0 and 1");

            int calculatedScore = CalculateScorePoints(score);

            ScorePoints = calculatedScore; 
        }

        private static int CalculateScorePoints(float score)
        {
            if (score < 0.3)
                return -1;
            else if (0.3 <= score && score <= 0.7)
                return 1;
            else
                return 2;
        }

        public static WritingScore Create(float score) => new WritingScore(score);
    }
}
