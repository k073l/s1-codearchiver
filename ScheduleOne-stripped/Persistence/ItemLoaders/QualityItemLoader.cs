using System;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.Persistence.ItemLoaders;
public class QualityItemLoader : ItemLoader
{
    public override string ItemType => typeof(QualityItemData).Name;

    public override ItemInstance LoadItem(string itemString);
}