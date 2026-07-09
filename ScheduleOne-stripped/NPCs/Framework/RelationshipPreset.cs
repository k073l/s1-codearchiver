using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[CreateAssetMenu(menuName = "ScheduleOne/NPCs/Presets/Relationship Preset")]
public class RelationshipPreset : ValueProviderScriptableObject<Relationship>
{
    public Relationship value;
    public override Relationship GetValue();
}