using System;
using FishNet.Serializing;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.Equipping;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.ItemFramework;
[Serializable]
public abstract class ItemInstance : BaseItemInstance
{
    public ItemDefinition Definition { get; }
    public virtual Equippable Equippable => Definition.Equippable;

    public ItemInstance(ItemDefinition definition, int quantity);
    public virtual bool CanStackWith(ItemInstance other, bool checkQuantities = true);
    public abstract ItemInstance GetCopy(int overrideQuantity = -1);
    public virtual ItemData GetItemData();
    public virtual void Write(Writer writer);
    public virtual void Read(Reader reader);
    public static ItemInstance CreateInstanceAndRead(Reader reader);
}