using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.FX;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using ScheduleOne.VoiceOver;
using UnityEngine;

namespace ScheduleOne.Effects;
[CreateAssetMenu(fileName = "Schizophrenic", menuName = "Properties/Schizophrenic Property")]
public class Schizophrenic : Effect
{
    public override void ApplyToNPC(NPC npc);
    public override void ApplyToPlayer(Player player);
    public override void ClearFromNPC(NPC npc);
    public override void ClearFromPlayer(Player player);
}