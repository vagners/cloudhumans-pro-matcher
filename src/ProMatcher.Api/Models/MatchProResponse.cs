using System.Text.Json.Serialization;

namespace ProMatcher.Api.Models
{
    public class MatchProResponse
    {
        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("selected_project")]
        public string SelectedProject { get; set; }

        [JsonPropertyName("eligible_projects")]
        public IEnumerable<string> EligibleProjects { get; set; }

        [JsonPropertyName("ineligible_projects")]
        public IEnumerable<string> IneligibleProjects { get; set; }
    }
}
