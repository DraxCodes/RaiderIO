using RaiderIO;
using RaiderIO.Entities.Enums;
using RaiderIO.Entities.MythicPlusRuns;
using System;

namespace RaiderIoTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RaiderIOClient(Region.EU, "Draenor", "Perifete");
            Console.WriteLine($"Extended Character Test: {client.Champion.GetRaidProgression.Uldir.Summary}");

            var recent = client.GetRecentRuns();
            Test(recent.RecentRuns, "Recent Runs");

            var best = client.GetBestRuns(3);
            Test(best.BestRuns, "Best Runs");

            var weekly = client.GetWeeklyRuns();
            Test(weekly.WeeklyRuns, "Weekly Runs");

            var highest = client.GetHighestRuns();
            Test(highest.HighestRuns, "Highest Runs");

            var rankings = client.GetMythicPlusRankings();
            Console.WriteLine($"\n\n RANKS\nOverall: {rankings.Rankings.Overall.World}\nRealm DPS: {rankings.Rankings.Dps.Realm}");

            var affixes = client.GetAffixes(Region.EU);
            Console.WriteLine("\n\nAffixes");
            foreach (var item in affixes.CurrentAffixes)
            {
                Console.WriteLine($"{item.Name}\n{item.Description}\n");
            }

            var guildprog = client.GetGuildRaidProgression(Region.EU, "draenor", "Phoenix Arising");
            Console.WriteLine($"\n\nGuild Raid Summary: {guildprog.RaidInfo.Uldir.Summary}");

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
