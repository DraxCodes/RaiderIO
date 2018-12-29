using RaiderIO;
using RaiderIO.Entities.Enums;
using System;

namespace RaiderIoTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RaiderIOClient(Region.EU, "Draenor", "Shamkie");
            Console.WriteLine($"Extended Character Test: {client.Champion.GetRaidProgression.Uldir.Summary}");

            var mythicplus = client.GetMythicPlusData();
            foreach (var item in mythicplus.RecentRuns)
            {
                Console.WriteLine($"Mythic Plus Test: {item.DungeonName}");
            }
            Console.ReadLine();
        }
    }
}
