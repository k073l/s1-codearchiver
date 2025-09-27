using System;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Product;
using ScheduleOne.Product.Packaging;
using UnityEngine;

namespace ScheduleOne.Persistence.ItemLoaders;
public class WeedLoader : ItemLoader
{
    public override string ItemType => typeof(WeedData).Name;

    public override ItemInstance LoadItem(string itemString);
}