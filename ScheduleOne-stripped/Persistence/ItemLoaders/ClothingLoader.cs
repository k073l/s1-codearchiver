using ScheduleOne.Clothing;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.Persistence.ItemLoaders;
public class ClothingLoader : ItemLoader
{
    public override string ItemType => typeof(ClothingData).Name;

    public override ItemInstance LoadItem(string itemString);
}