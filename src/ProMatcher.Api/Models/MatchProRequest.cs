using System.Text.Json.Serialization;

namespace ProMatcher.Api.Models
{
    public class InternetTest
    {
        [JsonPropertyName("download_speed")]
        public required float DownloadSpeed { get; set; }

        [JsonPropertyName("upload_speed")]
        public required float UploadSpeed { get; set; }
    }

    public class PastExperiences
    {
        [JsonPropertyName("sales")]
        public required bool Sales { get; set; }

        [JsonPropertyName("support")]
        public required bool Support { get; set; }
    }

    public class MatchProRequest
    {
        [JsonPropertyName("age")]
        public required int Age { get; set; }

        [JsonPropertyName("education_level")]
        public required string EducationLevel { get; set; }

        [JsonPropertyName("past_experiences")]
        public required PastExperiences PastExperiences { get; set; }

        [JsonPropertyName("internet_test")]
        public required InternetTest InternetTest { get; set; }

        [JsonPropertyName("writing_score")]
        public required float WritingScore { get; set; }

        [JsonPropertyName("referral_code")]
        public string? ReferralCode { get; set; }
    }
}
