using System.Collections.Generic;
using ScheduleOne.Core.Items.Framework;

namespace ScheduleOne.ItemFramework;
public class IDs : ItemFilter
{
    public List<string> AcceptedIDs;
    public override bool DoesItemMatchFilter(ItemInstance instance);
}