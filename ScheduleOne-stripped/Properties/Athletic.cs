using FishNet.Object;
using ScheduleOne.AvatarFramework;
using ScheduleOne.DevUtilities;
using ScheduleOne.FX;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Properties;
[CreateAssetMenu(fileName = "Athletic", menuName = "Properties/Athletic Property")]
public class Athletic : Property
{
    public const float SPEED_MULTIPLIER;
    public const float NPC_SPEED_MULTIPLIER;
    [ColorUsage(true, true)]
    [SerializeField]
    public Color TintColor;
    public override void ApplyToNPC(NPC npc);
    public override void ApplyToPlayer(Player player);
    public override void ClearFromNPC(NPC npc);
    public override void ClearFromPlayer(Player player);
}