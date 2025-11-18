using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Effects;
[CreateAssetMenu(fileName = "AntiGravity", menuName = "Properties/AntiGravity Property")]
public class AntiGravity : Effect
{
    public const float GravityMultiplier;
    public override void ApplyToNPC(NPC npc);
    public override void ApplyToPlayer(Player player);
    public override void ClearFromNPC(NPC npc);
    public override void ClearFromPlayer(Player player);
}