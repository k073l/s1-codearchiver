using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.Persistence.ItemLoaders;
public class IntegerItemLoader : ItemLoader
{
    public override string ItemType => typeof(IntegerItemData).Name;

    public override ItemInstance LoadItem(string itemString);
}