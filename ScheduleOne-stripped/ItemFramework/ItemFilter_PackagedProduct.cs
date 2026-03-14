using System.Collections.Generic;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.Product;
using UnityEngine;

namespace ScheduleOne.ItemFramework;
public class ItemFilter_PackagedProduct : ItemFilter_Category
{
    public ItemFilter_PackagedProduct();
    public override bool DoesItemMatchFilter(ItemInstance instance);
}