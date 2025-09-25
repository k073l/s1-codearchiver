using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Properties;
[CreateAssetMenu(fileName = "Shrinking", menuName = "Properties/Shrinking Property")]
public class Shrinking : Property
{
    public const float Scale;
    public const float LerpTime;
    public override void ApplyToNPC(NPC npc);
    public override void ApplyToPlayer(Player player);
    public override void ClearFromNPC(NPC npc);
    public override void ClearFromPlayer(Player player);
}