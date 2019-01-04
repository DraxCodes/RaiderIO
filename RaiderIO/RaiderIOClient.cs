using Newtonsoft.Json;
using RaiderIO.Entities;
using RaiderIO.Entities.Enums;
using RaiderIO.Entities.MythicPlusRuns;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RaiderIO
{
    /// <summary>
    /// The Overall Client.
    /// </summary>
    public sealed class RaiderIOClient
    {
        private Region Region { get; set; }
        private string Name { get; set; }
        private string Realm { get; set; }

        /// <summary>
        /// An Instance of the RaiderIO Client. Used To Access all Raider.IO Data.
        /// </summary>
        /// <param name="region">The Region the character you're looking up is from.</param>
        /// <param name="realm">The Realm the character you're looking up is on.</param>
        /// <param name="name">The Name of the character you're looking up.</param>
        public RaiderIOClient(Region region, string realm = null, string name = null)
            { Region = region; Name = name; Realm = realm; }

        /// <summary>
        /// Returns Basic Character Stats for the user define by the client.
        /// </summary>
        /// <returns></returns>
        public async Task<CharacterExtended> GetCharacterStats()
            => await DeserializeJson(DataType.Character, GetUrl(DataType.Character)) as CharacterExtended;

        /// <summary>
        /// Gets The Mythic+ Data For The Character.
        /// </summary>
        /// <returns></returns>
        public async Task<MpRecentRuns> GetRecentRuns()
            => await DeserializeJson(DataType.MythicPlusRecent, GetUrl(DataType.MythicPlusRecent)) as MpRecentRuns;

        /// <summary>
        /// Gets the Mythic+ Best Runs for the Character
        /// </summary>
        /// <param name="count">The Number of results to return.</param>
        /// <returns></returns>
        public async Task<MpBestRuns> GetBestRuns(int count)
            => await DeserializeJson(DataType.MythicPlusBest, $"{GetUrl(DataType.MythicPlusBest)}:{count}") as MpBestRuns;

        /// <summary>
        /// Gets the Mythic+ Weekly Runs for the Character.
        /// </summary>
        /// <returns></returns>
        public async Task<MpWeeklyRuns> GetWeeklyRuns()
            => await DeserializeJson(DataType.MythicPlusWeekly, GetUrl(DataType.MythicPlusWeekly)) as MpWeeklyRuns;

        /// <summary>
        /// Gets The Mythic+ Highest Runs for the Character.
        /// </summary>
        /// <returns></returns>
        public async Task<MpHighestRuns> GetHighestRuns()
            => await DeserializeJson(DataType.MythicPlusHighest, GetUrl(DataType.MythicPlusHighest)) as MpHighestRuns;

        /// <summary>
        /// Gets the Mythic+ Rankings for the Chartacter.
        /// </summary>
        /// <returns></returns>
        public async Task<MpRanking> GetMythicPlusRankings()
            => await DeserializeJson(DataType.MythicPlusRanking, GetUrl(DataType.MythicPlusRanking)) as MpRanking;

        /// <summary>
        /// Gets The current weeks Mythic+ Affixes.
        /// </summary>
        /// <param name="region">The Region you want to retrieve Affixes for.</param>
        /// <returns></returns>
        public async Task<Affixes> GetAffixes(Region region)
        {
            string baseUrl = String.Empty;
            switch (region)
            {
                case Region.US:
                    baseUrl = "https://raider.io/api/v1/mythic-plus/affixes?region=us&locale=en";
                    break;
                case Region.EU:
                    baseUrl = "https://raider.io/api/v1/mythic-plus/affixes?region=eu&locale=en";
                    break;
                case Region.KR:
                    baseUrl = "https://raider.io/api/v1/mythic-plus/affixes?region=kr&locale=en";
                    break;
                case Region.TW:
                    baseUrl = "https://raider.io/api/v1/mythic-plus/affixes?region=tw&locale=en";
                    break;
                default:
                    break;
            }
            return await DeserializeJson(DataType.MythicPlusAffixes, baseUrl) as Affixes;
        }

        /// <summary>
        /// Gets The Guilds Raid Progression data.
        /// </summary>
        /// <param name="guildRegion">The Region the guild you're looking up is from.</param>
        /// <param name="guildRealm">The Realm the guild you're looking up is from.</param>
        /// <param name="guildName">The name of the guild you're lookin up.</param>
        /// <returns></returns>
        public async Task<GuildRaidProgression> GetGuildRaidProgression(Region guildRegion, string guildRealm, string guildName)
        {
            string baseUrl = String.Empty;
            switch (guildRegion)
            {
                case Region.US:
                    baseUrl = $"https://raider.io/api/v1/guilds/profile?region=us&realm={guildRealm}&name={guildName}&fields=raid_progression";
                    break;
                case Region.EU:
                    baseUrl = $"https://raider.io/api/v1/guilds/profile?region=eu&realm={guildRealm}&name={guildName}&fields=raid_progression";
                    break;
                case Region.KR:
                    baseUrl = $"https://raider.io/api/v1/guilds/profile?region=kr&realm={guildRealm}&name={guildName}&fields=raid_progression";
                    break;
                case Region.TW:
                    baseUrl = $"https://raider.io/api/v1/guilds/profile?region=tw&realm={guildRealm}&name={guildName}&fields=raid_progression";
                    break;
                default:
                    break;
            }
            return await DeserializeJson(DataType.GuildProgression, baseUrl) as GuildRaidProgression;
        }

        private async Task<object> DeserializeJson(DataType type, string baseUrl)
        {
                switch (type)
                {
                    case DataType.Character:
                        return await Task.Run(async () => JsonConvert.DeserializeObject<CharacterExtended>(await GetRawData(baseUrl)));
                    case DataType.MythicPlusRecent:
                        return await Task.Run(async () => JsonConvert.DeserializeObject<MpRecentRuns>(await GetRawData(baseUrl)));
                    case DataType.MythicPlusBest:
                        return await Task.Run(async () => JsonConvert.DeserializeObject<MpBestRuns>(await GetRawData(baseUrl)));
                    case DataType.MythicPlusWeekly:
                        return await Task.Run(async () => JsonConvert.DeserializeObject<MpWeeklyRuns>(await GetRawData(baseUrl)));
                    case DataType.MythicPlusHighest:
                        return await Task.Run(async () => JsonConvert.DeserializeObject<MpHighestRuns>(await GetRawData(baseUrl)));
                    case DataType.MythicPlusRanking:
                        return await Task.Run(async () => JsonConvert.DeserializeObject<MpRanking>(await GetRawData(baseUrl)));
                    case DataType.MythicPlusAffixes:
                        return await Task.Run(async () => JsonConvert.DeserializeObject<Affixes>(await GetRawData(baseUrl)));
                    case DataType.GuildProgression:
                        return await Task.Run(async () => JsonConvert.DeserializeObject<GuildRaidProgression>(await GetRawData(baseUrl)));
                    default:
                        throw new NotSupportedException("The Requested Option Is Not Supported.");
                }
         }
        
        private async Task<string> GetRawData(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage message = await client.GetAsync(url);
                    message.EnsureSuccessStatusCode();
                    return await message.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        private string GetUrl(DataType type)
        {
            switch (type)
            {
                case DataType.Character:
                    return $"{GetBaseUrlRegion(Region)}&realm={Realm}&name={Name}&fields=gear%2Cguild%2Craid_progression%2Cmythic_plus_scores";
                case DataType.MythicPlusRecent:
                    return $"{GetBaseUrlRegion(Region)}&realm={Realm}&name={Name}&fields=mythic_plus_recent_runs";
                case DataType.MythicPlusBest:
                    return $"{GetBaseUrlRegion(Region)}&realm={Realm}&name={Name}&fields=mythic_plus_best_runs";
                case DataType.MythicPlusWeekly:
                    return $"{GetBaseUrlRegion(Region)}&realm={Realm}&name={Name}&fields=mythic_plus_weekly_highest_level_runs";
                case DataType.MythicPlusHighest:
                    return $"{GetBaseUrlRegion(Region)}&realm={Realm}&name={Name}&fields=mythic_plus_highest_level_runs";
                case DataType.MythicPlusRanking:
                    return $"{GetBaseUrlRegion(Region)}&realm={Realm}&name={Name}&fields=mythic_plus_ranks";
                default:
                    throw new Exception("Error In RaiderIOClient - GetUrl");
            }
        }

        private string GetBaseUrlRegion(Region region)
        {
            string baseUrl = null;
            switch (region)
            {
                case Region.US:
                    baseUrl = $"https://raider.io/api/v1/characters/profile?region=us";
                    break;
                case Region.EU:
                    baseUrl = $"https://raider.io/api/v1/characters/profile?region=eu";
                    break;
                case Region.KR:
                    baseUrl = $"https://raider.io/api/v1/characters/profile?region=kr";
                    break;
                case Region.TW:
                    baseUrl = $"https://raider.io/api/v1/characters/profile?region=tw";
                    break;
                default:
                    throw new NotSupportedException("The defined Region is not supported. Contact The Developer.");
            }
            return baseUrl;
        }
    }
}
