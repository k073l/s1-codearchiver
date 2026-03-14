using System.Collections.Generic;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.Product;
using UnityEngine;

namespace ScheduleOne.ItemFramework;
public class ItemFilter_UnpackagedProduct : ItemFilter_Category
{
    public ItemFilter_UnpackagedProduct();
    public override bool DoesItemMatchFilter(ItemInstance instance);
}