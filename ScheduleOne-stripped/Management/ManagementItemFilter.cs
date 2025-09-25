using System.Collections.Generic;
using ScheduleOne.ItemFramework;

namespace ScheduleOne.Management;
public class ManagementItemFilter
{
    public enum EMode
    {
        Whitelist,
        Blacklist
    }

    public EMode Mode { get; private set; } = EMode.Blacklist;
    public List<ItemDefinition> Items { get; private set; } = new List<ItemDefinition>();

    public ManagementItemFilter(EMode mode);
    public void SetMode(EMode mode);
    public void AddItem(ItemDefinition item);
    public void RemoveItem(ItemDefinition item);
    public bool Contains(ItemDefinition item);
    public bool DoesItemMeetFilter(ItemInstance item);
    public string GetDescription();
}