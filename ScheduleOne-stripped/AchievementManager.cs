using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using Steamworks;
using UnityEngine;

namespace ScheduleOne;
public class AchievementManager : PersistentSingleton<AchievementManager>
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

    private EAchievement[] achievements;
    private Dictionary<EAchievement, bool> achievementUnlocked;
    protected override void Awake();
    protected override void Start();
    private void PullAchievements();
    public void UnlockAchievement(EAchievement achievement);
}