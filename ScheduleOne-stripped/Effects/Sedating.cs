using FishNet.Object;
using ScheduleOne.AvatarFramework;
using ScheduleOne.DevUtilities;
using ScheduleOne.Employees;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Tools;
using ScheduleOne.UI;
using UnityEngine;

namespace ScheduleOne.Effects;
[CreateAssetMenu(fileName = "Sedating", menuName = "Properties/Sedating Property")]
public class Sedating : Effect
{
    public const float WorkSpeedMultiplier;
    public override void ApplyToNPC(NPC npc);
    public override void ApplyToPlayer(Player player);
    public override void ClearFromNPC(NPC npc);
    public override void ClearFromPlayer(Player player);
    protected override void ApplyToEmployee(Employee employee);
    protected override void ClearFromEmployee(Employee employee);
}