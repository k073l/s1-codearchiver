using FishNet.Object;
using ScheduleOne.AvatarFramework;
using ScheduleOne.DevUtilities;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using UnityEngine;

namespace ScheduleOne.Effects;
[CreateAssetMenu(fileName = "Sedating", menuName = "Properties/Sedating Property")]
public class Sedating : Effect
{
    public override void ApplyToNPC(NPC npc);
    public override void ApplyToPlayer(Player player);
    public override void ClearFromNPC(NPC npc);
    public override void ClearFromPlayer(Player player);
}