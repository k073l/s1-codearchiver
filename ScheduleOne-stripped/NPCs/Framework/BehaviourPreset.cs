using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[CreateAssetMenu(menuName = "ScheduleOne/NPCs/Presets/Behaviour Preset")]
public class BehaviourPreset : ValueProviderScriptableObject<Behaviour>
{
    public Behaviour value;
    public override Behaviour GetValue();
}