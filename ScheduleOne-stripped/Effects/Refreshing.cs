using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Effects;
[CreateAssetMenu(fileName = "Refreshing", menuName = "Properties/Refreshing Property")]
public class Refreshing : Effect
{
    public override void ApplyToNPC(NPC npc);
    public override void ApplyToPlayer(Player player);
    public override void ClearFromNPC(NPC npc);
    public override void ClearFromPlayer(Player player);
}