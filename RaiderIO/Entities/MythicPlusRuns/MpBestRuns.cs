using Newtonsoft.Json;

namespace RaiderIO.Entities.MythicPlusRuns
{
    public class MpBestRuns
    {
        [JsonProperty("mythic_plus_best_runs")]
        public BaseRuns[] BestRuns { get; set; }
    }
}
