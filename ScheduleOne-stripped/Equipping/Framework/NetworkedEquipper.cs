using System.Collections.Generic;
using System.Linq;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Object.Synchronizing;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using ScheduleOne.Core;
using ScheduleOne.Core.Equipping.Framework;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.ItemFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScheduleOne.Equipping.Framework;
public abstract class NetworkedEquipper : NetworkBehaviour
{
    [SyncObject]
    private readonly SyncList<EquippedItemHandler> _networkEquippedItems;
    private List<EquippedItemHandler> _allEquippedItems;
    private bool NetworkInitialize___EarlyScheduleOne_002EEquipping_002EFramework_002ENetworkedEquipperAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EEquipping_002EFramework_002ENetworkedEquipperAssembly_002DCSharp_002Edll_Excuted;
    protected abstract IEquippableUser GetUser();
    public override void OnStartClient();
    public IEquippedItemHandler Equip(EquippableData equippable, bool networked = true);
    public IEquippedItemHandler Equip(BaseItemInstance item, bool networked = true);
    public void Unequip(IEquippedItemHandler equippedItem);
    private void AddEquippedItem(EquippedItemHandler handler);
    private void RemoveEquippedItem(EquippedItemHandler handler);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    private void Unequip_Server(EquippedItemHandler handler);
    [ObserversRpc(RunLocally = true)]
    private void Unequip_Client(EquippedItemHandler handler);
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    private void AddNetworkedEquippedItem_Server(EquippedItemHandler handler);
    [ServerRpc(RunLocally = true, RequireOwnership = false)]
    private void RemoveNetworkedEquippedItem_Server(EquippedItemHandler handler);
    private IEquippedItemHandler CreateHandlerForEquippable(EquippableData equippable);
    private void NetworkEquippedItems_OnChange(SyncListOperation op, int index, EquippedItemHandler oldItem, EquippedItemHandler newItem, bool asServer);
    public void UnequipAll();
    private bool CanEquip(EquippableData equippable);
    private bool IsRightHandOccupied();
    private bool IsLeftHandOccupied();
    private bool IsItemEquipped(EquippedItemHandler handler);
    [Button]
    public void PrintLists();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_Unequip_Server_897730888(EquippedItemHandler handler);
    private void RpcLogic___Unequip_Server_897730888(EquippedItemHandler handler);
    private void RpcReader___Server_Unequip_Server_897730888(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_Unequip_Client_897730888(EquippedItemHandler handler);
    private void RpcLogic___Unequip_Client_897730888(EquippedItemHandler handler);
    private void RpcReader___Observers_Unequip_Client_897730888(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_AddNetworkedEquippedItem_Server_897730888(EquippedItemHandler handler);
    private void RpcLogic___AddNetworkedEquippedItem_Server_897730888(EquippedItemHandler handler);
    private void RpcReader___Server_AddNetworkedEquippedItem_Server_897730888(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_RemoveNetworkedEquippedItem_Server_897730888(EquippedItemHandler handler);
    private void RpcLogic___RemoveNetworkedEquippedItem_Server_897730888(EquippedItemHandler handler);
    private void RpcReader___Server_RemoveNetworkedEquippedItem_Server_897730888(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    public override void Awake();
}