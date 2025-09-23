using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.Management;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Tools;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.UI.Management;
public class NPCSelector : MonoBehaviour
{
    public const float SELECTION_RANGE;
    [Header("Settings")]
    public LayerMask DetectionMask;
    public Color HoverOutlineColor;
    private Type TypeRequirement;
    private Action<NPC> callback;
    private NPC hoveredNPC;
    private NPC highlightedNPC;
    public bool IsOpen { get; protected set; }

    private void Start();
    public virtual void Open(string selectionTitle, Type typeRequirement, Action<NPC> _callback);
    public virtual void Close(bool returnToClipboard);
    private void Update();
    private NPC GetHoveredNPC();
    public bool IsNPCTypeValid(NPC npc);
    public void NPCClicked(NPC npc);
    private void ClipboardClosed();
    private void Exit(ExitAction exitAction);
}