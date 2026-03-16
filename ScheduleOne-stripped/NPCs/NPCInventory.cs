using System;
using System.Collections.Generic;
using System.Linq;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Interaction;
using ScheduleOne.ItemFramework;
using ScheduleOne.Money;
using ScheduleOne.Networking;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.NPCs;
public class NPCInventory : NetworkBehaviour, IItemSlotOwner
{
    [Serializable]
    public class RandomInventoryItem
    {
        public StorableItemDefinition ItemDefinition;
        [Range(0f, 10f)]
        public float Weight;
    }

    public delegate bool ItemFilter(ItemInstance item);
    public InteractableObject PickpocketIntObj;
    public const float COOLDOWN;
    [Header("Settings")]
    public int SlotCount;
    public bool CanBePickpocketed;
    public float PickpocketDifficultyMultiplier;
    public bool ClearInventoryEachNight;
    public ItemDefinition[] TestItems;
    public ItemDefinition[] StartupItems;
    [Header("Random cash")]
    public bool RandomCash;
    public int RandomCashMin;
    public int RandomCashMax;
    [Header("Random items")]
    public bool RandomItems;
    public bool AllowDuplicateRandomItems;
    public RandomInventoryItem[] RandomInventoryItems;
    public int RandomItemMin;
    public int RandomItemMax;
    private NPC npc;
    public UnityEvent onContentsChanged;
    private float timeOnLastExpire;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ENPCInventoryAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ENPCInventoryAssembly_002DCSharp_002Edll_Excuted;
    public List<ItemSlot> ItemSlots { get; set; } = new List<ItemSlot>();

    public override void Awake();
    protected virtual void Start();
    public override void OnSpawnServer(NetworkConnection connection);
    private void OnDestroy();
    protected virtual void OnSleepStart();
    public void AddRandomItemsToInventory();
    private void AddRandomCashInstance();
    private StorableItemDefinition GetRandomInventoryItem(List<string> excludeIDs);
    [Button]
    public float GetTotalRandomInventoryItemWeight();
    public int GetIdenticalItemAmount(ItemInstance item);
    public int GetMaxItemCount(string[] ids);
    public bool CanItemFit(ItemInstance item);
    public int GetCapacityForItem(ItemInstance item);
    public void InsertItem(ItemInstance item, bool network = true);
    public ItemInstance GetFirstItem(string id, ItemFilter filter = null);
    public ItemInstance GetFirstIdenticalItem(ItemInstance item, ItemFilter filter = null);
    protected virtual void InventoryContentsChanged();
    public void Hovered();
    public void Interacted();
    private void StartPickpocket();
    public void ExpirePickpocket();
    private bool CanPickpocket();
    [Button]
    public void PrintInventoryContents();
    public void Clear();
    public float GetCashInInventory();
    public void RemoveCash(float amountToRemove);
    public void AddCash(float amountToAdd);
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public void SetStoredInstance(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void SetStoredInstance_Internal(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public void SetItemSlotQuantity(int itemSlotIndex, int quantity);
    [ObserversRpc(RunLocally = true)]
    private void SetItemSlotQuantity_Internal(int itemSlotIndex, int quantity);
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public void SetSlotLocked(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    [TargetRpc]
    [ObserversRpc(RunLocally = true)]
    private void SetSlotLocked_Internal(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    public void SetSlotFilter(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void SetSlotFilter_Internal(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SetStoredInstance_2652194801(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    public void RpcLogic___SetStoredInstance_2652194801(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    private void RpcReader___Server_SetStoredInstance_2652194801(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetStoredInstance_Internal_2652194801(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    private void RpcLogic___SetStoredInstance_Internal_2652194801(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    private void RpcReader___Observers_SetStoredInstance_Internal_2652194801(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetStoredInstance_Internal_2652194801(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);
    private void RpcReader___Target_SetStoredInstance_Internal_2652194801(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetItemSlotQuantity_1692629761(int itemSlotIndex, int quantity);
    public void RpcLogic___SetItemSlotQuantity_1692629761(int itemSlotIndex, int quantity);
    private void RpcReader___Server_SetItemSlotQuantity_1692629761(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetItemSlotQuantity_Internal_1692629761(int itemSlotIndex, int quantity);
    private void RpcLogic___SetItemSlotQuantity_Internal_1692629761(int itemSlotIndex, int quantity);
    private void RpcReader___Observers_SetItemSlotQuantity_Internal_1692629761(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetSlotLocked_3170825843(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    public void RpcLogic___SetSlotLocked_3170825843(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    private void RpcReader___Server_SetSlotLocked_3170825843(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Target_SetSlotLocked_Internal_3170825843(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    private void RpcLogic___SetSlotLocked_Internal_3170825843(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    private void RpcReader___Target_SetSlotLocked_Internal_3170825843(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetSlotLocked_Internal_3170825843(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);
    private void RpcReader___Observers_SetSlotLocked_Internal_3170825843(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SetSlotFilter_527532783(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    public void RpcLogic___SetSlotFilter_527532783(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    private void RpcReader___Server_SetSlotFilter_527532783(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetSlotFilter_Internal_527532783(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    private void RpcLogic___SetSlotFilter_Internal_527532783(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    private void RpcReader___Observers_SetSlotFilter_Internal_527532783(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetSlotFilter_Internal_527532783(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);
    private void RpcReader___Target_SetSlotFilter_Internal_527532783(PooledReader PooledReader0, Channel channel);
    protected virtual void Awake_UserLogic_ScheduleOne_002ENPCs_002ENPCInventory_Assembly_002DCSharp_002Edll();
}