using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Effects;
[CreateAssetMenu(fileName = "Euphoric", menuName = "Properties/Euphoric Property")]
public class Euphoric : Effect
{
    public override void ApplyToNPC(NPC npc);
    public override void ApplyToPlayer(Player player);
    public override void ClearFromNPC(NPC npc);
    public override void ClearFromPlayer(Player player);
}