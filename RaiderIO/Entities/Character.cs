using Newtonsoft.Json;

namespace RaiderIO.Entities
{
    public class Character
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("race")]
        public string Race { get; set; }
        [JsonProperty("class")]
        public string Class { get; set; }
        [JsonProperty("active_spec_name")]
        public string SpecName { get; set; }
        [JsonProperty("active_spec_role")]
        public string SpecRole { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("faction")]
        public string Faction { get; set; }
        [JsonProperty("achievement_points")]
        public int AchievmentPoints { get; set; }
        [JsonProperty("honorable_kills")]
        public int HonorableKills { get; set; }
        [JsonProperty("thumbnail_url")]
        public string Thumbnail { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("realm")]
        public string Realm { get; set; }
        [JsonProperty("profile_url")]
        public string Url { get; set; }
    }
}
