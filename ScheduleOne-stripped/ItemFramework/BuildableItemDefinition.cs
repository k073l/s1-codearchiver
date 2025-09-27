using System;
using ScheduleOne.EntityFramework;
using UnityEngine;

namespace ScheduleOne.ItemFramework;
[Serializable]
[CreateAssetMenu(fileName = "BuildableItemDefinition", menuName = "ScriptableObjects/BuildableItemDefinition", order = 1)]
public class BuildableItemDefinition : StorableItemDefinition
{
    public enum EBuildSoundType
    {
        Cardboard,
        Wood,
        Metal
    }

    public BuildableItem BuiltItem;
    public EBuildSoundType BuildSoundType;
}