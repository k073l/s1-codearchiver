using System;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Product;
using ScheduleOne.Product.Packaging;
using UnityEngine;

namespace ScheduleOne.Persistence.ItemLoaders;
public class ProductItemLoader : ItemLoader
{
    public override string ItemType => typeof(ProductItemData).Name;

    public override ItemInstance LoadItem(string itemString);
}