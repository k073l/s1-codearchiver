using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.VoiceOver;
using UnityEngine;

namespace ScheduleOne.Effects;
[CreateAssetMenu(fileName = "Seizure", menuName = "Properties/Seizure Property")]
public class Seizure : Effect
{
    public const float CAMERA_JITTER_INTENSITY;
    public const float DURATION_NPC;
    public const float DURATION_PLAYER;
    public override void ApplyToNPC(NPC npc);
    public override void ApplyToPlayer(Player player);
    public override void ClearFromNPC(NPC npc);
    public override void ClearFromPlayer(Player player);
}