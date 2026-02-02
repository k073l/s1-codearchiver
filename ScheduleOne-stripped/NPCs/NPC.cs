using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EPOOutline;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using FluffyUnderware.DevTools.Extensions;
using ScheduleOne.AvatarFramework;
using ScheduleOne.AvatarFramework.Animation;
using ScheduleOne.AvatarFramework.Equipping;
using ScheduleOne.Combat;
using ScheduleOne.DevUtilities;
using ScheduleOne.Dialogue;
using ScheduleOne.Doors;
using ScheduleOne.Economy;
using ScheduleOne.GameTime;
using ScheduleOne.Interaction;
using ScheduleOne.ItemFramework;
using ScheduleOne.Map;
using ScheduleOne.Messaging;
using ScheduleOne.NPCs.Actions;
using ScheduleOne.NPCs.Behaviour;
using ScheduleOne.NPCs.Relation;
using ScheduleOne.NPCs.Responses;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Variables;
using ScheduleOne.Vehicles;
using ScheduleOne.Vehicles.AI;
using ScheduleOne.Vision;
using ScheduleOne.VoiceOver;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace ScheduleOne.NPCs;
[RequireComponent(typeof(NPCHealth))]
public class NPC : NetworkBehaviour, IGUIDRegisterable, ISaveable, ICombatTargetable, IDamageable, ISightable
{
    public const float PANIC_DURATION;
    public const bool RequiresRegionUnlocked;
    [Header("Info Settings")]
    public string FirstName;
    public bool hasLastName;
    public string LastName;
    public string ID;
    public Sprite MugshotSprite;
    public EMapRegion Region;
    [Header("If true, NPC will respawn next day instead of waiting 3 days.")]
    public bool IsImportant;
    [Header("Personality")]
    [Range(0f, 1f)]
    public float Aggression;
    [Header("References")]
    [SerializeField]
    protected Transform modelContainer;
    [SerializeField]
    protected InteractableObject intObj;
    public NPCMovement Movement;
    public DialogueHandler DialogueHandler;
    public Avatar Avatar;
    public NPCAwareness Awareness;
    public NPCResponses Responses;
    public NPCActions Actions;
    public NPCBehaviour Behaviour;
    public NPCInventory Inventory;
    public VOEmitter VoiceOverEmitter;
    public NPCHealth Health;
    public EntityVisibility Visibility;
    public Action<LandVehicle> onEnterVehicle;
    public Action<LandVehicle> onExitVehicle;
    [Header("Summoning")]
    public bool CanBeSummoned;
    [Header("Relationship")]
    public NPCRelationData RelationData;
    public string NPCUnlockedVariable;
    public bool ShowRelationshipInfo;
    [Header("Messaging")]
    public List<EConversationCategory> ConversationCategories;
    public bool MessagingKnownByDefault;
    public bool ConversationCanBeHidden;
    public Action onConversationCreated;
    [Header("Other Settings")]
    public bool CanOpenDoors;
    public bool OverrideParent;
    public Transform OverriddenParent;
    public bool IgnoreImpacts;
    [SerializeField]
    protected List<GameObject> OutlineRenderers;
    protected Outlinable OutlineEffect;
    [Header("GUID")]
    public string BakedGUID;
    public Action<bool> onVisibilityChanged;
    private Coroutine resetUnsettledCoroutine;
    private List<int> impactHistory;
    private int headlightStartTime;
    private int heaedLightsEndTime;
    protected float defaultAggression;
    private Coroutine lerpScaleRoutine;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ENPCAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ENPCAssembly_002DCSharp_002Edll_Excuted;
    public string fullName { get; }
    public float Scale { get; private set; } = 1f;
    public bool IsConscious { get; }
    public LandVehicle CurrentVehicle { get; protected set; }
    public bool IsInVehicle => (Object)(object)CurrentVehicle != (Object)null;
    public bool isInBuilding => (Object)(object)CurrentBuilding != (Object)null;
    public NPCEnterableBuilding CurrentBuilding { get; protected set; }
    public StaticDoor LastEnteredDoor { get; set; }
    public MSGConversation MSGConversation { get; protected set; }
    public string SaveFolderName => fullName;
    public string SaveFileName => "NPC";
    public Loader Loader => null;
    public bool ShouldSaveUnderFolder => true;
    public List<string> LocalExtraFiles { get; set; } = new List<string>
    {
        "Relationship",
        "MessageConversation"
    };
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; }
    public Vector3 CenterPoint => CenterPointTransform.position;
    public Transform CenterPointTransform => Avatar.CenterPointTransform;
    public Vector3 LookAtPoint => ((Component)Avatar.Eyes).transform.position;
    public bool IsCurrentlyTargetable { get; }
    public float RangedHitChanceMultiplier => 1f;
    public Vector3 Velocity => Movement.VelocityCalculator.Velocity;
    public VisionEvent HighestProgressionEvent { get; set; }
    public EntityVisibility VisibilityComponent => Visibility;
    public Guid GUID { get; protected set; }
    public bool isVisible { get; protected set; } = true;
    public bool isUnsettled { get; protected set; }
    public bool IsPanicked => TimeSincePanicked < 20f;
    public float TimeSincePanicked { get; protected set; } = 1000f;

    public void RecordLastKnownPosition(bool resetTimeSinceLastSeen);
    public float GetSearchTime();
    public bool IsCurrentlySightable();
    public override void Awake();
    protected virtual void CheckAndGetReferences();
    public virtual void InitializeSaveable();
    public void SetGUID(Guid guid);
    private void PlayerSpawned();
    protected virtual void CreateMessageConversation();
    protected virtual string GetMessagingName();
    public virtual Sprite GetMessagingIcon();
    public void SendTextMessage(string message);
    protected virtual void Start();
    protected virtual void OnDestroy();
    public override void OnSpawnServer(NetworkConnection connection);
    [ObserversRpc]
    private void SetTransform(NetworkConnection conn, Vector3 position, Quaternion rotation);
    protected virtual void MinPass();
    protected virtual void OnUncappedMinPass();
    protected virtual void OnTick();
    public virtual void SetVisible(bool visible, bool networked = false);
    [ObserversRpc(RunLocally = true)]
    private void SetVisible_Networked(bool visible);
    public void SetScale(float scale);
    public void SetScale(float scale, float lerpTime);
    protected virtual void ApplyScale();
    [ServerRpc(RequireOwnership = false)]
    public virtual void AimedAtByPlayer(NetworkObject player);
    public void OverrideAggression(float aggression);
    public void ResetAggression();
    protected virtual void OnDie();
    protected virtual void OnKnockedOut();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public virtual void SendImpact(Impact impact);
    [ObserversRpc(RunLocally = true)]
    public virtual void ReceiveImpact(Impact impact);
    public virtual void ProcessImpactForce(Vector3 forcePoint, Vector3 forceDirection, float force);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public virtual void EnterVehicle(NetworkConnection connection, LandVehicle veh);
    [ObserversRpc(RunLocally = true)]
    public virtual void ExitVehicle();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SendWorldspaceDialogueReaction(string key, float duration);
    [ObserversRpc(RunLocally = true)]
    private void PlayWorldspaceDialogueReaction(string key, float duration);
    [ServerRpc(RequireOwnership = false)]
    public void SendWorldSpaceDialogue(string text, float duration);
    [ObserversRpc(RunLocally = true)]
    public void ShowWorldSpaceDialogue(string text, float duration);
    private void Hovered_Internal();
    private void Interacted_Internal();
    protected virtual void Hovered();
    protected virtual void Interacted();
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void EnterBuilding(NetworkConnection connection, string buildingGUID, int doorIndex);
    protected virtual void EnterBuilding(string buildingGUID, int doorIndex);
    [ObserversRpc(RunLocally = true)]
    public void ExitBuilding(string buildingID = "");
    protected virtual void ExitBuilding(NPCEnterableBuilding building);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void SetEquippable_Client(NetworkConnection conn, string assetPath);
    public AvatarEquippable SetEquippable_Networked_Return(NetworkConnection conn, string assetPath);
    public AvatarEquippable SetEquippable_Return(string assetPath);
    [ObserversRpc(RunLocally = false, ExcludeServer = true)]
    private void SetEquippable_Networked_ExcludeServer(NetworkConnection conn, string assetPath);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void SendEquippableMessage_Networked(NetworkConnection conn, string message);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void SendEquippableMessage_Networked_Vector(NetworkConnection conn, string message, Vector3 data);
    [ServerRpc(RequireOwnership = false)]
    public void SendAnimationTrigger(string trigger);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void SetAnimationTrigger_Networked(NetworkConnection conn, string trigger);
    public void SetAnimationTrigger(string trigger);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void ResetAnimationTrigger_Networked(NetworkConnection conn, string trigger);
    public void ResetAnimationTrigger(string trigger);
    [ObserversRpc(RunLocally = true)]
    public void SetCrouched_Networked(bool crouched);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void SetAnimationBool_Networked(NetworkConnection conn, string id, bool value);
    public void SetAnimationBool(string trigger, bool val);
    protected virtual void SetUnsettled_30s(Player player);
    protected void SetUnsettled(float duration);
    [ServerRpc(RequireOwnership = false)]
    public void SetPanicked();
    [ObserversRpc]
    private void ReceivePanicked();
    [ObserversRpc]
    private void RemovePanicked();
    public virtual string GetNameAddress();
    public void PlayVO(EVOLineType lineType, bool network = false);
    [ServerRpc(RequireOwnership = false)]
    private void PlayVO_Server(EVOLineType lineType);
    [ObserversRpc(RunLocally = true)]
    private void PlayVO_Client(EVOLineType lineType);
    [TargetRpc]
    public void ReceiveRelationshipData(NetworkConnection conn, float relationship, bool unlocked);
    [ServerRpc(RequireOwnership = false)]
    public void SetIsBeingPickPocketed(bool pickpocketed);
    [ServerRpc(RequireOwnership = false)]
    public void SendRelationship(float relationship);
    [ObserversRpc]
    private void SetRelationship(float relationship);
    public void ShowOutline(Color color);
    public void HideOutline();
    public virtual bool ShouldSave();
    protected virtual bool ShouldSaveRelationshipData();
    protected bool ShouldSaveMessages();
    protected virtual bool ShouldSaveInventory();
    protected virtual bool ShouldSaveHealth();
    public string GetSaveString();
    public virtual NPCData GetNPCData();
    public virtual DynamicSaveData GetSaveData();
    public virtual List<string> WriteData(string parentFolderPath);
    public virtual void Load(NPCData data, string containerPath);
    public virtual void Load(DynamicSaveData dynamicData, NPCData npcData);
    NetworkObject ICombatTargetable.get_NetworkObject();
    GameObject IDamageable.get_gameObject();
    NetworkObject ISightable.get_NetworkObject();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_SetTransform_4260003484(NetworkConnection conn, Vector3 position, Quaternion rotation);
    private void RpcLogic___SetTransform_4260003484(NetworkConnection conn, Vector3 position, Quaternion rotation);
    private void RpcReader___Observers_SetTransform_4260003484(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetVisible_Networked_1140765316(bool visible);
    private void RpcLogic___SetVisible_Networked_1140765316(bool visible);
    private void RpcReader___Observers_SetVisible_Networked_1140765316(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_AimedAtByPlayer_3323014238(NetworkObject player);
    public virtual void RpcLogic___AimedAtByPlayer_3323014238(NetworkObject player);
    private void RpcReader___Server_AimedAtByPlayer_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_SendImpact_427288424(Impact impact);
    public virtual void RpcLogic___SendImpact_427288424(Impact impact);
    private void RpcReader___Server_SendImpact_427288424(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_ReceiveImpact_427288424(Impact impact);
    public virtual void RpcLogic___ReceiveImpact_427288424(Impact impact);
    private void RpcReader___Observers_ReceiveImpact_427288424(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_EnterVehicle_3321926803(NetworkConnection connection, LandVehicle veh);
    public virtual void RpcLogic___EnterVehicle_3321926803(NetworkConnection connection, LandVehicle veh);
    private void RpcReader___Observers_EnterVehicle_3321926803(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_EnterVehicle_3321926803(NetworkConnection connection, LandVehicle veh);
    private void RpcReader___Target_EnterVehicle_3321926803(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_ExitVehicle_2166136261();
    public virtual void RpcLogic___ExitVehicle_2166136261();
    private void RpcReader___Observers_ExitVehicle_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SendWorldspaceDialogueReaction_606697822(string key, float duration);
    public void RpcLogic___SendWorldspaceDialogueReaction_606697822(string key, float duration);
    private void RpcReader___Server_SendWorldspaceDialogueReaction_606697822(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_PlayWorldspaceDialogueReaction_606697822(string key, float duration);
    private void RpcLogic___PlayWorldspaceDialogueReaction_606697822(string key, float duration);
    private void RpcReader___Observers_PlayWorldspaceDialogueReaction_606697822(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SendWorldSpaceDialogue_606697822(string text, float duration);
    public void RpcLogic___SendWorldSpaceDialogue_606697822(string text, float duration);
    private void RpcReader___Server_SendWorldSpaceDialogue_606697822(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_ShowWorldSpaceDialogue_606697822(string text, float duration);
    public void RpcLogic___ShowWorldSpaceDialogue_606697822(string text, float duration);
    private void RpcReader___Observers_ShowWorldSpaceDialogue_606697822(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_EnterBuilding_3905681115(NetworkConnection connection, string buildingGUID, int doorIndex);
    public void RpcLogic___EnterBuilding_3905681115(NetworkConnection connection, string buildingGUID, int doorIndex);
    private void RpcReader___Observers_EnterBuilding_3905681115(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_EnterBuilding_3905681115(NetworkConnection connection, string buildingGUID, int doorIndex);
    private void RpcReader___Target_EnterBuilding_3905681115(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_ExitBuilding_3615296227(string buildingID = "");
    public void RpcLogic___ExitBuilding_3615296227(string buildingID = "");
    private void RpcReader___Observers_ExitBuilding_3615296227(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetEquippable_Client_2971853958(NetworkConnection conn, string assetPath);
    public void RpcLogic___SetEquippable_Client_2971853958(NetworkConnection conn, string assetPath);
    private void RpcReader___Observers_SetEquippable_Client_2971853958(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetEquippable_Client_2971853958(NetworkConnection conn, string assetPath);
    private void RpcReader___Target_SetEquippable_Client_2971853958(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetEquippable_Networked_ExcludeServer_2971853958(NetworkConnection conn, string assetPath);
    private void RpcLogic___SetEquippable_Networked_ExcludeServer_2971853958(NetworkConnection conn, string assetPath);
    private void RpcReader___Observers_SetEquippable_Networked_ExcludeServer_2971853958(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SendEquippableMessage_Networked_2971853958(NetworkConnection conn, string message);
    public void RpcLogic___SendEquippableMessage_Networked_2971853958(NetworkConnection conn, string message);
    private void RpcReader___Observers_SendEquippableMessage_Networked_2971853958(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SendEquippableMessage_Networked_2971853958(NetworkConnection conn, string message);
    private void RpcReader___Target_SendEquippableMessage_Networked_2971853958(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SendEquippableMessage_Networked_Vector_4022222929(NetworkConnection conn, string message, Vector3 data);
    public void RpcLogic___SendEquippableMessage_Networked_Vector_4022222929(NetworkConnection conn, string message, Vector3 data);
    private void RpcReader___Observers_SendEquippableMessage_Networked_Vector_4022222929(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SendEquippableMessage_Networked_Vector_4022222929(NetworkConnection conn, string message, Vector3 data);
    private void RpcReader___Target_SendEquippableMessage_Networked_Vector_4022222929(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SendAnimationTrigger_3615296227(string trigger);
    public void RpcLogic___SendAnimationTrigger_3615296227(string trigger);
    private void RpcReader___Server_SendAnimationTrigger_3615296227(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetAnimationTrigger_Networked_2971853958(NetworkConnection conn, string trigger);
    public void RpcLogic___SetAnimationTrigger_Networked_2971853958(NetworkConnection conn, string trigger);
    private void RpcReader___Observers_SetAnimationTrigger_Networked_2971853958(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetAnimationTrigger_Networked_2971853958(NetworkConnection conn, string trigger);
    private void RpcReader___Target_SetAnimationTrigger_Networked_2971853958(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_ResetAnimationTrigger_Networked_2971853958(NetworkConnection conn, string trigger);
    public void RpcLogic___ResetAnimationTrigger_Networked_2971853958(NetworkConnection conn, string trigger);
    private void RpcReader___Observers_ResetAnimationTrigger_Networked_2971853958(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_ResetAnimationTrigger_Networked_2971853958(NetworkConnection conn, string trigger);
    private void RpcReader___Target_ResetAnimationTrigger_Networked_2971853958(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetCrouched_Networked_1140765316(bool crouched);
    public void RpcLogic___SetCrouched_Networked_1140765316(bool crouched);
    private void RpcReader___Observers_SetCrouched_Networked_1140765316(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetAnimationBool_Networked_619441887(NetworkConnection conn, string id, bool value);
    public void RpcLogic___SetAnimationBool_Networked_619441887(NetworkConnection conn, string id, bool value);
    private void RpcReader___Observers_SetAnimationBool_Networked_619441887(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetAnimationBool_Networked_619441887(NetworkConnection conn, string id, bool value);
    private void RpcReader___Target_SetAnimationBool_Networked_619441887(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetPanicked_2166136261();
    public void RpcLogic___SetPanicked_2166136261();
    private void RpcReader___Server_SetPanicked_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_ReceivePanicked_2166136261();
    private void RpcLogic___ReceivePanicked_2166136261();
    private void RpcReader___Observers_ReceivePanicked_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_RemovePanicked_2166136261();
    private void RpcLogic___RemovePanicked_2166136261();
    private void RpcReader___Observers_RemovePanicked_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_PlayVO_Server_1710085680(EVOLineType lineType);
    private void RpcLogic___PlayVO_Server_1710085680(EVOLineType lineType);
    private void RpcReader___Server_PlayVO_Server_1710085680(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_PlayVO_Client_1710085680(EVOLineType lineType);
    private void RpcLogic___PlayVO_Client_1710085680(EVOLineType lineType);
    private void RpcReader___Observers_PlayVO_Client_1710085680(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_ReceiveRelationshipData_4052192084(NetworkConnection conn, float relationship, bool unlocked);
    public void RpcLogic___ReceiveRelationshipData_4052192084(NetworkConnection conn, float relationship, bool unlocked);
    private void RpcReader___Target_ReceiveRelationshipData_4052192084(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetIsBeingPickPocketed_1140765316(bool pickpocketed);
    public void RpcLogic___SetIsBeingPickPocketed_1140765316(bool pickpocketed);
    private void RpcReader___Server_SetIsBeingPickPocketed_1140765316(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_SendRelationship_431000436(float relationship);
    public void RpcLogic___SendRelationship_431000436(float relationship);
    private void RpcReader___Server_SendRelationship_431000436(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetRelationship_431000436(float relationship);
    private void RpcLogic___SetRelationship_431000436(float relationship);
    private void RpcReader___Observers_SetRelationship_431000436(PooledReader PooledReader0, Channel channel);
    protected virtual void Awake_UserLogic_ScheduleOne_002ENPCs_002ENPC_Assembly_002DCSharp_002Edll();
}