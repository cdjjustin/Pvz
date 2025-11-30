using System.Collections.Generic;
using System.Linq;
public static class ConfigManager
{
    public static List<LevelManagerData> LevelManagerDataList;

    public static Dictionary<int, LevelManagerData> LevelManagerDataDict;

    public static void Load()
    {
        LevelManagerDataList = ConfigLoader.LoadList<LevelManagerData>("LevelManager.json");
        LevelManagerDataDict = LevelManagerDataList.ToDictionary(item => item.id);
    }
}
