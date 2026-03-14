using FishNet.Object;
using ScheduleOne.AvatarFramework;
using ScheduleOne.DevUtilities;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Tools;
using UnityEngine;

namespace ScheduleOne.Effects;
[CreateAssetMenu(fileName = "Energizing", menuName = "Properties/Energizing Property")]
public class Energizing : Effect
{
    public const float SPEED_MULTIPLIER;
    public override void ApplyToNPC(NPC npc);
    public override void ApplyToPlayer(Player player);
    public override void ClearFromNPC(NPC npc);
    public override void ClearFromPlayer(Player player);
}