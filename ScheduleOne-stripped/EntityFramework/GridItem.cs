using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.EntityFramework;
public class GridItem : BuildableItem
{
    [HideInInspector]
    public List<CoordinateFootprintTilePair> CoordinateFootprintTilePairs;
    protected Guid _ownerGridGUID;
    protected Vector2 _originCoordinate;
    protected int _rotation;
    public List<CoordinatePair> CoordinatePairs;
    private bool NetworkInitialize___EarlyScheduleOne_002EEntityFramework_002EGridItemAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EEntityFramework_002EGridItemAssembly_002DCSharp_002Edll_Excuted;
    public FootprintTile OriginFootprint => CoordinateFootprintTilePairs[0].footprintTile;
    public int FootprintX => CoordinateFootprintTilePairs.OrderByDescending(default).FirstOrDefault().coord.x + 1;
    public int FootprintY => CoordinateFootprintTilePairs.OrderByDescending(default).FirstOrDefault().coord.y + 1;
    public Grid OwnerGrid { get; protected set; }

    public override void Awake();
    protected override void SendInitializationToServer();
    protected override void SendInitializationToClient(NetworkConnection conn);
    [ServerRpc(RequireOwnership = false)]
    public void InitializeGridItem_Server(ItemInstance instance, string gridGUID, Vector2 originCoordinate, int rotation, string GUID);
    [TargetRpc]
    [ObserversRpc(RunLocally = true)]
    private void InitializeGridItem_Client(NetworkConnection conn, ItemInstance instance, string gridGUID, Vector2 originCoordinate, int rotation, string GUID);
    public virtual void InitializeGridItem(ItemInstance instance, Grid grid, Vector2 originCoordinate, int rotation, string GUID);
    protected void SetGridData(Guid gridGUID, Vector2 originCoordinate, int rotation);
    private int ValidateRotation(int rotation);
    private void ProcessGridData();
    private void RefreshTransform();
    private void ClearPositionData();
    protected override void Destroy();
    protected virtual void OnTileTemperatureChanged(Tile tile, float newTemp);
    public float GetAverageTileTemperature();
    public float GetAverageCosmeticTileTemperature();
    public virtual void CalculateFootprintTileIntersections();
    public void SetFootprintTileVisiblity(bool visible);
    public FootprintTile GetFootprintTile(Coordinate coord);
    public Tile GetParentTileAtFootprintCoordinate(Coordinate footprintCoord);
    public virtual bool CanShareTileWith(List<GridItem> obstacles);
    public override BuildableItemData GetBaseData();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_InitializeGridItem_Server_2821640832(ItemInstance instance, string gridGUID, Vector2 originCoordinate, int rotation, string GUID);
    public void RpcLogic___InitializeGridItem_Server_2821640832(ItemInstance instance, string gridGUID, Vector2 originCoordinate, int rotation, string GUID);
    private void RpcReader___Server_InitializeGridItem_Server_2821640832(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Target_InitializeGridItem_Client_1883577149(NetworkConnection conn, ItemInstance instance, string gridGUID, Vector2 originCoordinate, int rotation, string GUID);
    private void RpcLogic___InitializeGridItem_Client_1883577149(NetworkConnection conn, ItemInstance instance, string gridGUID, Vector2 originCoordinate, int rotation, string GUID);
    private void RpcReader___Target_InitializeGridItem_Client_1883577149(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_InitializeGridItem_Client_1883577149(NetworkConnection conn, ItemInstance instance, string gridGUID, Vector2 originCoordinate, int rotation, string GUID);
    private void RpcReader___Observers_InitializeGridItem_Client_1883577149(PooledReader PooledReader0, Channel channel);
    protected override void Awake_UserLogic_ScheduleOne_002EEntityFramework_002EGridItem_Assembly_002DCSharp_002Edll();
}