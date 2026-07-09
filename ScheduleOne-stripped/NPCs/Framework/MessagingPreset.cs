using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[CreateAssetMenu(menuName = "ScheduleOne/NPCs/Presets/Messaging Preset")]
public class MessagingPreset : ValueProviderScriptableObject<Messaging>
{
    public Messaging value;
    public override Messaging GetValue();
}