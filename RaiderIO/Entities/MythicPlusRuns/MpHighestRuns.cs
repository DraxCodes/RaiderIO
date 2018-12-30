using Newtonsoft.Json;

namespace RaiderIO.Entities.MythicPlusRuns
{
    public class MpHighestRuns
    {
        [JsonProperty("mythic_plus_highest_level_runs")]
        public BaseRuns[] HighestRuns { get; set; }
    }
}
