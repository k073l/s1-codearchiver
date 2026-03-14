using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Tools;
using ScheduleOne.UI;
using ScheduleOne.Vision;
using UnityEngine;

namespace ScheduleOne.Effects;
[CreateAssetMenu(fileName = "Sneaky", menuName = "Properties/Sneaky Property")]
public class Sneaky : Effect
{
    public const float SPEED_MULTIPLIER;
    public const float FOOTSTEP_VOL_MULTIPLIER;
    private VisibilityAttribute visibilityAttribute;
    public override void ApplyToNPC(NPC npc);
    public override void ApplyToPlayer(Player player);
    public override void ClearFromNPC(NPC npc);
    public override void ClearFromPlayer(Player player);
}