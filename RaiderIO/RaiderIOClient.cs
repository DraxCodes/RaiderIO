using Newtonsoft.Json;
using RaiderIO.Entities;
using RaiderIO.Entities.Enums;
using RaiderIO.Entities.MythicPlus;
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
        private Region _region { get; set; }
        private string _name { get; set; }
        private string _realm { get; set; }

        /// <summary>
        /// An Instance of the RaiderIO Client. Used To Access all Raider.IO Data.
        /// </summary>
        /// <param name="region">The Region the character you're looking up is from.</param>
        /// <param name="realm">The Realm the character you're looking up is on.</param>
        /// <param name="name">The Name of the character you're looking up.</param>
        public RaiderIOClient(Region region, string realm = null, string name = null)
        {
            _region = region;
            _name = name;
            _realm = realm;
        }

        /// <summary>
        /// Returns Basic Character Stats for the user define by the client.
        /// </summary>
        /// <returns></returns>
        public async Task<CharacterExtended> GetCharacterStatsAsync()
            => await RetrieveData<CharacterExtended>(GetUrl(DataType.Character));

        /// <summary>
        /// Gets The Mythic+ Data For The Character.
        /// </summary>
        /// <returns></returns>
        public async Task<MpRecentRuns> GetRecentRunsAsync()
            => await RetrieveData<MpRecentRuns>(GetUrl(DataType.MythicPlusRecent));

        /// <summary>
        /// Gets the Mythic+ Best Runs for the Character
        /// </summary>
        /// <param name="count">The Number of results to return.</param>
        /// <returns></returns>
        public async Task<MpBestRuns> GetBestRunsAsync(int count)
            => await RetrieveData<MpBestRuns>($"{GetUrl(DataType.MythicPlusBest)}:{count}");

        /// <summary>
        /// Gets the Mythic+ Weekly Runs for the Character.
        /// </summary>
        /// <returns></returns>
        public async Task<MpWeeklyRuns> GetWeeklyRunsAsync()
            => await RetrieveData<MpWeeklyRuns>(GetUrl(DataType.MythicPlusWeekly));

        /// <summary>
        /// Gets The Mythic+ Highest Runs for the Character.
        /// </summary>
        /// <returns></returns>
        public async Task<MpHighestRuns> GetHighestRunsAsync()
            => await RetrieveData<MpHighestRuns>(GetUrl(DataType.MythicPlusHighest));

        /// <summary>
        /// Gets the Mythic+ Rankings for the Chartacter.
        /// </summary>
        /// <returns></returns>
        public async Task<MpRanking> GetMythicPlusRankingsAsync()
            => await RetrieveData<MpRanking>(GetUrl(DataType.MythicPlusRanking));

        /// <summary>
        /// Gets The current weeks Mythic+ Affixes.
        /// </summary>
        /// <param name="region">The Region you want to retrieve Affixes for.</param>
        /// <returns></returns>
        public async Task<Affixes> GetAffixesAsync(Region region)
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
            return await RetrieveData<Affixes>(baseUrl);
        }

        /// <summary>
        /// Gets The Guilds Raid Progression data.
        /// </summary>
        /// <param name="guildRegion">The Region the guild you're looking up is from.</param>
        /// <param name="guildRealm">The Realm the guild you're looking up is from.</param>
        /// <param name="guildName">The name of the guild you're lookin up.</param>
        /// <returns></returns>
        public async Task<GuildRaidProgression> GetGuildRaidProgAsync(Region guildRegion, string guildRealm, string guildName)
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
            return await RetrieveData<GuildRaidProgression>(baseUrl);
        }

        private async Task<T> RetrieveData<T>(string baseUrl)
            => await Task.Run(async () => JsonConvert.DeserializeObject<T>(await GetRawData(baseUrl)));
        
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
                    return $"{GetBaseUrlRegion(_region)}&realm={_realm}&name={_name}&fields=gear%2Cguild%2Craid_progression%2Cmythic_plus_scores";
                case DataType.MythicPlusRecent:
                    return $"{GetBaseUrlRegion(_region)}&realm={_realm}&name={_name}&fields=mythic_plus_recent_runs";
                case DataType.MythicPlusBest:
                    return $"{GetBaseUrlRegion(_region)}&realm={_realm}&name={_name}&fields=mythic_plus_best_runs";
                case DataType.MythicPlusWeekly:
                    return $"{GetBaseUrlRegion(_region)}&realm={_realm}&name={_name}&fields=mythic_plus_weekly_highest_level_runs";
                case DataType.MythicPlusHighest:
                    return $"{GetBaseUrlRegion(_region)}&realm={_realm}&name={_name}&fields=mythic_plus_highest_level_runs";
                case DataType.MythicPlusRanking:
                    return $"{GetBaseUrlRegion(_region)}&realm={_realm}&name={_name}&fields=mythic_plus_ranks";
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
