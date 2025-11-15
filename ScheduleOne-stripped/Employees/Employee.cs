using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Object.Synchronizing;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.DevUtilities;
using ScheduleOne.Dialogue;
using ScheduleOne.GameTime;
using ScheduleOne.Management;
using ScheduleOne.NPCs;
using ScheduleOne.NPCs.Behaviour;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Property;
using ScheduleOne.UI;
using ScheduleOne.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Employees;
public class Employee : NPC
{
    public class NoWorkReason
    {
        public string Reason;
        public string Fix;
        public int Priority;
        public NoWorkReason(string reason, string fix, int priority);
    }

    public const int MAX_CONSECUTIVE_PATHING_FAILURES;
    public bool DEBUG;
    [CompilerGenerated]
    [SyncVar]
    public bool _003CPaidForToday_003Ek__BackingField;
    [SerializeField]
    protected EEmployeeType Type;
    [Header("Payment")]
    public float SigningFee;
    public float DailyWage;
    [Header("References")]
    public IdleBehaviour WaitOutside;
    public MoveItemBehaviour MoveItemBehaviour;
    public DialogueContainer BedNotAssignedDialogue;
    public DialogueContainer NotPaidDialogue;
    public DialogueContainer WorkIssueDialogueTemplate;
    public DialogueContainer FireDialogue;
    public DialogueContainer TransferDialogue;
    private List<NoWorkReason> WorkIssues;
    protected bool initialized;
    protected int consecutivePathingFailures;
    private float timeOnLastPathingFailure;
    private Transform cachedNPCSpawnPoint;
    public SyncVar<bool> syncVar____003CPaidForToday_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002EEmployees_002EEmployeeAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EEmployees_002EEmployeeAssembly_002DCSharp_002Edll_Excuted;
    public ScheduleOne.Property.Property AssignedProperty { get; protected set; }
    public int EmployeeIndex { get; protected set; }
    public bool PaidForToday {[CompilerGenerated]
        get; [CompilerGenerated]
        private set; }
    public bool Fired { get; private set; }
    public bool IsWaitingOutside => WaitOutside.Active;
    public bool IsMale { get; private set; } = true;
    protected int AppearanceIndex { get; private set; }
    public EEmployeeType EmployeeType => Type;
    public int TimeSinceLastWorked { get; private set; }
    public bool SyncAccessor__003CPaidForToday_003Ek__BackingField { get; set; }

    protected override void Start();
    public override void OnStartServer();
    public override void OnSpawnServer(NetworkConnection connection);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public virtual void Initialize(NetworkConnection conn, string firstName, string lastName, string id, string guid, string propertyID, bool male, int appearanceIndex);
    protected virtual void AssignProperty(ScheduleOne.Property.Property prop, bool warp);
    protected virtual void UnassignProperty();
    [ServerRpc(RequireOwnership = false)]
    public void SendTransfer(string propertyCode);
    [ObserversRpc]
    private void TransferToProperty(string code);
    protected virtual void TransferToProperty(ScheduleOne.Property.Property prop);
    protected virtual void InitializeInfo(string firstName, string lastName, string id);
    protected virtual void InitializeAppearance(bool male, int index);
    protected virtual void CheckDialogueChoice(string choiceLabel);
    [ServerRpc(RequireOwnership = false)]
    public void SendFire();
    [ObserversRpc]
    private void ReceiveFire();
    protected virtual void ResetConfiguration();
    protected virtual void Fire();
    protected bool CanWork();
    protected override void OnDestroy();
    protected virtual void UpdateBehaviour();
    protected void MarkIsWorking();
    private void SetWaitOutside(bool wait);
    protected virtual bool ShouldIdle();
    protected override void OnTick();
    private void OnSleepEnd();
    public void SetIsPaid();
    public override bool ShouldSave();
    public override NPCData GetNPCData();
    public virtual EmployeeHome GetHome();
    public bool IsPayAvailable();
    public void RemoveDailyWage();
    public virtual bool GetWorkIssue(out DialogueContainer notWorkingReason);
    public virtual void SetIdle(bool idle);
    protected void LeavePropertyAndDespawn();
    [ObserversRpc(RunLocally = true)]
    public void SubmitNoWorkReason(string reason, string fix, int priority = 0);
    private bool ShouldShowNoWorkDialogue(bool enabled);
    private void OnNotWorkingDialogue();
    private bool ShouldShowFireDialogue(bool enabled);
    private void TradeItems();
    private void TradeItemsDone();
    protected void SetDestination(ITransitEntity transitEntity, bool teleportIfFail = true);
    protected unsafe void SetDestination(Vector3 position, bool teleportIfFail = true);
    protected virtual void WalkCallback(NPCMovement.WalkResult result);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_Initialize_2260823878(NetworkConnection conn, string firstName, string lastName, string id, string guid, string propertyID, bool male, int appearanceIndex);
    public virtual void RpcLogic___Initialize_2260823878(NetworkConnection conn, string firstName, string lastName, string id, string guid, string propertyID, bool male, int appearanceIndex);
    private void RpcReader___Observers_Initialize_2260823878(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_Initialize_2260823878(NetworkConnection conn, string firstName, string lastName, string id, string guid, string propertyID, bool male, int appearanceIndex);
    private void RpcReader___Target_Initialize_2260823878(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SendTransfer_3615296227(string propertyCode);
    public void RpcLogic___SendTransfer_3615296227(string propertyCode);
    private void RpcReader___Server_SendTransfer_3615296227(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_TransferToProperty_3615296227(string code);
    private void RpcLogic___TransferToProperty_3615296227(string code);
    private void RpcReader___Observers_TransferToProperty_3615296227(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SendFire_2166136261();
    public void RpcLogic___SendFire_2166136261();
    private void RpcReader___Server_SendFire_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_ReceiveFire_2166136261();
    private void RpcLogic___ReceiveFire_2166136261();
    private void RpcReader___Observers_ReceiveFire_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SubmitNoWorkReason_15643032(string reason, string fix, int priority = 0);
    public void RpcLogic___SubmitNoWorkReason_15643032(string reason, string fix, int priority = 0);
    private void RpcReader___Observers_SubmitNoWorkReason_15643032(PooledReader PooledReader0, Channel channel);
    public override bool ReadSyncVar___ScheduleOne_002EEmployees_002EEmployee(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    public override void Awake();
}