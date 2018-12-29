using Newtonsoft.Json;
using RaiderIO.Entities;
using RaiderIO.Entities.Enums;
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
        /// <param name="count">The Amount of Best Runs You wish to Return. (Recent runs always returns 3)</param>
        /// <returns></returns>
        public MythicPlus GetMythicPlusData(int count)
        {
            var baseUrl = $"{GetBaseUrl(Region)}&realm={Realm}&name={Name}&fields=mythic_plus_best_runs:{count}%2Cmythic_plus_recent_runs";
            return DeserializeJson(DataType.MythicPlus, baseUrl) as MythicPlus;
        }

        private object DeserializeJson(DataType type, string baseUrl)
        {
            switch (type)
            {
                case DataType.Character:
                    return JsonConvert.DeserializeObject<CharacterExtended>(GetRawData(baseUrl));
                case DataType.MythicPlus:
                    return JsonConvert.DeserializeObject<MythicPlus>(GetRawData(baseUrl));
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
