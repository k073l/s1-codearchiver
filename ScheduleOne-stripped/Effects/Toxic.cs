using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.FX;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Effects;
[CreateAssetMenu(fileName = "Toxic", menuName = "Properties/Toxic Property")]
public class Toxic : Effect
{
    [ColorUsage(true, true)]
    [SerializeField]
    public Color TintColor;
    public override void ApplyToNPC(NPC npc);
    public override void ApplyToPlayer(Player player);
    public override void ClearFromNPC(NPC npc);
    public override void ClearFromPlayer(Player player);
}