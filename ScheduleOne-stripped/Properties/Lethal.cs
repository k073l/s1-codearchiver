using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Properties;
[CreateAssetMenu(fileName = "Lethal", menuName = "Properties/Lethal Property")]
public class Lethal : Property
{
    public const float HEALTH_DRAIN_PLAYER;
    public const float HEALTH_DRAIN_NPC;
    public override void ApplyToNPC(NPC npc);
    public override void ApplyToPlayer(Player player);
    public override void ClearFromNPC(NPC npc);
    public override void ClearFromPlayer(Player player);
}