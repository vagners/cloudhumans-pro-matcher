namespace ProMatcher.Domain.ValueObejcts
{
    public class InternetTest : ScorePointsBase
    {
        public InternetTest(int scorePoints) => ScorePoints = scorePoints;

        private static int CalculateScorePoints(float speed)
        {
            if (speed > 50)
                return 1;
            else if (speed < 5)
                return -1;
            else
                return 0;
        }

        public static InternetTest Create(float downloadSpeed, float uploadSpeed)
        {
            int downloadScore = CalculateScorePoints(downloadSpeed);
            int uploadScore = CalculateScorePoints(uploadSpeed);
            int totalScore = downloadScore + uploadScore;
            return new InternetTest(totalScore);
        }
    }
}
