using System;
using Newtonsoft.Json;

namespace RaiderIO.Entities
{
    public class MythicPlus
    {
        [JsonProperty("mythic_plus_recent_runs")]
        public MythicPlusRuns[] RecentRuns { get; set; }
        [JsonProperty("mythic_plus_best_runs")]
        public MythicPlusRuns[] BestRuns { get; set; }
    }

    public class MythicPlusRuns
    {
        [JsonProperty("dungeon")]
        public string DungeonName { get; set; }

        [JsonProperty("short_name")]
        public string DungeonShortName { get; set; }

        [JsonProperty("mythic_level")]
        public int Level { get; set; }

        [JsonProperty("completed_at")]
        public DateTime Date { get; set; }

        [JsonProperty("clear_time_ms")]
        public int ClearTime { get; set; }

        [JsonProperty("num_keystone_upgrades")]
        public int KeystoneUpgradeNum { get; set; }

        [JsonProperty("map_challenge_mode_id")]
        public int Id { get; set; }

        [JsonProperty("score")]
        public float Score { get; set; }

        [JsonProperty("affixes")]
        public Affix[] Affixes { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Affix
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("wowhead_url")]
        public string URL { get; set; }
    }

}
