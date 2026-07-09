using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[CreateAssetMenu(menuName = "ScheduleOne/NPCs/Presets/Interaction Preset")]
public class InteractionPreset : ValueProviderScriptableObject<Interaction>
{
    public Interaction value;
    public override Interaction GetValue();
}