using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.VoiceOver;
using UnityEngine;

namespace ScheduleOne.Properties;
[CreateAssetMenu(fileName = "Seizure", menuName = "Properties/Seizure Property")]
public class Seizure : Property
{
    public const float CAMERA_JITTER_INTENSITY;
    public const float DURATION_NPC;
    public const float DURATION_PLAYER;
    public override void ApplyToNPC(NPC npc);
    public override void ApplyToPlayer(Player player);
    public override void ClearFromNPC(NPC npc);
    public override void ClearFromPlayer(Player player);
}