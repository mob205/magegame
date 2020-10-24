using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelUnlocker
{
    public static List<string> UnlockedLevels { get; } = new List<string>() { "Grassland(1-1)", "Grassland(1-2)" };
    public static string SelectedLevel { get; private set; }

    public static void UnlockLevel(string levelName)
    {
        UnlockedLevels.Add(levelName);
    }
    public static void SelectLevel(string levelName)
    {
        if(UnlockedLevels.Contains(levelName))
            SelectedLevel = levelName;
    }
}
