using System;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.Growing;
using ScheduleOne.PlayerTasks;
using ScheduleOne.Product;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ScheduleOne.ItemFramework;
[Serializable]
[CreateAssetMenu(fileName = "ShroomSpawnDefinition", menuName = "ScriptableObjects/Item Definitions/ShroomSpawnDefinition", order = 1)]
public class ShroomSpawnDefinition : StorableItemDefinition
{
    [field: SerializeField]
    public ShroomColony ColonyPrefab { get; private set; }

    [field: SerializeField]
    public ShroomDefinition Shroom { get; private set; }

    [field: SerializeField]
    public SpawnChunk ChunkPrefab { get; private set; }

    [field: SerializeField]
    public DecalProjector MixTaskProjectorPrefab { get; private set; }

    public override void ValidateDefinition();
}