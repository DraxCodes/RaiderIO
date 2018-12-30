using Newtonsoft.Json;
using RaiderIO.Entities;
using RaiderIO.Entities.Enums;
using RaiderIO.Entities.MythicPlusRuns;
using System;
using System.Net;

namespace RaiderIO
{
    public sealed class RaiderIOClient
    {
        public CharacterExtended Champion { get; private set; }
        private Region Region { get; set; }
        private string Name { get; set; }
        private string Realm { get; set; }

        /// <summary>
        /// An Instance of the RaderIo Client. Used To Access all Raider.IO Data.
        /// </summary>
        /// <param name="region">The Region the character you're looking up is from.</param>
        /// <param name="realm">The Realm the character you're looking up is on.</param>
        /// <param name="name">The Name of the character you're looking up.</param>
        public RaiderIOClient(Region region, string realm, string name)
        {
            Region = region; Name = name; Realm = realm;
            var baseUrl = $"{GetBaseUrl(region)}&realm={realm}&name={name}&fields=gear%2Cguild%2Craid_progression%2Cmythic_plus_scores";
            Champion = DeserializeJson(DataType.Character, baseUrl) as CharacterExtended;
        }
        /// <summary>
        ///     Gets The Mythic+ Data For The Character.
        /// </summary>
        /// <returns></returns>
        public MpRecentRuns GetRecentRuns()
        {
            var baseUrl = $"{GetBaseUrl(Region)}&realm={Realm}&name={Name}&fields=mythic_plus_recent_runs";
            return DeserializeJson(DataType.MythicPlusRecent, baseUrl) as MpRecentRuns;
        }

        /// <summary>
        ///  Gets the Mythic+ Best Runs for the Character
        /// </summary>
        /// <param name="count">The Number of results to return.</param>
        /// <returns></returns>
        public MpBestRuns GetBestRuns(int count)
        {
            var baseUrl = $"{GetBaseUrl(Region)}&realm={Realm}&name={Name}&fields=mythic_plus_best_runs:{count}";
            return DeserializeJson(DataType.MythicPlusBest, baseUrl) as MpBestRuns;
        }

        /// <summary>
        /// Gets the Mythic+ Weekly Runs for the Character.
        /// </summary>
        /// <returns></returns>
        public MpWeeklyRuns GetWeeklyRuns()
        {
            var baseUrl = $"{GetBaseUrl(Region)}&realm={Realm}&name={Name}&fields=mythic_plus_weekly_highest_level_runs";
            return DeserializeJson(DataType.MythicPlusWeekly, baseUrl) as MpWeeklyRuns;
        }

        /// <summary>
        /// Gets The Mythic+ Highest Runs for the Character.
        /// </summary>
        /// <returns></returns>
        public MpHighestRuns GetHighestRuns()
        {
            var baseUrl = $"{GetBaseUrl(Region)}&realm={Realm}&name={Name}&fields=mythic_plus_highest_level_runs";
            return DeserializeJson(DataType.MythicPlusHighest, baseUrl) as MpHighestRuns;
        }

        /// <summary>
        /// Gets the Mythic+ Rankings for the Chartacter.
        /// </summary>
        /// <returns></returns>
        public MpRanking GetMythicPlusRankings()
        {
            var baseUrl = $"{GetBaseUrl(Region)}&realm={Realm}&name={Name}&fields=mythic_plus_ranks";
            return DeserializeJson(DataType.MythicPlusRanking, baseUrl) as MpRanking;
        }

        /// <summary>
        /// Gets The current weeks Mythic+ Affixes.
        /// </summary>
        /// <param name="region">The Region you want to retrieve Affixes for.</param>
        /// <returns></returns>
        public Affixes GetAffixes(Region region)
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
            return DeserializeJson(DataType.MythicPlusAffixes, baseUrl) as Affixes;
        }

        private object DeserializeJson(DataType type, string baseUrl)
        {
            switch (type)
            {
                case DataType.Character:
                    return JsonConvert.DeserializeObject<CharacterExtended>(GetRawData(baseUrl));
                case DataType.MythicPlusRecent:
                    return JsonConvert.DeserializeObject<MpRecentRuns>(GetRawData(baseUrl));
                case DataType.MythicPlusBest:
                    return JsonConvert.DeserializeObject<MpBestRuns>(GetRawData(baseUrl));
                case DataType.MythicPlusWeekly:
                    return JsonConvert.DeserializeObject<MpWeeklyRuns>(GetRawData(baseUrl));
                case DataType.MythicPlusHighest:
                    return JsonConvert.DeserializeObject<MpHighestRuns>(GetRawData(baseUrl));
                case DataType.MythicPlusRanking:
                    return JsonConvert.DeserializeObject<MpRanking>(GetRawData(baseUrl));
                case DataType.MythicPlusAffixes:
                    return JsonConvert.DeserializeObject<Affixes>(GetRawData(baseUrl));
                default:
                    throw new NotSupportedException("The Requested Option Is Not Supported.");
            }
        }

        private string GetRawData(string url)
        {
            return new WebClient().DownloadString(url);
        }

        private string GetBaseUrl(Region region)
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
