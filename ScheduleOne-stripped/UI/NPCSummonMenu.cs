using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using ScheduleOne.State;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class NPCSummonMenu : Singleton<NPCSummonMenu>
{
    [Header("References")]
    public Canvas Canvas;
    public RectTransform Container;
    public RectTransform EntryContainer;
    public RectTransform[] Entries;
    public MonoState State;
    private Action<NPC> callback;
    protected override void Start();
    public void Open(List<NPC> npcs, Action<NPC> _callback);
    public void Close();
    private void OnClose();
    public void NPCSelected(NPC npc);
}