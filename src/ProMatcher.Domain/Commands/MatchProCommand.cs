using ProMatcher.Domain.FixedValues;
using ProMatcher.Domain.ValueObjects;

namespace ProMatcher.Domain.Commands
{
    public class MatchProCommand
    {
        public MatchProCommand(
            int age,
            string educationLevel,
            PastExperiences pastExperiences,
            InternetTest internetTest,
            WritingScore writingScore,
            ReferralCode? referralCode)
        {
            Age = age;
            EducationLevel = educationLevel;
            PastExperiences = pastExperiences;
            InternetTest = internetTest;
            WritingScore = writingScore;
            ReferralCode = referralCode;
        }

        public Age Age { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public PastExperiences PastExperiences { get; set; }
        public InternetTest InternetTest { get; set; }
        public WritingScore WritingScore { get; set; }
        public ReferralCode? ReferralCode { get; set; }
    }
}
