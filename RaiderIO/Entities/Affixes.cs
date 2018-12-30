using Newtonsoft.Json;

namespace RaiderIO.Entities
{
    public class Affixes
    {
        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("leaderboard_url")]
        public string LeaderboardUrl { get; set; }

        [JsonProperty("affix_details")]
        public CurrentAffixes[] CurrentAffixes { get; set; }
    }

    public class CurrentAffixes
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("wowhead_url")]
        public string Url { get; set; }
    }

}
