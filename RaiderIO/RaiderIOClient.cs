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

        public RaiderIOClient(Region region, string realm, string name)
        {
            Region = region; Name = name; Realm = realm;
            var baseUrl = $"{GetBaseUrl(region)}&realm={realm}&name={name}&fields=gear%2Cguild%2Craid_progression%2Cmythic_plus_scores";
            Champion = DeserializeJson(DataType.Character, baseUrl) as CharacterExtended;
        }

        public MythicPlus GetMythicPlusData()
        {
            var baseUrl = $"{GetBaseUrl(Region)}&realm={Realm}&name={Name}&fields=mythic_plus_recent_runs%2C mythic_plus_best_runs";
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
