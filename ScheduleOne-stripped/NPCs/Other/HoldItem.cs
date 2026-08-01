using ScheduleOne.AvatarFramework.Equipping;
using UnityEngine;

namespace ScheduleOne.NPCs.Other;
public class HoldItem : MonoBehaviour
{
    public AvatarEquippable Equippable;
    private NPC _npc;
    public bool active { get; protected set; }

    private void Awake();
    public void Begin();
    public void End();
}