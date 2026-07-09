using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[CreateAssetMenu(menuName = "ScheduleOne/NPCs/Presets/Basic Info Preset")]
public class BasicInfoPreset : ValueProviderScriptableObject<BasicInfo>
{
    public BasicInfo value;
    public override BasicInfo GetValue();
}