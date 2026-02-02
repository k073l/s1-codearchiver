using System;
using System.Collections;
using System.Collections.Generic;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using GameKit.Utilities;
using ScheduleOne.Cartel;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Graffiti;
using ScheduleOne.Levelling;
using ScheduleOne.NPCs.Other;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class GraffitiBehaviour : Behaviour
{
    public const int InterruptionXP;
    public const float InterruptionCartelInfluenceChange;
    [Header("Graffiti: Components")]
    [SerializeField]
    private SprayPaint _sprayPaint;
    [Header("Graffiti: Settings")]
    [SerializeField]
    private Vector2Int _graffitiDurationInMinutes;
    [SerializeField]
    private Vector2 _minMaxEffectLoopDuration;
    [SerializeField]
    private Vector2 _minMaxEffectPauseDuration;
    [SerializeField]
    private Gradient _effectColorGradient;
    [Header("Graffiti: Drawings")]
    [SerializeField]
    private List<SerializedGraffitiDrawing> _drawinglist;
    [Header("Graffiti: Interruptions")]
    [SerializeField]
    private List<Behaviour> _interruptingBehaviours;
    [Header("Debugging & Development")]
    [SerializeField]
    private bool _debugMode;
    private int _duration;
    private Coroutine _effectCoroutine;
    private WorldSpraySurface _spraySurface;
    private bool _graffitiCompleted;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EGraffitiBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EGraffitiBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public override void OnSpawnServer(NetworkConnection connection);
    public override void Enable();
    public override void Disable();
    public override void Activate();
    public override void Pause();
    public override void Deactivate();
    [ServerRpc(RequireOwnership = false)]
    private void Complete_Server();
    private void CheckForInterruptions();
    private void SetupEvents();
    private void CleanUp();
    private void OnMinPass();
    private void OnTimePass(int minutes);
    private void StopEffectRoutine();
    private IEnumerator DoEffectRoutine();
    [ObserversRpc(RunLocally = true)]
    public void SetSpraySurface_Client(NetworkConnection conn, NetworkObject surface);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_Complete_Server_2166136261();
    private void RpcLogic___Complete_Server_2166136261();
    private void RpcReader___Server_Complete_Server_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetSpraySurface_Client_1824087381(NetworkConnection conn, NetworkObject surface);
    public void RpcLogic___SetSpraySurface_Client_1824087381(NetworkConnection conn, NetworkObject surface);
    private void RpcReader___Observers_SetSpraySurface_Client_1824087381(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}