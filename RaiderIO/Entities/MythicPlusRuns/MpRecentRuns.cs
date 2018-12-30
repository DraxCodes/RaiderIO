using Newtonsoft.Json;

namespace RaiderIO.Entities.MythicPlusRuns
{
    public class MpRecentRuns
    {
        [JsonProperty("mythic_plus_recent_runs")]
        public BaseRuns[] RecentRuns { get; set; }
    }
}
