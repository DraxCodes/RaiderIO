using RaiderIO;
using RaiderIO.Entities.Enums;
using RaiderIO.Entities.MythicPlusRuns;
using System;
using System.Threading.Tasks;

namespace RaiderIoTestApp
{
    class Program
    {
        static Task Main(string[] args)
            => Initialize();

        private static async Task Initialize()
        {
            var client = new RaiderIOClient(Region.EU, "Draenor", "Perifete");
            var characterStats = await client.GetCharacterStats();
            Console.WriteLine($"Extended Character Test: {characterStats.GetRaidProgression.Uldir.Summary}");

            //var recent = await client.GetRecentRuns();
            //Test(recent.RecentRuns, "Recent Runs");

            //var best = await client.GetBestRuns(3);
            //Test(best.BestRuns, "Best Runs");

            //var weekly = await client.GetWeeklyRuns();
            //Test(weekly.WeeklyRuns, "Weekly Runs");

            //var highest = await client.GetHighestRuns();
            //Test(highest.HighestRuns, "Highest Runs");

            //var rankings = await client.GetMythicPlusRankings();
            //Console.WriteLine($"\n\n RANKS\nOverall: {rankings.Rankings.Overall.World}\nRealm DPS: {rankings.Rankings.Dps.Realm}");

            //var affixes = await client.GetAffixes(Region.EU);
            //Console.WriteLine("\n\nAffixes");
            //foreach (var item in affixes.CurrentAffixes)
            //{
            //    Console.WriteLine($"{item.Name}\n{item.Description}\n");
            //}

            //var guildprog = await client.GetGuildRaidProgression(Region.EU, "draenor", "Phoenix Arising");
            //Console.WriteLine($"\n\nGuild Raid Summary: {guildprog.RaidInfo.Uldir.Summary}");

            Console.ReadLine();
        }

        public static void Test(BaseRuns[] runs, string type)
        {
            foreach (var item in runs)
            {
                Console.WriteLine($"Mythic Plus Test[{type}]: {item.DungeonName} [Level: {item.Level}] - LevelUp: {item.KeystoneUpgradeNum}");
            }
        }
    }
}
