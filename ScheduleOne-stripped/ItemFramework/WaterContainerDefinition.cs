using System;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.Tools;
using UnityEngine;

namespace ScheduleOne.ItemFramework;
[Serializable]
[CreateAssetMenu(fileName = "WaterContainerDefinition", menuName = "ScriptableObjects/Item Definitions/WaterContainerDefinition", order = 1)]
public class WaterContainerDefinition : StorableItemDefinition
{
    [SerializeField]
    public float Capacity;
    [SerializeField]
    public FillableWaterContainer FillablePrefab;
    public override void ValidateDefinition();
    public override ItemInstance GetDefaultInstance(int quantity = 1);
}