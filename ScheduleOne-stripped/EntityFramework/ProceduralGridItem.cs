using System;
using System.Collections;
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
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Property;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.EntityFramework;
public class ProceduralGridItem : BuildableItem
{
    public class FootprintTileMatch
    {
        public FootprintTile footprint;
        public ProceduralTile matchedTile;
    }

    [Header("Grid item data")]
    public List<CoordinateFootprintTilePair> CoordinateFootprintTilePairs;
    public ProceduralTile.EProceduralTileType ProceduralTileType;
    [SyncVar]
    [HideInInspector]
    public int Rotation;
    [SyncVar]
    [HideInInspector]
    public List<CoordinateProceduralTilePair> footprintTileMatches;
    public SyncVar<int> syncVar___Rotation;
    public SyncVar<List<CoordinateProceduralTilePair>> syncVar___footprintTileMatches;
    private bool NetworkInitialize___EarlyScheduleOne_002EEntityFramework_002EProceduralGridItemAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EEntityFramework_002EProceduralGridItemAssembly_002DCSharp_002Edll_Excuted;
    public int FootprintXSize => CoordinateFootprintTilePairs.OrderByDescending(default).FirstOrDefault().coord.x + 1;
    public int FootprintYSize => CoordinateFootprintTilePairs.OrderByDescending(default).FirstOrDefault().coord.y + 1;
    public int SyncAccessor_Rotation { get; set; }
    public List<CoordinateProceduralTilePair> SyncAccessor_footprintTileMatches { get; set; }

    public override void Awake();
    protected override void SendInitializationToServer();
    protected override void SendInitializationToClient(NetworkConnection conn);
    [ServerRpc(RequireOwnership = false)]
    public void InitializeProceduralGridItem_Server(ItemInstance instance, int _rotation, List<CoordinateProceduralTilePair> _footprintTileMatches, string GUID);
    [TargetRpc]
    [ObserversRpc(RunLocally = true)]
    public virtual void InitializeProceduralGridItem_Client(NetworkConnection conn, ItemInstance instance, int _rotation, List<CoordinateProceduralTilePair> _footprintTileMatches, string GUID);
    public virtual void InitializeProceduralGridItem(ItemInstance instance, int _rotation, List<CoordinateProceduralTilePair> _footprintTileMatches, string GUID);
    protected virtual void SetProceduralGridData(int _rotation, List<CoordinateProceduralTilePair> _footprintTileMatches);
    private void RefreshTransform();
    private void ClearPositionData();
    protected override void Destroy();
    protected override ScheduleOne.Property.Property GetProperty(Transform searchTransform = null);
    public virtual void CalculateFootprintTileIntersections();
    public void SetFootprintTileVisiblity(bool visible);
    public FootprintTile GetFootprintTile(Coordinate coord);
    public override BuildableItemData GetBaseData();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_InitializeProceduralGridItem_Server_638911643(ItemInstance instance, int _rotation, List<CoordinateProceduralTilePair> _footprintTileMatches, string GUID);
    public void RpcLogic___InitializeProceduralGridItem_Server_638911643(ItemInstance instance, int _rotation, List<CoordinateProceduralTilePair> _footprintTileMatches, string GUID);
    private void RpcReader___Server_InitializeProceduralGridItem_Server_638911643(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Target_InitializeProceduralGridItem_Client_3164718044(NetworkConnection conn, ItemInstance instance, int _rotation, List<CoordinateProceduralTilePair> _footprintTileMatches, string GUID);
    public virtual void RpcLogic___InitializeProceduralGridItem_Client_3164718044(NetworkConnection conn, ItemInstance instance, int _rotation, List<CoordinateProceduralTilePair> _footprintTileMatches, string GUID);
    private void RpcReader___Target_InitializeProceduralGridItem_Client_3164718044(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_InitializeProceduralGridItem_Client_3164718044(NetworkConnection conn, ItemInstance instance, int _rotation, List<CoordinateProceduralTilePair> _footprintTileMatches, string GUID);
    private void RpcReader___Observers_InitializeProceduralGridItem_Client_3164718044(PooledReader PooledReader0, Channel channel);
    public override bool ReadSyncVar___ScheduleOne_002EEntityFramework_002EProceduralGridItem(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    protected override void Awake_UserLogic_ScheduleOne_002EEntityFramework_002EProceduralGridItem_Assembly_002DCSharp_002Edll();
}