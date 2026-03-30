using FishNet.Object;
using ScheduleOne.AvatarFramework;
using ScheduleOne.DevUtilities;
using ScheduleOne.Employees;
using ScheduleOne.FX;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Tools;
using UnityEngine;

namespace ScheduleOne.Effects;
[CreateAssetMenu(fileName = "Athletic", menuName = "Properties/Athletic Property")]
public class Athletic : Effect
{
    public const float SPEED_MULTIPLIER;
    public const float NPC_SPEED_MULTIPLIER;
    public const float WorkSpeedMultiplier;
    [ColorUsage(true, true)]
    [SerializeField]
    public Color TintColor;
    public override void ApplyToNPC(NPC npc);
    public override void ApplyToPlayer(Player player);
    public override void ClearFromNPC(NPC npc);
    public override void ClearFromPlayer(Player player);
    protected override void ApplyToEmployee(Employee employee);
    protected override void ClearFromEmployee(Employee employee);
}