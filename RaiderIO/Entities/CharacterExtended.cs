using Newtonsoft.Json;

namespace RaiderIO.Entities
{
    public class CharacterExtended : Character
    {
        [JsonProperty("mythic_plus_scores")]
        public Mythic_Plus_Scores GetMythicPlusScores { get; set; }
        [JsonProperty("gear")]
        public Gear Gear { get; set; }
        [JsonProperty("raid_progression")]
        public Progression GetRaidProgression { get; set; }
        [JsonProperty("guild")]
        public Guild Guild { get; set; }
    }
    public class Mythic_Plus_Scores
    {
        [JsonProperty("all")]
        public float Overall { get; set; }
        [JsonProperty("dps")]
        public float DPS { get; set; }
        [JsonProperty("healer")]
        public float Healer { get; set; }
        [JsonProperty("tank")]
        public float Tank { get; set; }
    }

    public class Gear
    {
        [JsonProperty("item_level_equipped")]
        public int ItemLevelEquiped { get; set; }
        [JsonProperty("item_level_total")]
        public int ItemLevelAverage { get; set; }
        [JsonProperty("artifact_traits")]
        public int AzeritePower { get; set; }
    }

    public class Progression
    {
        [JsonProperty("antorustheburningthrone")]
        public Raid Antorus { get; set; }

        [JsonProperty("theemeraldnightmare")]
        public Raid EmeraldNightmare { get; set; }

        [JsonProperty("thenighthold")]
        public Raid Nighthold { get; set; }

        [JsonProperty("tombofsargeras")]
        public Raid TombOfSargeras { get; set; }

        [JsonProperty("trialofvalor")]
        public Raid TrialOfValor { get; set; }

        [JsonProperty("uldir")]
        public Raid Uldir { get; set; }
    }

    public class Raid
    {
        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("total_bosses")]
        public int TotalBosses { get; set; }

        [JsonProperty("normal_bosses_killed")]
        public int NormalBossesKilled { get; set; }

        [JsonProperty("heroic_bosses_killed")]
        public int HeroicBossesKilled { get; set; }

        [JsonProperty("mythic_bosses_killed")]
        public int MythicBossesKilled { get; set; }
    }

    public class Guild
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("realm")]
        public string Realm { get; set; }
    }
}

