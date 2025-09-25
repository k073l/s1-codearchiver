using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Storage;
using ScheduleOne.UI;
using UnityEngine;

namespace ScheduleOne.Building;
public class BuildStart_Cash : BuildStart_StoredItem
{
    public override void StartBuilding(ItemInstance itemInstance);
}