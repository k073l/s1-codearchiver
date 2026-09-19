using ScheduleOne.Core.Equipping.Framework;
using UnityEngine;

namespace ScheduleOne.NPCs.Other;
public class UseGuitar : NPCDiscreteAction
{
    [Header("Components")]
    private NPC _npc;
    [SerializeField]
    private EquippableData _guitarData;
    private IEquippedItemHandler _equippedItemHandler;
    private void Awake();
    protected override void BeginOnServer();
    protected override void EndOnServer();
}