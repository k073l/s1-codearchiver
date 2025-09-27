using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.Persistence.ItemLoaders;
public class CashLoader : ItemLoader
{
    public override string ItemType => typeof(CashData).Name;

    public override ItemInstance LoadItem(string itemString);
}