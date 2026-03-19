using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using Steamworks;
using UnityEngine;

namespace ScheduleOne;
public static class AchievementManager
{
    public enum EAchievement
    {
        COMPLETE_PROLOGUE,
        RV_DESTROYED,
        DEALER_RECRUITED,
        MASTER_CHEF,
        BUSINESSMAN,
        BIGWIG,
        MAGNATE,
        UPSTANDING_CITIZEN,
        ROLLING_IN_STYLE,
        LONG_ARM_OF_THE_LAW,
        INDIAN_DEALER,
        URBAN_ARTIST,
        FINISHING_THE_JOB
    }

    private static EAchievement[] achievements;
    private static Dictionary<EAchievement, bool> achievementUnlocked;
    [RuntimeInitializeOnLoadMethod( /*Could not decode attribute arguments.*/)]
    private static void Init();
    private static void PullAchievements();
    public static void UnlockAchievement(EAchievement achievement);
}