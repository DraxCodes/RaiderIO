using Newtonsoft.Json;

namespace RaiderIO.Entities.MythicPlusRuns
{
    public class MpWeeklyRuns
    {
        [JsonProperty("mythic_plus_weekly_highest_level_runs")]
        public BaseRuns[] WeeklyRuns { get; set; }
    }
}
