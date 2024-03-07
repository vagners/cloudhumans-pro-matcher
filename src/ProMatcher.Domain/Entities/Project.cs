namespace ProMatcher.Domain.Entities
{
    public class Project
    {
        public Project(string description, int minimalScoreRequired)
        {
            Description = description;
            MinimalScoreRequired = minimalScoreRequired;
        }

        public string Description { get; }

        public int MinimalScoreRequired { get; }
    }
}
