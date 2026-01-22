using System;
using FishNet.Serializing.Helping;
using ScheduleOne.Equipping;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.ItemFramework;
[Serializable]
public abstract class ItemInstance
{
    public const int APPROXIMATE_BYTE_SIZE;
    [CodegenExclude]
    protected ItemDefinition definition;
    public int Quantity;
    [CodegenExclude]
    public Action onDataChanged;
    [CodegenExclude]
    public Action requestClearSlot;
    [CodegenExclude]
    public ItemDefinition Definition { get; }
    public string ID { get; protected set; } = string.Empty;

    [CodegenExclude]
    public virtual string Name => Definition.Name;

    [CodegenExclude]
    public virtual string Description => Definition.Description;

    [CodegenExclude]
    public virtual Sprite Icon => Definition.Icon;

    [CodegenExclude]
    public virtual EItemCategory Category => Definition.Category;

    [CodegenExclude]
    public virtual int StackLimit => Definition.StackLimit;

    [CodegenExclude]
    public virtual Color LabelDisplayColor => Definition.LabelDisplayColor;

    [CodegenExclude]
    public virtual Equippable Equippable => Definition.Equippable;

    public ItemInstance();
    public ItemInstance(ItemDefinition definition, int quantity);
    public virtual bool CanStackWith(ItemInstance other, bool checkQuantities = true);
    public virtual ItemInstance GetCopy(int overrideQuantity = -1);
    public virtual bool IsValidInstance();
    protected void InvokeDataChange();
    public void SetQuantity(int quantity);
    public void ChangeQuantity(int change);
    public virtual ItemData GetItemData();
    public virtual float GetMonetaryValue();
    public void RequestClearSlot();
    public virtual int GetTotalAmount();
    public void SetID(string id);
}