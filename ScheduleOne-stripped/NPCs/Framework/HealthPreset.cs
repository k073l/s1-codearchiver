using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[CreateAssetMenu(menuName = "ScheduleOne/NPCs/Presets/Health Preset")]
public class HealthPreset : ValueProviderScriptableObject<Health>
{
    public Health value;
    public override Health GetValue();
}