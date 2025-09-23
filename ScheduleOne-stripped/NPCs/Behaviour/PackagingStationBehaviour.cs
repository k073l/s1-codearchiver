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
public class PackagingStationBehaviour : Behaviour
{
    public const float BASE_PACKAGING_TIME;
    private Coroutine packagingRoutine;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EPackagingStationBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EPackagingStationBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public PackagingStation Station { get; protected set; }
    public bool PackagingInProgress { get; protected set; }

    protected override void Begin();
    protected override void Resume();
    protected override void Pause();
    public override void Disable();
    protected override void End();
    public override void ActiveMinPass();
    private void StartPackaging();
    public void AssignStation(PackagingStation station);
    public bool IsAtStation();
    public void GoToStation();
    [ObserversRpc(RunLocally = true)]
    public void BeginPackaging();
    private void StopPackaging();
    public bool IsStationReady(PackagingStation station);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_BeginPackaging_2166136261();
    public void RpcLogic___BeginPackaging_2166136261();
    private void RpcReader___Observers_BeginPackaging_2166136261(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}