using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[CreateAssetMenu(menuName = "ScheduleOne/NPCs/Presets/Dialogue Preset")]
public class DialoguePreset : ValueProviderScriptableObject<Dialogue>
{
    public Dialogue value;
    public override Dialogue GetValue();
}