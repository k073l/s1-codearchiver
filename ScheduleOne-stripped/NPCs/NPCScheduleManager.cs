using System;
using System.Collections.Generic;
using System.Linq;
using EasyButtons;
using FishNet;
using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Law;
using ScheduleOne.NPCs.Schedules;
using ScheduleOne.Persistence;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

namespace ScheduleOne.NPCs;
public class NPCScheduleManager : MonoBehaviour
{
    private static readonly NPCActionOrderByDescending orderByDescending;
    public bool DEBUG_MODE;
    [Header("References")]
    public GameObject[] EnabledDuringCurfew;
    public GameObject[] EnabledDuringNoCurfew;
    public List<NPCAction> ActionList;
    protected int lastProcessedTime;
    public bool ScheduleEnabled { get; protected set; }
    public bool CurfewModeEnabled { get; protected set; }
    public NPCAction ActiveAction { get; set; }
    public List<NPCAction> PendingActions { get; set; } = new List<NPCAction>();
    public NPC Npc { get; protected set; }
    protected List<NPCAction> ActionsAwaitingStart { get; set; } = new List<NPCAction>();
    protected TimeManager Time => NetworkSingleton<TimeManager>.Instance;

    protected virtual void Awake();
    protected virtual void Start();
    private void LocalPlayerSpawned();
    private void OnValidate();
    protected virtual void Update();
    public void EnableSchedule();
    public void DisableSchedule();
    [Button]
    public void InitializeActions();
    protected virtual void MinPass();
    private List<NPCAction> GetActionsOccurringAt(int time);
    private List<NPCAction> GetActionsTotallyOccurringWithinRange(int min, int max, bool checkShouldStart);
    private void StartAction(NPCAction action);
    private void EnforceState();
    public void EnforceState(bool initial = false);
    protected virtual void CurfewEnabled();
    protected virtual void CurfewDisabled();
    public void SetCurfewModeEnabled(bool enabled);
}