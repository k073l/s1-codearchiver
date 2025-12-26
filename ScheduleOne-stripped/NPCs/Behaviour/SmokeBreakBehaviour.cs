using System;
using System.Collections.Generic;
using System.Linq;
using EasyButtons;
using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.NPCs.Other;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class SmokeBreakBehaviour : Behaviour
{
    [Header("Components")]
    public SmokeCigarette SmokeCigarette;
    [Header("Smoke Break Settings")]
    public Vector2Int MinMaxSmokeBreak;
    public float maxDistanceToSmokeLocation;
    [Header("Smoking Locations")]
    public List<Transform> SmokeBreakLocations;
    [Header("Debug")]
    [SerializeField]
    private bool _debugMode;
    [SerializeField]
    private int _ocationOverride;
    [SerializeField]
    private bool _showMaxDistance;
    [SerializeField]
    private bool _showLocationGizmos;
    [SerializeField]
    private bool _showLookAtGizmos;
    private int _smokeBreakDuration;
    private Transform _currentSmokeLocation;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002ESmokeBreakBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002ESmokeBreakBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public override void OnStartServer();
    private void SetupEvents();
    public override void Enable();
    public override void Activate();
    public override void Deactivate();
    private void BeginSmokeBreak();
    private void EndSmokeBreak();
    private void CheckSmokeBreakEnd();
    private void UpdateSmokeBreakDuration(int amount);
    protected override void WalkCallback(NPCMovement.WalkResult result);
    private void OnTimeSkipped(int skippedTimeInMintues);
    private void OnHourPass();
    [Button]
    public void ChangeLocation();
    [Button]
    public void ActivateSmokeBreak();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}