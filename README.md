# RaiderIO [![Build status](https://ci.appveyor.com/api/projects/status/wieghmj1380r1hom?svg=true)](https://ci.appveyor.com/project/joelp53/raiderio)

## A C# RaiderIO Library To Retrieve and use data from the RaiderIO Api. 

## Built With

* [DotNet Core (Version - 2.1)](https://dotnet.microsoft.com/download/dotnet-core/2.2) - Dotnet version.

## USAGE
```cs
//Create a new instance of the RaiderIO Client.
//Client requires 3 things. Region, Realm & Character Name. Provide them as below.
//Regions are stored in an Enum so (Region.) with intelliensence enabled should display all availble regions.
var client = new RaiderIOClient(Region.EU, "Draenor", "Shamkie");
//Now you're able to access all the basic Raider.IO data for the specified user.
Console.WriteLine($"Extended Character Test: {client.Champion.GetRaidProgression.Uldir.Summary}");
```
### Get More MythicPlus Info For That Character
```cs
var mythicplus = client.GetMythicPlusData();
foreach (var item in mythicplus.RecentRuns)
{
     Console.WriteLine($"Mythic Plus Test: {item.DungeonName}");
}
```


## Authors

* **Draxis (Me)** - *Initial work* - [Drax](https://github.com/joelp53/)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
