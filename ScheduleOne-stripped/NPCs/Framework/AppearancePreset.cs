using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[CreateAssetMenu(menuName = "ScheduleOne/NPCs/Presets/Appearance Preset")]
public class AppearancePreset : ValueProviderScriptableObject<Appearance>
{
    public Appearance value;
    public override Appearance GetValue();
}