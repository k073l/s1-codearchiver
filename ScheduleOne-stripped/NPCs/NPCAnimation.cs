using System;
using ScheduleOne.AvatarFramework.Animation;
using UnityEngine;

namespace ScheduleOne.NPCs;
public class NPCAnimation : MonoBehaviour
{
    protected NPC npc;
    private void Awake();
    private void Start();
    protected void Update();
    protected virtual void UpdateMovementAnimation();
    private void StandupStart();
    private void StandupDone();
    private void OnNPCVisibilityChanged(bool visible);
}