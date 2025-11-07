using System.Collections;
using FishNet;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Employees;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.ObjectScripts;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class StartMixingStationBehaviour : Behaviour
{
    public const float INSERT_INGREDIENT_BASE_TIME;
    private Chemist chemist;
    private Coroutine startRoutine;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EStartMixingStationBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EStartMixingStationBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public MixingStation targetStation { get; private set; }

    public override void Awake();
    public void AssignStation(MixingStation station);
    public override void End();
    public override void Pause();
    public override void ActiveMinPass();
    [ObserversRpc(RunLocally = true)]
    private void StartCook();
    private bool CanCookStart();
    private void StopCook();
    private Vector3 GetStationAccessPoint();
    private bool IsAtStation();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_StartCook_2166136261();
    private void RpcLogic___StartCook_2166136261();
    private void RpcReader___Observers_StartCook_2166136261(PooledReader PooledReader0, Channel channel);
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002EBehaviour_002EStartMixingStationBehaviour_Assembly_002DCSharp_002Edll();
}