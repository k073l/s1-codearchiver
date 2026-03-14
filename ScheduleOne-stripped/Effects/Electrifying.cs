using ScheduleOne.AvatarFramework;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Effects;
[CreateAssetMenu(fileName = "Electrifying", menuName = "Properties/Electrifying Property")]
public class Electrifying : Effect
{
    private static Color32 EyeColor;
    public override void ApplyToNPC(NPC npc);
    public override void ApplyToPlayer(Player player);
    public override void ClearFromNPC(NPC npc);
    public override void ClearFromPlayer(Player player);
    public static void ApplyToAvatar(Avatar avatar);
    public static void ClearFromAvatar(Avatar avatar);
}