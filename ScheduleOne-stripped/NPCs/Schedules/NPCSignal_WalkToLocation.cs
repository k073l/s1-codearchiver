using FishNet;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using UnityEngine;

namespace ScheduleOne.NPCs.Schedules;
public class NPCSignal_WalkToLocation : NPCSignal
{
    public Transform Destination;
    public bool FaceDestinationDir;
    public float DestinationThreshold;
    public bool WarpIfSkipped;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ESchedules_002ENPCSignal_WalkToLocationAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ESchedules_002ENPCSignal_WalkToLocationAssembly_002DCSharp_002Edll_Excuted;
    public new string ActionName => "Walk to location";

    public override string GetName();
    public override void Started();
    public override void ActiveUpdate();
    public override void LateStarted();
    public override void Interrupt();
    public override void Resume();
    public override void Skipped();
    private bool IsAtDestination();
    protected override void WalkCallback(NPCMovement.WalkResult result);
    [ObserversRpc]
    private void ReachedDestination();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_ReachedDestination_2166136261();
    private void RpcLogic___ReachedDestination_2166136261();
    private void RpcReader___Observers_ReachedDestination_2166136261(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}