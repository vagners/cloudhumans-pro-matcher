namespace ProMatcher.Domain.ValueObejcts
{
    public class ReferralCode : ScorePointsBase
    {
        public ReferralCode(string value, bool valid) 
        {
            Value = value;
            Valid = valid;

            if (valid)
                ScorePoints = 1;
        }

        public string Value { get; set; }
        public bool Valid { get; private set; }

        public static implicit operator ReferralCode(string value) => new ReferralCode(value, false);
    }
}
