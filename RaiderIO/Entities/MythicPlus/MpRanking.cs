using Newtonsoft.Json;

namespace RaiderIO.Entities.MythicPlus
{

    public class MpRanking
    {
        [JsonProperty("mythic_plus_ranks")]
        public Ranks Rankings { get; set; }
    }

    public class Ranks
    {
        [JsonProperty("overall")]
        public Areas Overall { get; set; }

        [JsonProperty("dps")]
        public Areas Dps { get; set; }

        [JsonProperty("healer")]
        public Areas Healer { get; set; }

        [JsonProperty("tank")]
        public Areas Tank { get; set; }

        [JsonProperty("class")]
        public Areas ClassOverall { get; set; }

        [JsonProperty("class_dps")]
        public Areas ClassDPS { get; set; }

        [JsonProperty("class_healer")]
        public Areas ClassHealer { get; set; }

        [JsonProperty("class_tank")]
        public Areas ClassTank { get; set; }
    }

    public class Areas
    {
        [JsonProperty("world")]
        public int World { get; set; }

        [JsonProperty("region")]
        public int Region { get; set; }

        [JsonProperty("realm")]
        public int Realm { get; set; }
    }
}
