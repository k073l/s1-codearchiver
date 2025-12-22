using System.Collections;
using FishNet;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.StationFramework;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class UseSpawnStationBehaviour : Behaviour
{
    private const float TaskDuration;
    private const float ProximityThreshold;
    private const string AnimationBoolName;
    private bool _currentlyUsingStation;
    private Coroutine _workRoutine;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EUseSpawnStationBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EUseSpawnStationBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public MushroomSpawnStation Station { get; protected set; }

    public void AssignStation(MushroomSpawnStation station);
    public override void Activate();
    public override void Deactivate();
    public override void Resume();
    public override void Pause();
    public override void OnActiveTick();
    public bool IsAtStation();
    public void GoToStation();
    [ObserversRpc(RunLocally = true)]
    public void BeginWork();
    private void StopWork();
    public bool IsStationReady(MushroomSpawnStation station);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_BeginWork_2166136261();
    public void RpcLogic___BeginWork_2166136261();
    private void RpcReader___Observers_BeginWork_2166136261(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}