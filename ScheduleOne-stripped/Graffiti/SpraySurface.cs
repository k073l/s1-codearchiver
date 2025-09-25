using System;
using System.Collections.Generic;
using System.Linq;
using EasyButtons;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using ScheduleOne.DevUtilities;
using ScheduleOne.Map;
using ScheduleOne.Persistence.Datas;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ScheduleOne.Graffiti;
public class SpraySurface : NetworkBehaviour, IGUIDRegisterable
{
    public const float PIXEL_SIZE;
    public const int PADDING;
    [Header("Settings")]
    public string BakedGUID;
    [Range(1f, 1000f)]
    public int Width;
    [Range(1f, 1000f)]
    public int Height;
    public AnimationCurve FalloffCurve;
    [Range(0f, 100f)]
    public int FalloffRadius;
    [Header("References")]
    public Transform BottomLeftPoint;
    public DecalProjector Projector;
    private Drawing cachedDrawing;
    public Action onDrawingChanged;
    private List<int> pastRequestIDs;
    private bool NetworkInitialize___EarlyScheduleOne_002EGraffiti_002ESpraySurfaceAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EGraffiti_002ESpraySurfaceAssembly_002DCSharp_002Edll_Excuted;
    public Guid GUID { get; protected set; }
    public NetworkObject CurrentEditor { get; private set; }
    public Drawing Drawing { get; private set; }
    public EMapRegion Region { get; private set; }
    public bool HasDrawingBeenFinalized { get; private set; }
    public Vector3 TopRightPoint => BottomLeftPoint.TransformPoint(new Vector3((float)(-Width) * 0.006666671f, (float)Height * 0.006666671f, 0f));

    public override void Awake();
    private void Start();
    protected override void OnValidate();
    private void ResizeProjector();
    public bool CanBeEdited();
    public override void OnSpawnServer(NetworkConnection connection);
    public void ReplicateTo(NetworkConnection conn);
    [ServerRpc(RequireOwnership = false)]
    public void SetCurrentEditor_Server(NetworkObject player);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void SetCurrentEditor_Client(NetworkConnection conn, NetworkObject player);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void AddStrokes_Server(List<SprayStroke> newStrokes, int requestID);
    [ObserversRpc(RunLocally = true)]
    private void AddStrokes_Client(List<SprayStroke> newStrokes, int requestID);
    [ServerRpc(RequireOwnership = false)]
    public void ClearDrawing();
    private void CreateNewDrawing();
    public void CacheDrawing();
    public void RestoreFromCache();
    public Vector3 ToWorldPosition(UShort2 coordinate, float offset = 0f);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void MarkDrawingFinalized();
    [ObserversRpc(RunLocally = true)]
    private void SetFinalized();
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void Set(NetworkConnection conn, SprayStroke[] strokes, bool hasBeenFinalized);
    private void DrawingChanged();
    private float[] GetFalloffTable();
    public void SetGUID(Guid guid);
    [Button]
    public void RegenerateGUID();
    public bool ShouldSave();
    public SpraySurfaceData GetSaveData();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SetCurrentEditor_Server_3323014238(NetworkObject player);
    public void RpcLogic___SetCurrentEditor_Server_3323014238(NetworkObject player);
    private void RpcReader___Server_SetCurrentEditor_Server_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetCurrentEditor_Client_1824087381(NetworkConnection conn, NetworkObject player);
    private void RpcLogic___SetCurrentEditor_Client_1824087381(NetworkConnection conn, NetworkObject player);
    private void RpcReader___Observers_SetCurrentEditor_Client_1824087381(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetCurrentEditor_Client_1824087381(NetworkConnection conn, NetworkObject player);
    private void RpcReader___Target_SetCurrentEditor_Client_1824087381(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_AddStrokes_Server_1511871282(List<SprayStroke> newStrokes, int requestID);
    public void RpcLogic___AddStrokes_Server_1511871282(List<SprayStroke> newStrokes, int requestID);
    private void RpcReader___Server_AddStrokes_Server_1511871282(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_AddStrokes_Client_1511871282(List<SprayStroke> newStrokes, int requestID);
    private void RpcLogic___AddStrokes_Client_1511871282(List<SprayStroke> newStrokes, int requestID);
    private void RpcReader___Observers_AddStrokes_Client_1511871282(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_ClearDrawing_2166136261();
    public void RpcLogic___ClearDrawing_2166136261();
    private void RpcReader___Server_ClearDrawing_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Server_MarkDrawingFinalized_2166136261();
    public void RpcLogic___MarkDrawingFinalized_2166136261();
    private void RpcReader___Server_MarkDrawingFinalized_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetFinalized_2166136261();
    private void RpcLogic___SetFinalized_2166136261();
    private void RpcReader___Observers_SetFinalized_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_Set_4105842735(NetworkConnection conn, SprayStroke[] strokes, bool hasBeenFinalized);
    public void RpcLogic___Set_4105842735(NetworkConnection conn, SprayStroke[] strokes, bool hasBeenFinalized);
    private void RpcReader___Observers_Set_4105842735(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_Set_4105842735(NetworkConnection conn, SprayStroke[] strokes, bool hasBeenFinalized);
    private void RpcReader___Target_Set_4105842735(PooledReader PooledReader0, Channel channel);
    private void Awake_UserLogic_ScheduleOne_002EGraffiti_002ESpraySurface_Assembly_002DCSharp_002Edll();
}