using System;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Storage;
using UnityEngine;

namespace ScheduleOne.ItemFramework;
[Serializable]
public class WaterContainerInstance : StorableItemInstance
{
    public float CurrentFillAmount { get; private set; }
    public float NormalizedFillAmount => CurrentFillAmount / WaterContainerDefinition.Capacity;
    public WaterContainerDefinition WaterContainerDefinition => (WaterContainerDefinition)base.Definition;

    public WaterContainerInstance();
    public WaterContainerInstance(ItemDefinition definition, int quantity, float fillAmount);
    public override ItemInstance GetCopy(int overrideQuantity = -1);
    public void ChangeFillAmount(float change);
    public void ChangeFillAmountByPercentage(float percentage);
    public void SetFillAmount(float amount);
    public override ItemData GetItemData();
}