using System;
using FishNet.Serializing.Helping;
using ScheduleOne.ItemFramework;
using UnityEngine;

namespace ScheduleOne.Storage;
[Serializable]
public class StorableItemInstance : ItemInstance
{
    [CodegenExclude]
    public virtual StoredItem StoredItem { get; }

    public StorableItemInstance(ItemDefinition definition, int quantity);
    public override ItemInstance GetCopy(int overrideQuantity = -1);
    public override float GetMonetaryValue();
}