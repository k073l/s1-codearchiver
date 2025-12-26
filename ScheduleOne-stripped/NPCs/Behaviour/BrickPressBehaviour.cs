using System.Collections;
using FishNet;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Employees;
using ScheduleOne.Management;
using ScheduleOne.ObjectScripts;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class BrickPressBehaviour : Behaviour
{
    public const float BASE_PACKAGING_TIME;
    private Coroutine packagingRoutine;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EBrickPressBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EBrickPressBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public BrickPress Press { get; protected set; }
    public bool PackagingInProgress { get; protected set; }

    public override void Activate();
    public override void Resume();
    public override void Pause();
    public override void Disable();
    public override void Deactivate();
    public override void OnActiveTick();
    private void StartPackaging();
    public void AssignStation(BrickPress press);
    public bool IsAtStation();
    public void GoToStation();
    [ObserversRpc(RunLocally = true)]
    public void BeginPackaging();
    private void StopPackaging();
    public bool IsStationReady(BrickPress press);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_BeginPackaging_2166136261();
    public void RpcLogic___BeginPackaging_2166136261();
    private void RpcReader___Observers_BeginPackaging_2166136261(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}