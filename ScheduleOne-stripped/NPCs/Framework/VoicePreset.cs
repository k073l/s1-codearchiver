using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[CreateAssetMenu(menuName = "ScheduleOne/NPCs/Presets/Voice Preset")]
public class VoicePreset : ValueProviderScriptableObject<Voice>
{
    public Voice value;
    public override Voice GetValue();
}