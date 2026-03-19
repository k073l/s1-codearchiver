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
using ScheduleOne.Persistence.Datas;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace ScheduleOne.Graffiti;
public class SpraySurface : NetworkBehaviour
{
    public const float PIXEL_SIZE;
    [Header("Settings")]
    public bool Editable;
    [Range(1f, 1000f)]
    public int Width;
    [Range(1f, 1000f)]
    public int Height;
    public AnimationCurve FalloffCurve;
    [SerializeField]
    public bool IsVandalismSurface;
    [Header("References")]
    public Transform BottomLeftPoint;
    public DecalProjector Projector;
    protected Drawing drawing;
    private Drawing cachedDrawing;
    public Action onDrawingChanged;
    private List<int> pastRequestIDs;
    private bool NetworkInitialize___EarlyScheduleOne_002EGraffiti_002ESpraySurfaceAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EGraffiti_002ESpraySurfaceAssembly_002DCSharp_002Edll_Excuted;
    public NetworkObject CurrentEditor { get; private set; }
    public int DrawingStrokeCount { get; }
    public Texture DrawingOutputTexture { get; }
    public int DrawingPaintedPixelCount { get; set; }
    public int RoundedWidth => Mathf.NextPowerOfTwo(Width);
    public int RoundedHeight => Mathf.NextPowerOfTwo(Height);
    public bool ContainsCartelGraffiti { get; set; }
    public Vector3 TopRightPoint => BottomLeftPoint.TransformPoint(new Vector3((float)(-Width) * 0.006666671f, (float)Height * 0.006666671f, 0f));
    public Vector3 CenterPoint => BottomLeftPoint.TransformPoint(new Vector3((float)(-Width) * 0.006666671f / 2f, (float)Height * 0.006666671f / 2f, 0f));

    public override void Awake();
    protected override void OnValidate();
    private void ResizeProjector();
    public bool CanBeEdited(bool checkEditor);
    public bool CanUndo();
    public override void OnSpawnServer(NetworkConnection connection);
    public virtual void ReplicateTo(NetworkConnection conn);
    [ServerRpc(RequireOwnership = false)]
    public void SetCurrentEditor_Server(NetworkObject player);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void SetCurrentEditor_Client(NetworkConnection conn, NetworkObject player);
    public virtual void OnEditingFinished();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void AddStrokes_Server(List<SprayStroke> newStrokes, int requestID);
    [ObserversRpc(RunLocally = true)]
    private void AddStrokes_Client(List<SprayStroke> newStrokes, int requestID);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void AddTextureToHistory_Server(int requestID);
    [ObserversRpc(RunLocally = true)]
    private void AddTextureToHistory_Client(int requestID);
    public void CacheDrawing();
    public void PrintHistoryCount();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void Undo_Server(int requestID);
    [ObserversRpc(RunLocally = true)]
    private void Undo_Client(int requestID);
    public virtual void CleanGraffiti();
    [ServerRpc(RequireOwnership = false)]
    public void ClearDrawing();
    public void EnsureDrawingExists();
    protected void CreateNewDrawing();
    public void RestoreFromCache();
    public Vector3 ToWorldPosition(UShort2 coordinate, float offset = 0f);
    public void DrawPaintedPixel(PixelData data, bool applyTexture);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    public void Set(NetworkConnection conn, SprayStroke[] strokes, bool isCartelGraffiti);
    private void DrawingChanged();
    public SerializedGraffitiDrawing GetSerializedDrawing();
    [Button]
    public void LoadSerializedDrawing(SerializedGraffitiDrawing serializedDrawing, bool isCartelGraffiti);
    public bool WillDrawingFit(int width, int height);
    public static int GetPadding(byte strokeSize);
    public virtual bool ShouldSave();
    public virtual SpraySurfaceData GetSaveData();
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
    private void RpcWriter___Server_AddTextureToHistory_Server_3316948804(int requestID);
    public void RpcLogic___AddTextureToHistory_Server_3316948804(int requestID);
    private void RpcReader___Server_AddTextureToHistory_Server_3316948804(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_AddTextureToHistory_Client_3316948804(int requestID);
    private void RpcLogic___AddTextureToHistory_Client_3316948804(int requestID);
    private void RpcReader___Observers_AddTextureToHistory_Client_3316948804(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_Undo_Server_3316948804(int requestID);
    public void RpcLogic___Undo_Server_3316948804(int requestID);
    private void RpcReader___Server_Undo_Server_3316948804(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_Undo_Client_3316948804(int requestID);
    private void RpcLogic___Undo_Client_3316948804(int requestID);
    private void RpcReader___Observers_Undo_Client_3316948804(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_ClearDrawing_2166136261();
    public void RpcLogic___ClearDrawing_2166136261();
    private void RpcReader___Server_ClearDrawing_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_Set_4105842735(NetworkConnection conn, SprayStroke[] strokes, bool isCartelGraffiti);
    public void RpcLogic___Set_4105842735(NetworkConnection conn, SprayStroke[] strokes, bool isCartelGraffiti);
    private void RpcReader___Observers_Set_4105842735(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_Set_4105842735(NetworkConnection conn, SprayStroke[] strokes, bool isCartelGraffiti);
    private void RpcReader___Target_Set_4105842735(PooledReader PooledReader0, Channel channel);
    protected virtual void Awake_UserLogic_ScheduleOne_002EGraffiti_002ESpraySurface_Assembly_002DCSharp_002Edll();
}