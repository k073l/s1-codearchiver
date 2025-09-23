using System;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Product;
using ScheduleOne.Product.Packaging;
using UnityEngine;

namespace ScheduleOne.Persistence.ItemLoaders;
public class CocaineLoader : ItemLoader
{
    public override string ItemType => typeof(CocaineData).Name;

    public override ItemInstance LoadItem(string itemString);
}