using System.Collections.Generic;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Management;
public class ItemField : ConfigField
{
    public bool CanSelectNone;
    public List<ItemDefinition> Options;
    public UnityEvent<ItemDefinition> onItemChanged;
    public ItemDefinition SelectedItem { get; protected set; }

    public ItemField(EntityConfiguration parentConfig);
    public void SetItem(ItemDefinition item, bool network);
    public override bool IsValueDefault();
    public ItemFieldData GetData();
    public void Load(ItemFieldData data);
}