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
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Networking;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using ScheduleOne.Property;
using ScheduleOne.UI.Phone.Delivery;
using ScheduleOne.UI.Shop;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Delivery;
public class DeliveryManager : NetworkSingleton<DeliveryManager>, IBaseSaveable, ISaveable
{
    public List<DeliveryInstance> Deliveries;
    public UnityEvent<DeliveryInstance> onDeliveryCreated;
    public UnityEvent<DeliveryInstance> onDeliveryCompleted;
    private DeliveriesLoader loader;
    private List<string> writtenVehicles;
    private Dictionary<DeliveryInstance, int> minsSinceVehicleEmpty;
    private bool NetworkInitialize___EarlyScheduleOne_002EDelivery_002EDeliveryManagerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EDelivery_002EDeliveryManagerAssembly_002DCSharp_002Edll_Excuted;
    public string SaveFolderName => "Deliveries";
    public string SaveFileName => "Deliveries";
    public Loader Loader => loader;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public bool HasChanged { get; set; }
    public int LoadOrder { get; }

    public override void Awake();
    protected override void Start();
    public virtual void InitializeSaveable();
    public override void OnSpawnServer(NetworkConnection connection);
    private void OnMinPass();
    public bool IsLoadingBayFree(ScheduleOne.Property.Property destination, int loadingDockIndex);
    [ServerRpc(RequireOwnership = false)]
    public void SendDelivery(DeliveryInstance delivery);
    [ObserversRpc]
    [TargetRpc]
    private void ReceiveDelivery(NetworkConnection conn, DeliveryInstance delivery);
    [ObserversRpc(RunLocally = true)]
    private void SetDeliveryState(string deliveryID, EDeliveryStatus status);
    private DeliveryInstance GetDelivery(string deliveryID);
    public DeliveryInstance GetDelivery(ScheduleOne.Property.Property destination);
    public DeliveryInstance GetActiveShopDelivery(DeliveryShop shop);
    public ShopInterface GetShopInterface(string shopName);
    public virtual string GetSaveString();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SendDelivery_2813439055(DeliveryInstance delivery);
    public void RpcLogic___SendDelivery_2813439055(DeliveryInstance delivery);
    private void RpcReader___Server_SendDelivery_2813439055(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_ReceiveDelivery_2795369214(NetworkConnection conn, DeliveryInstance delivery);
    private void RpcLogic___ReceiveDelivery_2795369214(NetworkConnection conn, DeliveryInstance delivery);
    private void RpcReader___Observers_ReceiveDelivery_2795369214(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_ReceiveDelivery_2795369214(NetworkConnection conn, DeliveryInstance delivery);
    private void RpcReader___Target_ReceiveDelivery_2795369214(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetDeliveryState_316609003(string deliveryID, EDeliveryStatus status);
    private void RpcLogic___SetDeliveryState_316609003(string deliveryID, EDeliveryStatus status);
    private void RpcReader___Observers_SetDeliveryState_316609003(PooledReader PooledReader0, Channel channel);
    protected override void Awake_UserLogic_ScheduleOne_002EDelivery_002EDeliveryManager_Assembly_002DCSharp_002Edll();
}