using System;
using ScheduleOne.Core.Equipping.Framework;
using UnityEngine;

namespace ScheduleOne.Core.Items.Framework;
[Serializable]
public abstract class BaseItemInstance
{
    public const int ApproximateByteSize;
    protected BaseItemDefinition _definition;
    public string ID => _definition.ID;
    public int Quantity { get; protected set; } = 1;
    public virtual string Name => _definition.Name;
    public virtual string Description => _definition.Description;
    public virtual Sprite Icon => _definition.Icon;
    public virtual EItemCategory Category => _definition.Category;
    public virtual int StackLimit => _definition.StackLimit;
    public virtual EquippableData EquippableData => _definition.EquippableData;

    public event Action onDataChanged;
    public event Action requestClearSlot;
    public BaseItemInstance(BaseItemDefinition definition, int quantity);
    public virtual bool CanStackWith(BaseItemInstance other, bool checkQuantities = true);
    public virtual bool IsValidInstance();
    protected void InvokeDataChange();
    public void SetQuantity(int quantity);
    public void ChangeQuantity(int change);
    public virtual float GetMonetaryValue();
    public void RequestClearSlot();
    public virtual int GetTotalAmount();
}