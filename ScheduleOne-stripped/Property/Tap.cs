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
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerTasks;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Property;
public class Tap : NetworkBehaviour, IUsable
{
    private const float FlowRateMultiplier;
    private const float HandleMoveSpeed;
    [SerializeField]
    private InteractableObject _interactable;
    [SerializeField]
    private Transform _handleTransform;
    [SerializeField]
    private Clickable _handleClickable;
    [SerializeField]
    private ParticleSystem _waterParticles;
    [SerializeField]
    private AudioSourceController _squeakSound;
    [SerializeField]
    private AudioSourceController _waterRunningSound;
    [CompilerGenerated]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    [HideInInspector]
    public bool _003CIsHeldOpen_003Ek__BackingField;
    [CompilerGenerated]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    [HideInInspector]
    public NetworkObject _003CNPCUserObject_003Ek__BackingField;
    [CompilerGenerated]
    [SyncVar( /*Could not decode attribute arguments.*/)]
    [HideInInspector]
    public NetworkObject _003CPlayerUserObject_003Ek__BackingField;
    private float _normalizedTapFlow;
    private Vector2 _defaultParticleStartSize;
    private float _maxTapOpenValue;
    public SyncVar<bool> syncVar____003CIsHeldOpen_003Ek__BackingField;
    public SyncVar<NetworkObject> syncVar____003CNPCUserObject_003Ek__BackingField;
    public SyncVar<NetworkObject> syncVar____003CPlayerUserObject_003Ek__BackingField;
    private bool NetworkInitialize___EarlyScheduleOne_002EProperty_002ETapAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EProperty_002ETapAssembly_002DCSharp_002Edll_Excuted;
    [field: SerializeField]
    public Transform CameraPos { get; private set; }

    [field: SerializeField]
    public Transform FillableModelContainer { get; private set; }
    public bool IsHeldOpen {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public float ActualFlowRate => 6f * _normalizedTapFlow;
    public NetworkObject NPCUserObject {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public NetworkObject PlayerUserObject {[CompilerGenerated]
        get; [CompilerGenerated]
        set; }
    public bool SyncAccessor__003CIsHeldOpen_003Ek__BackingField { get; set; }
    public NetworkObject SyncAccessor__003CNPCUserObject_003Ek__BackingField { get; set; }
    public NetworkObject SyncAccessor__003CPlayerUserObject_003Ek__BackingField { get; set; }

    public override void Awake();
    protected virtual void LateUpdate();
    private void UpdateTapVisuals();
    private void UpdateWaterSound();
    private void Hovered();
    private void Interacted();
    public void SetHandleEnabled(bool enabled);
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    private void SetHeldOpen(bool open);
    private void OnHandleClickStart(RaycastHit hit);
    private void OnHandleClickEnd();
    private bool CanInteract(out string invalidReason);
    public void SetMaxTapOpen(float max);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetPlayerUser(NetworkObject playerObject);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetNPCUser(NetworkObject npcObject);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SetHeldOpen_1140765316(bool open);
    private void RpcLogic___SetHeldOpen_1140765316(bool open);
    private void RpcReader___Server_SetHeldOpen_1140765316(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_SetPlayerUser_3323014238(NetworkObject playerObject);
    public void RpcLogic___SetPlayerUser_3323014238(NetworkObject playerObject);
    private void RpcReader___Server_SetPlayerUser_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_SetNPCUser_3323014238(NetworkObject npcObject);
    public void RpcLogic___SetNPCUser_3323014238(NetworkObject npcObject);
    private void RpcReader___Server_SetNPCUser_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    public override bool ReadSyncVar___ScheduleOne_002EProperty_002ETap(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    private void Awake_UserLogic_ScheduleOne_002EProperty_002ETap_Assembly_002DCSharp_002Edll();
}