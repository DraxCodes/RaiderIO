# RaiderIOSharp [![Build status](https://ci.appveyor.com/api/projects/status/8jpbajkl2btl9xkt?svg=true)](https://ci.appveyor.com/project/joelp53/raideriosharp)

## A C# RaiderIO Library To Retrieve and use data from the RaiderIO Api. 

## USAGE

**Add the Nuget Package: RaiderIoSharp via the package manager.
Or Run**
```bash
Install-Package RaiderIOSharp-V2 -Version 2.0.2 
```
```cs
//Create a new instance of the RaiderIO Client.
//Client requires 3 things. Region, Realm & Character Name. Provide them as below.
//Regions are stored in an Enum so (Region.) with intelliensence enabled should display all availble regions.
var client = new RaiderIOClient(Region.EU, "Draenor", "Perifete");
Now you can call information for the user. Below is an example of calling CharacterStats.
var characterData = await client.GetCharacterStats();

//Due to how Raider.IO Handles requests, it is one client per character request for now. This may change in future.
```
### Get This weeks affixes
```cs
//This requires the Region param again to allow for the user to request affixes for any region.
//regardless of those defined in the RaiderIOClient. 
var affixes = await client.GetAffixes(Region.EU);
Console.WriteLine("\n\nAffixes");
foreach (var item in affixes.CurrentAffixes)
{
    Console.WriteLine($"{item.Name}\n{item.Description}\n");
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
