using System.Collections;
using System.Collections.Generic;
using System;

public static class AbilityUnlocker
{
    public static List<string> UnlockedAbilities = new List<string>() { "Fireball" };

    public static void UnlockAbility(string abilityName)
    {
        if (!UnlockedAbilities.Contains(abilityName))
        {
            UnlockedAbilities.Add(abilityName);
        }
    }
}
