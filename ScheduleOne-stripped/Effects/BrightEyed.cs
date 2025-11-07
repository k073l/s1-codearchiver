using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Effects;
[CreateAssetMenu(fileName = "BrightEyed", menuName = "Properties/BrightEyed Property")]
public class BrightEyed : Effect
{
    public Color EyeColor;
    public float Emission;
    public float LightIntensity;
    public override void ApplyToNPC(NPC npc);
    public override void ApplyToPlayer(Player player);
    public override void ClearFromNPC(NPC npc);
    public override void ClearFromPlayer(Player player);
}