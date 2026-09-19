using ScheduleOne.AvatarFramework.Animation;
using UnityEngine;

namespace ScheduleOne.NPCs.Other;
public class NPCAuxAction : NPCDiscreteAction
{
    [Header("Components")]
    [SerializeField]
    private string _animBoolName;
    [SerializeField]
    private GameObject _auxEffect;
    private NPC _npc;
    private AvatarAnimation _anim;
    private void Awake();
    protected override void BeginOnClient();
    protected override void EndOnClient();
}