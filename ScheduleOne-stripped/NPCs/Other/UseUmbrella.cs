using ScheduleOne.Core.Equipping.Framework;
using UnityEngine;

namespace ScheduleOne.NPCs.Other;
public class UseUmbrella : NPCDiscreteAction
{
    [Header("Components")]
    [SerializeField]
    private NPC _npc;
    [SerializeField]
    private EquippableData _umbrellaData;
    private IEquippedItemHandler _equippedItemHandler;
    private void Awake();
    protected override void BeginOnServer();
    protected override void EndOnServer();
}