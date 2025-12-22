using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.Persistence.ItemLoaders;
public class WateringCanLoader : ItemLoader
{
    public override string ItemType => typeof(WateringCanData).Name;

    public override ItemInstance LoadItem(string itemString);
}