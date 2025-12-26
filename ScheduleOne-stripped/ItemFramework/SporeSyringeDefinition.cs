using System;
using UnityEngine;

namespace ScheduleOne.ItemFramework;
[Serializable]
[CreateAssetMenu(fileName = "SporeSyringeDefinition", menuName = "ScriptableObjects/Item Definitions/SporeSyringeDefinition", order = 1)]
public class SporeSyringeDefinition : StorableItemDefinition
{
    [field: SerializeField]
    public ShroomSpawnDefinition SpawnDefinition { get; private set; }
}