using Newtonsoft.Json;

namespace RaiderIO.Entities.MythicPlus
{
    public class MpBestRuns
    {
        [JsonProperty("mythic_plus_best_runs")]
        public BaseRuns[] BestRuns { get; set; }
    }
}
