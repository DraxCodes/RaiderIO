# RaiderIOSharp [![Build status](https://ci.appveyor.com/api/projects/status/8jpbajkl2btl9xkt?svg=true)](https://ci.appveyor.com/project/joelp53/raideriosharp)

## A C# RaiderIO Library To Retrieve and use data from the RaiderIO Api. 

## USAGE
```cs
//Create a new instance of the RaiderIO Client.
//Client requires 3 things. Region, Realm & Character Name. Provide them as below.
//Regions are stored in an Enum so (Region.) with intelliensence enabled should display all availble regions.
var client = new RaiderIOClient(Region.EU, "Draenor", "Shamkie");
//Now you're able to access all the basic Raider.IO data for the specified user.
Console.WriteLine($"Extended Character Test: {client.Champion.GetRaidProgression.Uldir.Summary}");

//Due to how Raider.IO Handles requests, it is one client per character request for now. This may change in future.
```
### Get The MythicPlus Best Runs For That Character
```cs
//Request the best runs info.
//Requires an Int Param for the amount of requests to return.
var mythicplus = client.GetBestRuns(3);
//This returns a list of the best runs for the character, you can then do whatever you like with it.
foreach (var item in mythicplus.RecentRuns)
{
     Console.WriteLine($"Mythic Plus Test: {item.DungeonName}");
}
```
### Currently Supports
- [x] Character Info
- [x] Basic Gear Info (ItemLevel)
- [x] Mythic+ Scores
- [x] Raid Progression
- [x] Mythic+ Recent Runs
- [x] Mythic+ Best Runs
- [x] Mythic+ Weekly Best Runs
- [x] Mythic+ Highest Level Runs
- [x] Mythic+ Rankings
- [ ] Ahead Of The Curve
- [x] Guild Raid Progression Data
- [x] Weekly Affixes
- [ ] Raid Hall Of Fame

### Authors

* **Draxis (Me)** - *Initial work* - [Drax](https://github.com/joelp53/)

### License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
