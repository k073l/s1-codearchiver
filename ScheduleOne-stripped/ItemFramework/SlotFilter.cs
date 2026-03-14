using System;
using System.Collections.Generic;
using ScheduleOne.Core.Items.Framework;

namespace ScheduleOne.ItemFramework;
[Serializable]
public class SlotFilter
{
    public enum EType
    {
        None,
        Whitelist,
        Blacklist
    }

    public EType Type;
    public List<string> ItemIDs;
    public List<EQuality> AllowedQualities;
    public SlotFilter();
    public bool DoesItemMatchFilter(ItemInstance instance);
    public bool IsDefault();
    public SlotFilter Clone();
}