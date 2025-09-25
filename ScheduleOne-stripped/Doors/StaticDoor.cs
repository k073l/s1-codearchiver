using System.Collections;
using System.Collections.Generic;
using FluffyUnderware.DevTools.Extensions;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using ScheduleOne.Map;
using ScheduleOne.NPCs;
using ScheduleOne.UI;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Doors;
public class StaticDoor : MonoBehaviour
{
    public const float KNOCK_COOLDOWN;
    public const float SUMMON_DURATION;
    [Header("References")]
    public Transform AccessPoint;
    public InteractableObject IntObj;
    public AudioSourceController KnockSound;
    public NPCEnterableBuilding Building;
    [Header("Settings")]
    public bool Usable;
    public bool CanKnock;
    private float timeSinceLastKnock;
    private int doorIndex;
    protected virtual void Awake();
    protected virtual void OnValidate();
    protected virtual void Update();
    protected virtual void Hovered();
    protected virtual bool CanKnockNow();
    protected virtual bool IsKnockValid(out string message);
    protected virtual void Interacted();
    protected virtual void Knock();
    protected virtual void NPCSelected(NPC npc);
}