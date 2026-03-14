using System;
using ScheduleOne.Core.Items.Framework;
using UnityEngine;

namespace ScheduleOne.ItemFramework;
[Serializable]
[CreateAssetMenu(fileName = "AdditiveDefinition", menuName = "ScriptableObjects/Item Definitions/AdditiveDefinition", order = 1)]
public class AdditiveDefinition : StorableItemDefinition
{
    [field: SerializeField]
    public Material DisplayMaterial { get; private set; }

    [field: SerializeField]
    public float QualityChange { get; private set; }

    [field: SerializeField]
    public float YieldMultiplier { get; private set; } = 1f;

    [field: SerializeField]
    public float InstantGrowth { get; private set; }

    public override void ValidateDefinition();
}