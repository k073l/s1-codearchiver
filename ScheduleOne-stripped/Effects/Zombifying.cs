using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.VoiceOver;
using UnityEngine;

namespace ScheduleOne.Effects;
[CreateAssetMenu(fileName = "Zombifying", menuName = "Properties/Zombifying Property")]
public class Zombifying : Effect
{
    public VODatabase zombieVODatabase;
    public override void ApplyToNPC(NPC npc);
    public override void ApplyToPlayer(Player player);
    public override void ClearFromNPC(NPC npc);
    public override void ClearFromPlayer(Player player);
}