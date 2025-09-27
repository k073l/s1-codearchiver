using ScheduleOne.Product;
using UnityEngine;

namespace ScheduleOne.ItemFramework;
public class ItemFilter_Dryable : ItemFilter
{
    public override bool DoesItemMatchFilter(ItemInstance instance);
    public static bool IsItemDryable(ItemInstance instance);
}