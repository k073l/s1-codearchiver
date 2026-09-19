using ScheduleOne.AvatarFramework.Animation;
using UnityEngine;

namespace ScheduleOne.NPCs.Other;
public class PissAuxAction : NPCDiscreteAction
{
    [Header("Components")]
    [SerializeField]
    private GameObject _pissEffect;
    private NPC _npc;
    private AvatarAnimation _anim;
    private void Awake();
    protected override void BeginOnClient();
    protected override void EndOnClient();
}