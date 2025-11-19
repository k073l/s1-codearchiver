using System;
using UnityEngine;

namespace ScheduleOne.ItemFramework;
[Serializable]
[CreateAssetMenu(fileName = "SubstrateDefinition", menuName = "ScriptableObjects/Item Definitions/SubstrateDefinition", order = 1)]
public class SubstrateDefinition : StorableItemDefinition
{
    public EQuality SubstrateQuality;
}