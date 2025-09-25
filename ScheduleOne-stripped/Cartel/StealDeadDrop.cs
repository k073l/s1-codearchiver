using System.Collections.Generic;
using System.Linq;
using FishNet;
using GameKit.Utilities;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.GameTime;
using ScheduleOne.ItemFramework;
using ScheduleOne.Map;
using UnityEngine;

namespace ScheduleOne.Cartel;
public class StealDeadDrop : CartelActivity
{
    public const int MIN_TIME_SINCE_CONTENTS_CHANGED;
    public ItemDefinition[] ItemsToLeave;
    public override bool IsRegionValidForActivity(EMapRegion region);
    public override void Activate(EMapRegion region);
    private static DeadDrop GetRandomDropToStealFrom(EMapRegion region);
}