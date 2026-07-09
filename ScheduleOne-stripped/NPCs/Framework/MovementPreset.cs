using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[CreateAssetMenu(menuName = "ScheduleOne/NPCs/Presets/Movement Preset")]
public class MovementPreset : ValueProviderScriptableObject<Movement>
{
    public Movement value;
    public override Movement GetValue();
}